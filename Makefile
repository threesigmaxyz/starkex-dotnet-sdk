.PHONY: *

# Github Actions
test-main-ga:
	@docker pull catthehacker/ubuntu:act-latest && act -W .github/workflows/main.yml -s NUGET_API_KEY=${NUGET_API_KEY} \
		-s READ_PACKAGES_TOKEN=${READ_PACKAGES_TOKEN} \
		-s GITHUB_TOKEN=${GITHUB_TOKEN}

test-pull-request-ga:
	@docker pull catthehacker/ubuntu:act-latest && act -W .github/workflows/pull_request.yml \
		-s NUGET_API_KEY=${NUGET_API_KEY} \
		-s READ_PACKAGES_TOKEN=${READ_PACKAGES_TOKEN} \
		-s GITHUB_TOKEN=${GITHUB_TOKEN}

test-all-ga:
	@docker pull catthehacker/ubuntu:act-latest && act \
		-s NUGET_API_KEY=${NUGET_API_KEY} \
		-s READ_PACKAGES_TOKEN=${READ_PACKAGES_TOKEN} \
		-s GITHUB_TOKEN=${GITHUB_TOKEN}
