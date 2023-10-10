# Build the project 

In your terminal, at "src/ConsoleAppVisuals" directory, run the following command:

```bash
dotnet build
```

You will then find the NuGet package in the "bin/Debug" folder of your project.

# Publish the project

If you want to edit the project and publish it, feel free to fork it and follow these steps.

## Create a NuGet account

You need to create a NuGet account [here](https://www.nuget.org/users/account/LogOn?returnUrl=%2F).

Preferably, use an outlook email address.

## Modify informations

Start by changing the information in the "src/ConsoleAppVisuals/ConsoleAppVisuals.csproj" file as you won't be able to push on my name obviously.

```xml
<PropertyGroup>
    <TargetFramework>net7.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
      <PackageId>ConsoleAppVisuals</PackageId> <!-- Change this by the name of your package, it must be unique -->
      <Authors>MorganK</Authors> <!-- Change this by the name of the publisher on nuget.org -->
      <Version>1.0.1</Version> <!-- Change this by the version of your package -->
      <Description>Visuals for console app</Description> <!-- Change this by the description of your package -->
      <PackageLicenceExpression>MIT</PackageLicenceExpression>
      <PackageTags>Visuals, ConsoleApp</PackageTags> <!-- Change this by the tags of your package -->
      <RepositoryUrl>https://github.com/MorganKryze/ConsoleAppVisuals</RepositoryUrl> <!-- Change this by the url of your repository on GitHub -->
      
    <GenerateDocumentationFile>true</GenerateDocumentationFile> <!-- This is optional, it will generate a .xml file with the documentation of your package if you put xml comments on your project -->
    <GeneratePackageOnBuild>true</GeneratePackageOnBuild> <!-- This is optional, it will generate a .nupkg file of your package when you build your project automatically without doing a dotnet pack -->
    <PackageReadmeFile>README.md</PackageReadmeFile> <!-- This is optional, it will add the README.md file of your project to the package -->
    <PackageLicenseFile>LICENSE</PackageLicenseFile> <!-- This is optional, it will add the LICENSE file of your project to the package -->
</PropertyGroup>

<ItemGroup>
    <None Include="..\..\README.md" Pack="true" PackagePath=""/>
    <None Include="..\..\LICENSE" Pack="true" PackagePath=""/>
</ItemGroup>

```

## Licence

You need to change the licence of the project by your own licence.

## Build the project

In your terminal, run the following command:

```bash
dotnet build
```

## Create an API key

Then, you need to create an API key [here](https://www.nuget.org/account/apikeys) and copy it to your clipboard.

## Publish your package

Back to your terminal and run the following command:

```bash

dotnet nuget push <Insert_the_name_of_your_package>.nupkg --api-key <Insert_your_api_key_just_copied> --source https://api.nuget.org/v3/index.json

```

FYI : remove the "<>" when you insert your package name and your api key.

Wait a few minutes and you will find your package on NuGet.org, you will be notified by email.





**ressources** : [Official documentation](https://learn.microsoft.com/nuget/quickstart/create-and-publish-a-package-using-the-dotnet-cli)