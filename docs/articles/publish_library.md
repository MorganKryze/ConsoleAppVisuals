# Publish your library

## Introduction

This article will guide you through the process of publishing a package on NuGet.org and GitHub packages using GitHub actions. This will enable you to share your library with the world.

NuGet is a package manager for .NET that allows you to share your code with the world. It is a great way to share your library with the community and to make it easy for others to use your code.

## Prerequisites

- Having looked at the project from the [Introduction section](/introduction/index.html)
- [.NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0) or later
- [NuGet account](https://www.nuget.org/users/account/LogOn?returnUrl=%2F), preferably for you on an outlook email address
- [Github account](https://github.com/login)
- Put your project on GitHub to be able to use GitHub actions

## Preparing you project

We will take the example project of the [Introduction section](/introduction/index.html) and we will publish it on NuGet.org and GitHub packages as an example.

As a reminder, here is the file structure of the project:

```bash
Example_project  <-- root
└───MyApp
    ├───bin
    ├───MyApp.csproj
    └───Program.cs
```

### `README.md` & `LICENSE`

This part is not mandatory but highly recommended.

Readme files are a great way to introduce your project to the world. It is the first thing people will see when they visit your repository. It is a good practice to include a README file in your project. [Learn more](https://docs.github.com/en/repositories/managing-your-repositorys-settings-and-features/customizing-your-repository/about-readmes)

The license file is also important. It is a way to tell people what they can and cannot do with your project. The default license is the MIT license that let the user a lot a freedom with your code. [Learn more](https://docs.github.com/en/repositories/managing-your-repositorys-settings-and-features/customizing-your-repository/licensing-a-repository)

Here is an example of a README file:

```markdown
# MyApp

> A simple console app for demonstration purposes

## Installation

Describe how to install your project

## Usage

Describe how to use your project

## Contributing

Describe how to contribute to your project

## License

MIT
```

And here is an example of a LICENSE file:

```markdown
MIT License

Copyright (c) 2024 YourName

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.
```

### `MyApp.csproj`

C# project files (`.csproj`) are the files that contain all the information about your project. It is where you define the target framework, the dependencies, the version of your project, and much more. [Learn more](https://docs.microsoft.com/dotnet/core/tools/csproj)

Here is a template for a `.csproj` file made for publishing a package:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <!-- MANDATORY: add your metadata comments to your package -->
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
  </PropertyGroup>

  <PropertyGroup>
    <Title>MyApp</Title>
    <!-- Change this by the name of your package, it must be unique -->
    <PackageId>MyFirstApp1234</PackageId>
    <!-- Change this by the name of the publisher on nuget.org -->
    <Authors>YourNugetAccountName</Authors>
    <!-- Change this by the version of your package -->
    <Version>0.0.0</Version>
    <!-- Change this by the description of your package -->
    <Description>Descriptive description to describe the package use</Description>
    <PackageLicenseExpression>MIT</PackageLicenseExpression>
    <!-- Change this by the tags of your package -->
    <PackageTags>Test, Discovery</PackageTags>
    <!-- Change this by the url of your repository on GitHub -->
    <RepositoryUrl>https://github.com/MorganKryze/ConsoleAppVisuals</RepositoryUrl>
    <RepositoryType>git</RepositoryType>
    <PackageReadmeFile>README.md</PackageReadmeFile>
    <PackageLicenseFile>LICENSE</PackageLicenseFile>
    <!-- This line make your package deterministic -->
    <EmbedUntrackedSources>true</EmbedUntrackedSources>
  </PropertyGroup>

  <PropertyGroup>
    <!-- NuGet Package Explorer health standards -->
    <EmbedUntrackedSources>true</EmbedUntrackedSources>
    <PublishRepositoryUrl>true</PublishRepositoryUrl>
    <IncludeSymbols>true</IncludeSymbols>
  </PropertyGroup>

  <ItemGroup>
    <!-- MANDATORY: give the filepath to the files declared -->
    <!-- OPTIONAL: give a custom path to store them inside your package -->
    <None Include="..\README.md" Pack="true" PackagePath=""/>
    <None Include="..\LICENSE" Pack="true" PackagePath=""/>
  </ItemGroup>
</Project>
```

Consider checking that the filepaths are accurate. Here is the file structure of the project updated:

```bash
Example_project  <-- root
├───MyApp
│   ├───bin
│   ├───MyApp.csproj
│   └───Program.cs
├───LICENSE
└───README.md
```

[Learn more](https://github.com/clairernovotny/DeterministicBuilds) about making your project deterministic.

### Build the project

Now we will be able to build your project including the metadata for the package.

```bash
cd MyApp
```

```bash
dotnet build -c Release
```

Optional: You can also run the tests to make sure everything is working as expected by creating a local package:

```bash
dotnet pack -c Release
```

You will then find the NuGet package in the `bin/Release` folder of your project.

## Publish your package

### API keys

API keys are a way to authenticate yourself to a service. Using those keys will enable you to create automation to deploy and publish packages for example. You will need to create an API key for NuGet and GitHub.

Go to [Nuget.org](https://www.nuget.org) and sign in. Then jump to the [API keys page](https://www.nuget.org/account/apikeys) and create a new API key. Copy it to your clipboard (I recommend you to store it somewhere safe afterward like in a password manager).

> [!IMPORTANT]
> Set your API key as a secret of your repository on GitHub and name it `NUGET_API_KEY`. Paste your API key in the value field.

To create a GitHub personal API key, go to [this page](https://github.com/settings/tokens) and create a classic token. You will need to check the "write:packages" scope. Copy it to your clipboard (I recommend you to store it somewhere safe afterward like in a password manager).

### Automation

Now we will set up a github action to automate the process of publishing your package.

Create two folders in the root of your project: `.github` then `workflows` inside.

Create a new file in the `.github/workflows` folder and name it `publish.yml`.

```yml
name: Publish (Github & NuGet)

on:
  push:
    tags:
      - 'v[0-9]+.[0-9]+.[0-9]+'

jobs:
  build:
    runs-on: ubuntu-latest
    timeout-minutes: 15
    steps:
      - name: Checkout
        uses: actions/checkout@v2
        with:
          fetch-depth: 0
      - name: Verify commit exists in origin/main
        run: git branch --remote --contains | grep origin/main
      - name: Extract release notes
        run: |
          git log --pretty=format:'%d %s' ${GITHUB_REF} | perl -pe 's| \(.*tag: v(\d+.\d+.\d+(-preview\d{3})?)(, .*?)*\)|\n## \1\n|g' > RELEASE-NOTES
      - name: Set VERSION variable from tag
        run: echo "VERSION=${GITHUB_REF/refs\/tags\/v/}" >> $GITHUB_ENV
      - name: Build
        run: dotnet build --configuration Release /p:ContinuousIntegrationBuild=true /p:Version=${VERSION}
      - name: Pack
        run: dotnet pack <your_path_from_your_project_file> --configuration Release /p:ContinuousIntegrationBuild=true /p:Version=${VERSION} --no-build --output .
      - name: Push to GitHub Packages
        run: dotnet nuget push <name_of_your_app>.${VERSION}.nupkg --source https://nuget.pkg.github.com/<nuget_username>/index.json --api-key ${GITHUB_TOKEN}
        env:
          GITHUB_TOKEN: ${{ secrets.GITHUB_TOKEN }}
      - name: Push to NuGet.org
        run: dotnet nuget push "*.nupkg" --api-key ${{secrets.NUGET_API_KEY}} --source https://api.nuget.org/v3/index.json
```

> [!IMPORTANT]
> Check that you updated:
>
> - `<your_path_from_your_project_file.csproj>` by the path to your `.csproj` file
> - `<name_of_your_app>` by the name of your app
> - `<nuget_username>` by your NuGet username (on the same line as the `dotnet nuget push` command)

Then, commit your changes and push them to your repository.

Finally, create a new release and add a tag to it as follow "vX.X.X" where X is a number representing the version of your package. [Learn more](https://docs.github.com/en/repositories/releasing-projects-on-github/managing-releases-in-a-repository)

> [!TIP]
> Wait a few minutes and you will find your package on NuGet.org and GitHub packages, you will be notified by email.

### Clean up

If that project was indeed for you for demo purposes, you cannot delete it from NuGet.org, but you can hide it by unlisting it: Go to Manage Packages > select the package > click on the Edit button > Listing category > unchecked the "List in search results" checkbox > Save.

## Resources

- [Official NuGet documentation](https://learn.microsoft.com/nuget/quickstart/create-and-publish-a-package-using-the-dotnet-cli)
- [Main Source](https://acraven.medium.com/a-nuget-package-workflow-using-github-actions-7da8c6557863)
- [Recap](https://levelup.gitconnected.com/publish-to-nuget-with-github-actions-4e1486e7c19f)
- [Deterministic Builds](https://github.com/clairernovotny/DeterministicBuilds)
