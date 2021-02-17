# SourcefulTask

## Setup
Follow these steps to get your development environment set up:

  1. Clone the repository
  2. At the root directory, restore required packages by running:
      ```
     dotnet restore
     ```
  3. Next, build the solution by running:
     ```
     dotnet build
     ```
  4. Next, within the `\Src\WebUI\ClientApp` directory, launch the front end by running:
      ```
     npm start
     ```
  5. Once the front end has started, within the `\Src\WebUI` directory, launch the back end by running:
     ```
	 dotnet run
	 ```
 
  6. Launch [https://localhost:5001/api](http://localhost:5001/api) in your browser to view the API

## Technologies
* .NET Core 5
* Entity Framework Core 5
* Angular 8

