# Microsoft eShopOnWeb Formatting Demo with Husky.Net and CSharpier

This repository was forked from the [eShopOnWeb](https://github.com/NimblePros/eShopOnWeb) repository to demonstrate [Husky.Net](https://alirezanet.github.io/Husky.Net/) and [CSharpier](https://csharpier.com/).

CSharpier has a completely optional [extension for Visual Studio](https://marketplace.visualstudio.com/items?itemName=csharpier.CSharpier).

## Quickstart Demo
For this demo, we edited the [CustomerOrdersSpecification.cs](./src/ApplicationCore/Specifications/CustomerOrdersSpecification.cs) file in the `ApplicationCore.csproj` to have inconsistent formatting.

1. Run the following command to restore the solution, this will automatically install Husky.

	```bash
     cd <project-root>
	dotnet restore eShopOnWeb.sln
	```
2. Now, add a comment to the [CustomerOrdersSpecification.cs](./src/ApplicationCore/Specifications/CustomerOrdersSpecification.cs) file. 
3. Commit the changes, you will see CSharpier will have formatted the file.

## Installing Husky.Net and CSharpier in your own project
1. Create a .NET tool manifest if you don't have one already. This will allow your team members to run `dotnet tool restore` to easily install the tools added to the manifest.
	```bash
	dotnet new tool-manifest
	```
2. Install the tools and add them to the manifest.
	```bash
	dotnet tool install Husky.Net --version 0.8.0 --add-source https://api.nuget.org/v3/index.json
	dotnet tool install CSharpier --version 1.2.5 --add-source https://api.nuget.org/v3/index.json
	```
3. Initialize Husky in your repository. This will add a `.husky` folder to the root of your repository.
	```bash
	dotnet husky install
	``` 
4. Modify the file at `.husky/task-runner.json` to include the commands you want to execute. 
   
   The below configuration will execute `dotnet csharpier format` on all staged files matching the 'include' glob pattern.
 	```json
	{
		"tasks": [{
			"name": "Run csharpier",
			"command": "dotnet",
			"args": [ "csharpier", "format", "${staged}" ],
			"include": [
				"**/*.cs",
				"**/*.csx",
				"**/*.csproj",
				"**/*.props",
				"**/*.targets",
				"**/*.xml",
				"**/*.config"
			]
		}]
	}
	```
5. Optionally add an MSBuild target to your projects. Restoring the project will then automatically restore all tools in your manifest and initialize Husky. 
	```bash
    dotnet husky attach <path-to-csproj-file>
    ```
6. Add a pre-commit hook to your repository. This will ensure that the tasks defined in the `task-runner.json` file are executed before each commit.
	```bash
	dotnet husky add pre-commit -c "dotnet husky run"
	``` 