#!/bin/bash

echo "\n --- Building project --- \n"
dotnet build -c Release --verbosity quiet

echo "\n --- Generating Tests --- \n"
coverlet tests/bin/Release/net8.0/tests.dll --target dotnet --targetargs "test -c Release --no-build --verbosity minimal" --format opencover --exclude-by-attribute Visual

echo "\n --- Generating Coverage report --- \n"
reportgenerator "-reports:./coverage.opencover.xml" "-targetdir:coverage" "-reporttypes:lcov"
