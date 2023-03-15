namespace StarkEx.Crypto.SDK.DifferentialTests.Helpers.Attributes;

using System.Reflection;
using Xunit.Sdk;

public class RepeatAttribute : DataAttribute
{
    private readonly int count;

    public RepeatAttribute(int count)
    {
        if (count < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(count),
                "Repeat count must be greater than 0.");
        }

        this.count = count;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        return Enumerable.Range(1, count).Select(n => new object[] { n });
    }
}
