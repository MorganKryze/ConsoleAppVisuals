install:
	@echo "\n --- Verifying dotnet installation --- \n"
	dotnet --version

	@echo "\n --- Installing project dependdencies --- \n"
	dotnet restore

	dotnet tool restore

coverage:
	@echo "\n --- Building project --- \n"
	dotnet build -c Release --verbosity minimal

	@echo "\n --- Generating Tests --- \n"
	dotnet tool run coverlet tests/bin/Release/net9.0/tests.dll --target dotnet --targetargs "test -c Release --no-build --verbosity minimal" --format opencover --exclude-by-attribute Visual

	@echo "\n --- Generating Coverage report --- \n"
	dotnet tool run reportgenerator "-reports:./coverage.opencover.xml" "-targetdir:coverage" "-reporttypes:lcov"

docs:
	@echo "\n --- Building and hosting local website --- \n"
	dotnet tool run docfx docs/docfx.json --serve