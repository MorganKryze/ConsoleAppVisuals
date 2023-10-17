# Generating a documentation for a C# project

## The tool

The tool used to generate the documentation is [DocFX](https://dotnet.github.io/docfx/).

To install it, or update it,open any terminal and run the following command:

```bash
dotnet tool install -g docfx
```

## The structure

Here is the folder structure of the project before generating the documentation:

```bash
ConsoleAppVisuals  <-- root
├───.github
│   └───workflows
├───ConsoleAppVisuals
│   └───bin
│       ├───Debug
│       └───Release   
└───example
```

Open a terminal to the root of the project, and run the following command:

```bash
docfx init -q
```

Now you should have a new folder called "docfx_project" in the root of your project. Your folder structure should look like this (files are speficied with the dots):


```bash
ConsoleAppVisuals  <-- root
├───.github
│   └───workflows
├───ConsoleAppVisuals
│   └───bin
│       ├───Debug
│       └───Release
├───docfx_project
│   ├───api
│   ├───apidoc
│   ├───articles
│   ├───images
│   ├───src
│   ├..─.gitignore
│   ├..─docfx.json
│   ├..─index.md
│   └..─toc.yml
└───example
```
Open the file "docfx.json" and modify the following lines:

```json
"metadata": [
    {
      "src": [
        {
          "files": [
            "bin/**/*.dll"
          ]
        }
      ],
      "dest": "api",
      "outputFormat": "mref",
      "includePrivateMembers": false,
      "disableGitFeatures": false,
      "disableDefaultFilter": false,
      "noRestore": false,
      "namespaceLayout": "flattened",
      "memberLayout": "samePage",
      "EnumSortOrder": "alphabetic",
      "allowCompilationErrors": false
    }
  ],
```

To look like this:

```json
"metadata": [{
    "src": [{
      "files": ["**/bin/Release/**.dll"],
      "src": "../"
    }],
    "dest": "api",
    "properties": {
      "TargetFramework": "net7.0"
    }
  }],
```

## Preview your doc

Now, back on your terminal from the root, run the following command:

```bash
docfx docfx_project/docfx.json --serve
```

You should see something like this:

```bash
...
Serving ".../ConsoleAppVisuals/docfx_project/_site" on http://localhost:8080. Press Ctrl+C to shut down.
```
Your documentation is now available on http://localhost:8080 if you want to see the preview.

## Customize your doc

To ensure that the documentation is generated correctly (your /// comments are taken in account), check if this line is present in your "**.csproj" file, inside the "PropertyGroup" tag:

```xml
<GenerateDocumentationFile>true</GenerateDocumentationFile>
```

Now your documentation is ready to be generated in the section "Api Documentation" in the generated site.

For more customization, you may want update the "index.md" file in the "docfx_project" folder, and create wonderful articles in the "articles" folder to explain how to use your library.

## Deploy the doc

Finally, you can host your static site on GitHub Pages by adding a workflow in the ".github/workflows" folder like this one:

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
        dotnet-version: 7.x

    - run: dotnet tool update -g docfx
    - run: docfx docfx_project/docfx.json

    - name: Deploy
      uses: peaceiris/actions-gh-pages@v3
      with:
        github_token: ${{ secrets.GITHUB_TOKEN }}
        publish_dir: docs/_site
```

Now, on every push on the main branch, the documentation will be generated and deployed on GitHub Pages.

I recommend that you copy/paste the url into the home page of your repository on GitHub.com in order to display the documentation to your users.

## Sources

- [DocFX doc](https://dotnet.github.io/docfx/index.html)