# Contributing

Thank you for your interest in contributing to ConsoleAppVisuals! We welcome contributions from everyone. By participating in this project, you agree to abide by the code of conduct outlined in the [CODE_OF_CONDUCT](CODE_OF_CONDUCT.md) file.

## How Can I Contribute?

### Reporting Bugs

If you encounter a bug while using ConsoleAppVisuals, please ensure that the bug hasn't already been reported by checking the Issues section of our repository. If it hasn't been reported yet, please open a new issue and provide as much detail as possible, including:

A clear and descriptive title
Steps to reproduce the bug
Expected behavior
Any error messages or screenshots if applicable

### Suggesting Enhancements

If you have ideas for enhancements or new features, we'd love to hear them! You can submit your suggestions by opening a new issue in the [Issues section](https://github.com/MorganKryze/ConsoleAppVisuals/issues) of our repository. Please provide a clear description of the enhancement and why you think it would be beneficial.

### Contributing to code

We welcome contributions in the form of code changes! If you'd like to contribute code, please follow these steps:

- Fork the repository and create a new branch for your feature or bug fix.
- Make your changes and ensure that they adhere to our coding standards.
- Write tests for your code if applicable.
- Submit a pull request to the main branch of our repository.

Before submitting your pull request, please ensure that you have:

- Included a clear and descriptive title for your pull request.
- Provided a detailed description of the changes made.
- Mentioned any related issues or pull requests.

#### Versioning conventions

We use the [Semantic Versioning](https://semver.org/) convention for versioning. The version number is composed of three parts: Major, Minor, and Patch. We also use a suffix to denote pre-release versions (vX.Y.Z-PreRelease):

- Major. Breaking changes
- Minor: New features, but backwards compatible
- Patch: Backwards compatible bug fixes only
- -Suffix (optional): a hyphen followed by a string denoting a pre-release version (following the Semantic Versioning or SemVer« convention)

For the pre-release suffix, we use the following conventions:

- -alpha: Alpha release, typically used for work-in-progress and experimentation (No tests or docs at this point)
- -beta: Beta release, typically one that is feature complete for the next planned release, but may contain known bugs (No docs at this point)
- -rc: Release candidate, typically a release that's potentially final (stable) unless significant bugs emerge (contains tests and docs)

Example: v1.0.0-alpha < v1.0.0-alpha.1 < v1.0.0-beta < v1.0.0-beta.2 < v1.0.0-beta.11 < v1.0.0-rc.1 < v1.0.0

#### Testing Conventions

For testing, we use the following conventions:

- Tests should be written in the `testing` directory.
- Tests filenames should follow the `ClassToTest.Tests.cs` pattern.
- Classes should have a `TestCleanup` function.
- Tests are written using the `MSTests` framework.
- Tests methods names should be descriptive and follow the `ElementToTest_BehaviorExpected` pattern.
- Tests should have the `TestMethod` attribute.
- Tests should have the `TestCategory("ClassToTest")` attribute.
- Tests content should follow the `Arrange`, `Act`, `Assert` pattern.

#### Commit names conventions

For commit names, we use the github hooks:

- New feature: `:feat:` • 🌟
- refactor: `:refactor:` • 🚧
- New tests: `:test:` • ✅
- Update of project's CI/CD: `:ci:` • 🤖
- Update of documentation: `:docs:` • 📖
- Bug fix: `:fix:` • 🚑
- Aesthetic improvement: `:style:` • 💄
- Update project's dependencies: `:build:` • 📦
- Add or remove a file: `:file:` • 📄

We also use the following conventions:

- Commit names should be written in the present tense.
- Commit names should be descriptive and concise.

### Adding your custom font

If you want to contribute to the library by adding a font, you can do so by creating a pull request on the [GitHub repository](https://github.com/MorganKryze/ConsoleAppVisuals/pulls).

Here are the steps to follow:

1. Fork the repository and create a new branch for your new font.
2. Add your font to the `src/ConsoleAppVisuals/fonts` directory.
3. Make sure to match all the requirements for the font defined in the [font article](https://morgankryze.github.io/ConsoleAppVisuals/articles/create_font.html).
4. Add your font name to the `Font` enum (`src/ConsoleAppVisuals/enums/Font.cs`) and precise the author and the height of the characters in the metadata comments.
5. Submit a pull request to the dev branch of the repository.

After these steps, your font will be reviewed and merged into the library to be available for everyone.

### Submitting example project

If you want to contribute to the library by adding an example project, you can do so by following [this template](https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/.github/example_template.md) and the guidelines given in the Examples section of the [documentation](https://morgankryze.github.io/ConsoleAppVisuals/examples).

Finally, submit a pull request to the dev branch of the repository or reach us at [morgan@kodelab.fr](mailto:morgan@kodelab.fr).

## Reviewing Pull Requests

All pull requests will be reviewed by members of the project maintainers team. Please be patient while we review your contribution. We may provide feedback or request changes before merging your pull request.

## Code of Conduct

Please note that this project is governed by our [Code of Conduct](CODE_OF_CONDUCT.md). We expect all contributors to adhere to this code when participating in our community.

## Get in Touch

If you have any questions or need further assistance, feel free to reach out to us via [email](mailto:morgan@kodelab.fr) or join our [community chat](https://github.com/MorganKryze/ConsoleAppVisuals/discussions).
