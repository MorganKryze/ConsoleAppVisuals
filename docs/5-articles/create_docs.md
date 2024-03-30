---
title: Create your project documentation
author: Yann M. Vidamment (MorganKryze)
description: This article will guide you through the process of creating a documentation for your C# project using the tool DocFX. Documentation is key to help user understand how to use the tools you create. It is also a good way to show the quality of your work.
keywords: c#, docfx, documentation, project, publish, github pages
ms.author: Yann M. Vidamment (MorganKryze)
ms.date: 03/28/2024
ms.topic: article
ms.service: ConsoleAppVisuals
---

<!--  TODO : add: https://learn.microsoft.com/en-us/contribute/content/metadata -->

# Create your project documentation

## Introduction

This article will guide you through the process of creating a documentation for your C# project using the tool [DocFX](https://dotnet.github.io/docfx/). Documentation is key to help user understand how to use the tools you create. It is also a good way to show the quality of your work.

## Prerequisites

- Having looked at the project from the [Introduction section](https://morgankryze.github.io/ConsoleAppVisuals/1-introduction/first_app.html)
- [.NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0) or later

## Install DocFX

Ensure that you have dotnet (C#) installed by running:

```bash
dotnet --version
```

To install docfx, or update it, open any terminal and run the following command:

```bash
dotnet tool update -g docfx
```

## Setup workspace

As we are taking back the `Introduction project` to set the example, here is the file structure before generating the documentation:

```bash
Example_project  <-- root
└───MyApp
    ├───bin
    ├───MyApp.csproj
    └───Program.cs
```

Open a terminal to the root of the project(the end of your path should be `Example_project/`), and run the following command:

```bash
docfx init -y -o  documentation
```

Now you should have a new folder called "documentation" in the root of your project. Your folder structure should look like this (files are specified with the dots):

```bash
Example_project  <-- root
├───documentation
│   ├───docs
│   │   ├───getting-started.md
│   │   ├───introduction.md
│   │   └───toc.yml
│   ├───docfx.json
│   ├───index.md
│   └───toc.yml
└───MyApp
    ├───bin
    ├───MyApp.csproj
    └───Program.cs
```

Here should be the default content of `docfx.json`:

```json
{
  "metadata": [
    {
      "src": [
        {
          "src": "../src",
          "files": ["**/*.csproj"]
        }
      ],
      "dest": "api"
    }
  ],
  "build": {
    "content": [
      {
        "files": ["**/*.{md,yml}"],
        "exclude": ["_site/**"]
      }
    ],
    "resource": [
      {
        "files": ["img/**"]
      }
    ],
    "output": "_site",
    "template": ["default", "modern"],
    "globalMetadata": {
      "_appName": "",
      "_appTitle": "",
      "_enableSearch": true,
      "pdf": true
    }
  }
}
```

For a more convenient display, features and to target to the project, I recommend you to update the file to the version below. For more information, see the [official documentation](https://dotnet.github.io/docfx/reference/docfx-json-reference.html) of the references tags.

```json
{
  "metadata": [
    {
      "src": [
        {
          "src": "../MyApp",
          "files": ["**/*.csproj"]
        }
      ],
      "dest": "api"
    }
  ],
  "build": {
    "content": [
      {
        "files": ["**/*.{md,yml}"],
        "exclude": ["_site/**"]
      }
    ],
    "output": "_site",
    "resource": ["assets/**"],
    "template": ["default", "modern"],
    "keepFileLink": false,
    "disableGitFeatures": false,
    "globalMetadata": {
      "_appName": "MyApp",
      "_appTitle": "MyApp",
      "_appFooter": "Copyright (C) 2024  Your Name",
      "_enableSearch": true,
      "_disableContribution": true,
      "pdf": true
    }
  }
}
```

> [!NOTE]
> You may want to select the channel of the documentation you want to generate. For example, if you want to generate the documentation for the Debug or Release version only. Feel free to update `files` to Debug or Release and `TargetFramework` to your dotnet version(available in the `MyApp.csproj`).

```json
...
"metadata": [
    {
      "src": [
        {
          "src": "../MyApp",
          "files": ["**/bin/Debug/**.dll"]
        }
      ],
      "dest": "api",
        "properties": {
          "TargetFramework": "net8.0"
        }
    }
  ],
...
```

Do not forget to update your compiled files using the `dotnet build` command:

# [Debug](#tab/debug)

```bash
dotnet build -c Debug
```

# [Release](#tab/release)

```bash
dotnet build -c Release
```

---

## Preview your doc

Now, back on your terminal from the root, run the following command:

```bash
docfx build documentation/docfx.json --serve
```

The output should end like this:

```bash
...
Serving ".../MyApp/documentation/_site" on http://localhost:8080. Press Ctrl+C to shut down.
```

Your documentation is now available on <http://localhost:8080> if you want to see the preview on localhost.

## Customize your doc

### Add sections

By default, the only sections available are `Docs` and `Api Documentation`. You may want to add more sections to your documentation. To do so, you will have to do fe steps:

1. Add a new folder in the `documentation` folder. For example, `articles`.
2. Inside `articles`, add a `index.md` file and a `toc.yml` file.

Here is an example of the `index.md` file:

```markdown
# Articles

This is the articles section. You can add articles to explain how to use your library.
```

Here is an example of the `toc.yml` file:

```yml
items:
  - name: Articles
    href: index.md
```

> [!NOTE]
> We added the `items` tag to the `toc.yml` file. This is the root of the table of contents and will remove the error `Incorrect Type. Expected "TOC"`.

3. Now, we need to update the `toc.yml` file in the `documentation` folder to add the new section. I recommend adding a homepage mention (will be the landing page when the section is clicked). Here is an example of the `toc.yml` file:

```yml
items:
  - name: Docs
    href: docs/
  - name: API
    href: api/
  - name: Articles
    href: articles/
    homepage: articles/index.md
```

### Add pages

Now that you know how to create new sections, to add pages you may just add markdown files to the sections folder, and add them to the `toc.yml` file. Here is an example of the `toc.yml` file:

```yml
items:
  - name: Getting Started
    href: index.md
  - name: How to use the library
    href: how_to_use.md
  - name: How to publish your work
    href: how_to_publish.md
```

However you may also be able to create collapsible menu in the `toc.yml` file. Here is an example of the `toc.yml` file:

```yml
items:
  - name: Getting Started
    href: index.md
  - name: Advanced
    items:
      - name: How to use the library
        href: how_to_use.md
      - name: How to publish your work
        href: how_to_publish.md
```

Or use another style and display the category name, and the pages without being collapsible:

```yml
items:
  - name: Getting Started
    href: index.md
  - name: Other pages
    href: how_to_use.md
    href: how_to_publish.md
```

### Markdown features support

DocFX supports a lot of markdown features. All of them are listed in the [official documentation](https://dotnet.github.io/docfx/spec/docfx_flavored_markdown.html).

### Logo & favicon

To add a logo or favicon to your documentation, start by adding them into the assets folder (if you have not, create it in the `documentation` folder). Then, update the `docfx.json` file to add the `logo` and `favicon` tags. Here is an example:

```json
...
"build": {
    ...
    "resource": ["assets/**"],
    "globalMetadata": {
      ...
      "_appLogoPath": "assets/logo.jpg",
      "_appFaviconPath": "assets/favicon.ico",
      ...
    }
    ...
  }
```

For both I recommend you using svg files so that the logo and favicon are scalable and will not lose quality.

### Code documentation

Coding in C#, you may be aware of the use of the `///` comments to document your code. This is a good practice to help other developers understand your code. DocFX will take these comments into account to generate accurate documentation. Please refer to the [official documentation](https://docs.microsoft.com/dotnet/csharp/programming-guide/xmldoc/xml-documentation-comments) for more information.

For docfx to support these metadata, ensure that a documentation file is generated correctly. Add this line to your "\*\*.csproj" file, inside the "PropertyGroup" tag:

```xml
<GenerateDocumentationFile>true</GenerateDocumentationFile>
```

Here is a little troubleshooting if you have an error while building the documentation:

- Check the version of your dotnet.
- Update docfx.
- Check the `docfx.json` path to your project (e.g. `../MyApp`).
- Check if you have well put a `namespace` in your file.
- Your `program.cs` will not be used in the documentation, so you will need to have at least on more class. Here is a quick example to copy/paste in a new file:

```csharp
namespace MyApp;

/// <summary>
/// Class <c>Point</c> models a point in a two-dimensional plane.
/// </summary>
public class Point
{
    private int x;
    private int y;

    /// <summary>
    /// Initializes a new instance of the <c>Point</c> class.
    /// </summary>
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    /// <summary>
    /// Gets the x-coordinate of the point.
    /// </summary>
    public int X
    {
        get { return x; }
    }

    /// <summary>
    /// Gets the y-coordinate of the point.
    /// </summary>
    public int Y
    {
        get { return y; }
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    public override string ToString()
    {
        return $"({x}, {y})";
    }
}
```

Now your documentation is ready to be generated in the section `API` in the generated site (you may change all sections names in your `toc.yml` file at the root of your documentation folder).

## Deploy the doc

### GitHub Pages

GitHub provides a service called GitHub Pages that allows you to host static websites directly from your repository. We will need to setup few things before deploying the documentation.

First of all, go to your repository settings, then to the "Pages" section. Select "Deploy from branch", then select the branch "gh-pages" branch and the root folder. Then click on "Save". If you do not have a "gh-pages" branch, you will have to create one (it is better if it is empty at the beginning but it is not mandatory).

### Deployment

Then, you will have to create a new folder called `.github` at the root of your project. Inside this folder, create a new folder called `workflows`. Inside this folder, create a new file called `deploy_docs.yml`. This file will contain the workflow to generate and deploy the documentation on GitHub Pages.

Here is an example of the `deploy_docs.yml` file:

```yml
name: Deploy docs
on:
  push:
    branches:
      - main
jobs:
  publish-docs:
    runs-on: ubuntu-latest
    steps:
      - name: Checkout
        uses: actions/checkout@v3
      - name: Dotnet Setup
        uses: actions/setup-dotnet@v3
        with:
          dotnet-version: 8.x

      - run: dotnet tool update -g docfx
      - run: docfx documentation/docfx.json

      - name: Deploy
        uses: peaceiris/actions-gh-pages@v3
        with:
          github_token: ${{ secrets.GITHUB_TOKEN }}
          publish_dir: docs/_site
```

Push the changes and go to the "Actions" section of your repository. You should see a new workflow called "Deploy docs". Click on it to see the logs. If everything went well, you should see a "Deployed" message at the end of the logs.

Now, on every push on the main branch, the documentation will be generated and deployed on GitHub Pages.

> [!NOTE]
> In your github repository description, click on "Edit" then for the url select the "GitHub Pages" url option. So that your documentation is directly accessible from your repository.

## Sources

- [DocFX documentation](https://dotnet.github.io/docfx/index.html)
- [Useful but not official documentation](https://tehgm.net/blog/docfx-github-actions/)
- [C# documentation comments](https://docs.microsoft.com/dotnet/csharp/programming-guide/xmldoc/xml-documentation-comments)
- [DocFX markdown support](https://dotnet.github.io/docfx/spec/docfx_flavored_markdown.html)

---

Have a question, give a feedback or found a bug? Feel free to [open an issue](https://github.com/MorganKryze/ConsoleAppVisuals/issues) or [start a discussion](https://github.com/MorganKryze/ConsoleAppVisuals/discussions) on the GitHub repository.
