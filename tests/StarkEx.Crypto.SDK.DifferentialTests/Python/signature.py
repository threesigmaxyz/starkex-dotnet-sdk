###############################################################################
# Copyright 2019 StarkWare Industries Ltd.                                    #
#                                                                             #
# Licensed under the Apache License, Version 2.0 (the "License").             #
# You may not use this file except in compliance with the License.            #
# You may obtain a copy of the License at                                     #
#                                                                             #
# https://www.starkware.co/open-source-license/                               #
#                                                                             #
# Unless required by applicable law or agreed to in writing,                  #
# software distributed under the License is distributed on an "AS IS" BASIS,  #
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.    #
# See the License for the specific language governing permissions             #
# and limitations under the License.                                          #
###############################################################################


from typing import Tuple

import mpmath
import sympy
from sympy.core.numbers import igcdex

# A type that represents a point (x,y) on an elliptic curve.
ECPoint = Tuple[int, int]


def pi_as_string(digits: int) -> str:
    """
    Returns pi as a string of decimal digits without the decimal point ("314...").
    """
    mpmath.mp.dps = digits  # Set number of digits.
    return '3' + str(mpmath.mp.pi)[2:]


def is_quad_residue(n: int, p: int) -> bool:
    """
    Returns True if n is a quadratic residue mod p.
    """
    return sympy.is_quad_residue(n, p)


def sqrt_mod(n: int, p: int) -> int:
    """
    Finds the minimum positive integer m such that (m*m) % p == n
    """
    return min(sympy.sqrt_mod(n, p, all_roots=True))


def div_mod(n: int, m: int, p: int) -> int:
    """
    Finds a nonnegative integer 0 <= x < p such that (m * x) % p == n
    """
    a, b, c = igcdex(m, p)
    assert c == 1
    return (n * a) % p


def ec_add(point1: ECPoint, point2: ECPoint, p: int) -> ECPoint:
    """
    Gets two points on an elliptic curve mod p and returns their sum.
    Assumes the points are given in affine form (x, y) and have different x coordinates.
    """
    assert (point1[0] - point2[0]) % p != 0
    m = div_mod(point1[1] - point2[1], point1[0] - point2[0], p)
    x = (m * m - point1[0] - point2[0]) % p
    y = (m * (point1[0] - x) - point1[1]) % p
    return x, y


def ec_neg(point: ECPoint, p: int) -> ECPoint:
    """
    Given a point (x,y) return (x, -y)
    """
    x, y = point
    return (x, (-y) % p)


def ec_double(point: ECPoint, alpha: int, p: int) -> ECPoint:
    """
    Doubles a point on an elliptic curve with the equation y^2 = x^3 + alpha*x + beta mod p.
    Assumes the point is given in affine form (x, y) and has y != 0.
    """
    assert point[1] % p != 0
    m = div_mod(3 * point[0] * point[0] + alpha, 2 * point[1], p)
    x = (m * m - 2 * point[0]) % p
    y = (m * (point[0] - x) - point[1]) % p
    return x, y


