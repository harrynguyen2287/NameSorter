# Name Sorter

## Project Structure

- src
  - NameSorter.ConsoleApp: The console app project.
    - Program.cs: The main entry of the project.
    - App.cs: Acts as an controller to receive the arguments and call the corresponding service.
  - NameSorter.Core: The Core project where all logics will be here.
    - Common: Contains all of common things likes: constants, enums,...
    - DependencyInjections: Register dependencies for the project
    - Services:
      - Interfaces: Define public service interfaces to be used in the console app.
      - Implementation: Implement methods of above interfaces.
- test
  - NameSorter.ConsoleApp.UnitTest: Unit Test for the ConsoleApp project
  - NameSorter.Core.UnitTest: Unit Test for the Core project

## Prerequisite

- Visual Studio Code: https://code.visualstudio.com/download
- .net 8 sdk:https://dotnet.microsoft.com/en-us/download
- PowerShell

## Run project

- Open PowerShell
- Go to the project root folder
- Run the below commnad:

      dotnet run --project .\src\NameSorter.ConsoleApp\NameSorter.ConsoleApp.csproj .\unsorted-names-list.txt

## Pack and Run Project Globally

- Open PowerShell
- Go to the project root folder
- Run the below commnads:

      dotnet pack .\src\NameSorter.ConsoleApp\
      dotnet tool install --global --add-source .\src\NameSorter.ConsoleApp\nupkg\ name-sorter

- Now you can run the app with this command:

      name-sorter .\unsorted-names-list.txt

## Run unit test

### Test the Core project

- Open PowerShell
- Go to the project root folder
- Go to the Core project folder:

      cd .\test\NameSorter.Core.UnitTest

- Run the below command:

      dotnet test

### Test the ConsoleApp project

- Open PowerShell
- Go to the project root folder
- Go to the ConsoleApp project folder:

      cd .\test\NameSorter.ConsoleApp.UnitTest

- Run the below command:

      dotnet test