def ec_mult(m: int, point: ECPoint, alpha: int, p: int) -> ECPoint:
    """
    Multiplies by m a point on the elliptic curve with equation y^2 = x^3 + alpha*x + beta mod p.
    Assumes the point is given in affine form (x, y) and that 0 < m < order(point).
    """
    if m == 1:
        return point
    if m % 2 == 0:
        return ec_mult(m // 2, ec_double(point, alpha, p), alpha, p)
    return ec_add(ec_mult(m - 1, point, alpha, p), point, p)


import hashlib
import json
import math
import os
import random
from typing import Optional, Tuple, Union

from ecdsa.rfc6979 import generate_k

# TODO from .math_utils import ECPoint, div_mod, ec_add, ec_double, ec_mult, is_quad_residue, sqrt_mod

PEDERSEN_HASH_POINT_FILENAME = os.path.join(
    os.path.dirname(__file__), 'pedersen_params.json')
PEDERSEN_PARAMS = json.load(open(PEDERSEN_HASH_POINT_FILENAME))

FIELD_PRIME = PEDERSEN_PARAMS['FIELD_PRIME']
FIELD_GEN = PEDERSEN_PARAMS['FIELD_GEN']
ALPHA = PEDERSEN_PARAMS['ALPHA']
BETA = PEDERSEN_PARAMS['BETA']
EC_ORDER = PEDERSEN_PARAMS['EC_ORDER']
CONSTANT_POINTS = PEDERSEN_PARAMS['CONSTANT_POINTS']

N_ELEMENT_BITS_ECDSA = math.floor(math.log(FIELD_PRIME, 2))
assert N_ELEMENT_BITS_ECDSA == 251

N_ELEMENT_BITS_HASH = FIELD_PRIME.bit_length()
assert N_ELEMENT_BITS_HASH == 252

# Elliptic curve parameters.
assert 2 ** N_ELEMENT_BITS_ECDSA < EC_ORDER < FIELD_PRIME

SHIFT_POINT = CONSTANT_POINTS[0]
MINUS_SHIFT_POINT = (SHIFT_POINT[0], FIELD_PRIME - SHIFT_POINT[1])
EC_GEN = CONSTANT_POINTS[1]

assert SHIFT_POINT == [0x49ee3eba8c1600700ee1b87eb599f16716b0b1022947733551fde4050ca6804,
                       0x3ca0cfe4b3bc6ddf346d49d06ea0ed34e621062c0e056c1d0405d266e10268a]
assert EC_GEN == [0x1ef15c18599971b7beced415a40f0c7deacfd9b0d1819e03d723d8bc943cfca,
                  0x5668060aa49730b7be4801df46ec62de53ecd11abe43a32873000c36e8dc1f]

#########
# ECDSA #
#########

# A type for the digital signature.
ECSignature = Tuple[int, int]


class InvalidPublicKeyError(Exception):
    def __init__(self):
        super().__init__('Given x coordinate does not represent any point on the elliptic curve.')


def get_y_coordinate(stark_key_x_coordinate: int) -> int:
    """
    Given the x coordinate of a stark_key, returns a possible y coordinate such that together the
    point (x,y) is on the curve.
    Note that the real y coordinate is either y or -y.
    If x is invalid stark_key it throws an error.
    """

    x = stark_key_x_coordinate
    y_squared = (x * x * x + ALPHA * x + BETA) % FIELD_PRIME
    if not is_quad_residue(y_squared, FIELD_PRIME):
        raise InvalidPublicKeyError()
    return sqrt_mod(y_squared, FIELD_PRIME)


def get_random_private_key() -> int:
    # NOTE: It is IMPORTANT to use a strong random function here.
    return random.randint(1, EC_ORDER - 1)


def private_key_to_ec_point_on_stark_curve(priv_key: int) -> ECPoint:
    assert 0 < priv_key < EC_ORDER
    return ec_mult(priv_key, EC_GEN, ALPHA, FIELD_PRIME)


def private_to_stark_key(priv_key: int) -> int:
    return private_key_to_ec_point_on_stark_curve(priv_key)[0]


def inv_mod_curve_size(x: int) -> int:
    return div_mod(1, x, EC_ORDER)


def generate_k_rfc6979(msg_hash: int, priv_key: int, seed: Optional[int] = None) -> int:
    # Pad the message hash, for consistency with the elliptic.js library.
    if 1 <= msg_hash.bit_length() % 8 <= 4 and msg_hash.bit_length() >= 248:
        # Only if we are one-nibble short:
        msg_hash *= 16

    if seed is None:
        extra_entropy = b''
    else:
        extra_entropy = seed.to_bytes(math.ceil(seed.bit_length() / 8), 'big')

    return generate_k(EC_ORDER, priv_key, hashlib.sha256,
                      msg_hash.to_bytes(math.ceil(msg_hash.bit_length() / 8), 'big'),
                      extra_entropy=extra_entropy)


def sign(msg_hash: int, priv_key: int, seed: Optional[int] = None) -> ECSignature:
    # Note: msg_hash must be smaller than 2**N_ELEMENT_BITS_ECDSA.
    # Message whose hash is >= 2**N_ELEMENT_BITS_ECDSA cannot be signed.
    # This happens with a very small probability.
    assert 0 <= msg_hash < 2 ** N_ELEMENT_BITS_ECDSA, 'Message not signable.'

    # Choose a valid k. In our version of ECDSA not every k value is valid,
    # and there is a negligible probability a drawn k cannot be used for signing.
    # This is why we have this loop.
    while True:
        k = generate_k_rfc6979(msg_hash, priv_key, seed)
        # Update seed for next iteration in case the value of k is bad.
        if seed is None:
            seed = 1
        else:
            seed += 1

        # Cannot fail because 0 < k < EC_ORDER and EC_ORDER is prime.
        x = ec_mult(k, EC_GEN, ALPHA, FIELD_PRIME)[0]

        # DIFF: in classic ECDSA, we take int(x) % n.
        r = int(x)
        if not (1 <= r < 2 ** N_ELEMENT_BITS_ECDSA):
            # Bad value. This fails with negligible probability.
            continue

        if (msg_hash + r * priv_key) % EC_ORDER == 0:
            # Bad value. This fails with negligible probability.
            continue

        w = div_mod(k, msg_hash + r * priv_key, EC_ORDER)
        if not (1 <= w < 2 ** N_ELEMENT_BITS_ECDSA):
            # Bad value. This fails with negligible probability.
            continue

        s = inv_mod_curve_size(w)
        return r, s


def mimic_ec_mult_air(m: int, point: ECPoint, shift_point: ECPoint) -> ECPoint:
    """
    Computes m * point + shift_point using the same steps like the AIR and throws an exception if
    and only if the AIR errors.
    """
    assert 0 < m < 2 ** N_ELEMENT_BITS_ECDSA
    partial_sum = shift_point
    for _ in range(N_ELEMENT_BITS_ECDSA):
        assert partial_sum[0] != point[0]
        if m & 1:
            partial_sum = ec_add(partial_sum, point, FIELD_PRIME)
        point = ec_double(point, ALPHA, FIELD_PRIME)
        m >>= 1
    assert m == 0
    return partial_sum


def verify(msg_hash: int, r: int, s: int, public_key: Union[int, ECPoint]) -> bool:
    # Compute w = s^-1 (mod EC_ORDER).
    assert 1 <= s < EC_ORDER, 's = %s' % s
    w = inv_mod_curve_size(s)

    # Preassumptions:
    # DIFF: in classic ECDSA, we assert 1 <= r, w <= EC_ORDER-1.
    # Since r, w < 2**N_ELEMENT_BITS_ECDSA < EC_ORDER, we only need to verify r, w != 0.
    assert 1 <= r < 2 ** N_ELEMENT_BITS_ECDSA, 'r = %s' % r
    assert 1 <= w < 2 ** N_ELEMENT_BITS_ECDSA, 'w = %s' % w
    assert 0 <= msg_hash < 2 ** N_ELEMENT_BITS_ECDSA, 'msg_hash = %s' % msg_hash

    if isinstance(public_key, int):
        # Only the x coordinate of the point is given, check the two possibilities for the y
        # coordinate.
        try:
            y = get_y_coordinate(public_key)
        except InvalidPublicKeyError:
            return False
        assert pow(y, 2, FIELD_PRIME) == (
            pow(public_key, 3, FIELD_PRIME) + ALPHA * public_key + BETA) % FIELD_PRIME
        return verify(msg_hash, r, s, (public_key, y)) or \
               verify(msg_hash, r, s, (public_key, (-y) % FIELD_PRIME))
    else:
        # The public key is provided as a point.
        # Verify it is on the curve.
        assert (public_key[1] ** 2 - (public_key[0] ** 3 + ALPHA *
                                      public_key[0] + BETA)) % FIELD_PRIME == 0

    # Signature validation.
    # DIFF: original formula is:
    # x = (w*msg_hash)*EC_GEN + (w*r)*public_key
    # While what we implement is:
    # x = w*(msg_hash*EC_GEN + r*public_key).
    # While both mathematically equivalent, one might error while the other doesn't,
    # given the current implementation.
    # This formula ensures that if the verification errors in our AIR, it errors here as well.
    try:
        zG = mimic_ec_mult_air(msg_hash, EC_GEN, MINUS_SHIFT_POINT)
        rQ = mimic_ec_mult_air(r, public_key, SHIFT_POINT)
        wB = mimic_ec_mult_air(w, ec_add(zG, rQ, FIELD_PRIME), SHIFT_POINT)
        x = ec_add(wB, MINUS_SHIFT_POINT, FIELD_PRIME)[0]
    except AssertionError:
        return False

    # DIFF: Here we drop the mod n from classic ECDSA.
    return r == x


#################
# Pedersen hash #
#################

def pedersen_hash(*elements: int) -> int:
    return pedersen_hash_as_point(*elements)[0]


def pedersen_hash_as_point(*elements: int) -> ECPoint:
    """
    Similar to pedersen_hash but also returns the y coordinate of the resulting EC point.
    This function is used for testing.
    """
    point = SHIFT_POINT
    for i, x in enumerate(elements):
        assert 0 <= x < FIELD_PRIME
        point_list = CONSTANT_POINTS[2 + i * N_ELEMENT_BITS_HASH:2 + (i + 1) * N_ELEMENT_BITS_HASH]
        assert len(point_list) == N_ELEMENT_BITS_HASH
        for pt in point_list:
            assert point[0] != pt[0], 'Unhashable input.'
            if x & 1:
                point = ec_add(point, pt, FIELD_PRIME)
            x >>= 1
        assert x == 0
    return point


######################
# Differential Tests #
######################


import argparse


if __name__ == '__main__':
    parser = argparse.ArgumentParser(
        description='Helper script for differential testing of the StarkEx.Crypto.SDK package.')
    subparsers = parser.add_subparsers(dest="subcommand")

    # Hash subcommand parser
    hash_cmd_parser = subparsers.add_parser("hash", help="Compute the Pedersen hash of two field elements.")
    hash_cmd_parser.add_argument('left_field', type=int, help='The right field to hash.')
    hash_cmd_parser.add_argument('right_field', type=int, help='The left field to hash.')

    # Sign subcommand parser
    sign_cmd_parser = subparsers.add_parser("sign", help="Compute a STARK signature.")
    sign_cmd_parser.add_argument("message_hash", type=str, help="The Pedersen hash of the message to sign.")
    sign_cmd_parser.add_argument("private_key", type=str, help="The STARK private key to use for signing.")

    # Verify subcommand parser
    verify_cmd_parser = subparsers.add_parser("verify", help="Verify a STARK signature.")
    verify_cmd_parser.add_argument("message_hash", type=str, help="The Pedersen hash of the message to verify.")
    verify_cmd_parser.add_argument("signature_r", type=str, help="The STARK signature R to verify.")
    verify_cmd_parser.add_argument("signature_s", type=str, help="The STARK signature S to verify.")
    verify_cmd_parser.add_argument("public_key", type=str, help="The STARK public key to verify the signature.")

    # AIR multiply subcommand parser
    air_multiply_cmd_parser = subparsers.add_parser("air-multiply", help="Execute AIR compatible EC multiplication.")
    air_multiply_cmd_parser.add_argument("value", type=int)
    air_multiply_cmd_parser.add_argument("gx", type=str)
    air_multiply_cmd_parser.add_argument("gy", type=str)
    air_multiply_cmd_parser.add_argument("sx", type=str)
    air_multiply_cmd_parser.add_argument("sy", type=str)

    # Parse command arguments
    args = parser.parse_args()

    # Execute command
    if args.subcommand == "hash":
        hash_result = pedersen_hash(args.left_field, args.right_field)
        print(hash_result)
    elif args.subcommand == "sign":
        sign_result = sign(int(args.message_hash, 16), int(args.private_key, 16))
        print(hex(sign_result[0])[2:])
        print(hex(sign_result[1])[2:])
    elif args.subcommand == "verify":
        verify_result = verify(
            msg_hash=int(args.message_hash, 16),
            r=int(args.signature_r, 16),
            s=int(args.signature_s, 16),
            public_key=int(args.public_key, 16)
        )
        print(verify_result)
    elif args.subcommand == "air-multiply":
        air_multiply_result = mimic_ec_mult_air(
            m=args.value,
            point=(int(args.gx, 16), int(args.gy, 16)),
            shift_point=(int(args.sx, 16), int(args.sy, 16)))
        print(hex(air_multiply_result[0])[2:])
        print(hex(air_multiply_result[1])[2:])
    else:
        print("No subcommand specified.")
