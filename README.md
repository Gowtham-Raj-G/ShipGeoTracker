# Introduction 
- The ShipGeoTracker solution is a RESTful API that helps you find the closest port to a given ship.
- Calculate the estimated arrival time based on the velocity and geolocation (longitude and latitude) of the ship.

# Stories
- As an API user, I should be able to:
	- Add new ships to the system.
	- View all ships in the system.
	- Update the velocity of a specific ship.
	- See the closest port to a ship with the estimated arrival time and relevant port details.

# Requirements
To use the ShipGeoTracker solution, you need to ensure that your environment meets the following requirements:
- C# programming language is required for this solution.
- A database is required to store the port and ship data. SQL Server is recommended.
- You must have the latest version of .NET 6.0 installed.

# Installation
- Clone the repository to your local machine.
- Update the connection string in the appsettings.json file to point to your database.
- Build the solution.
- Run the migrations to create the necessary tables in the database.

# Folder Structure
- ShipGeoTracker.Api
	- Controllers
	- Infrastructure
	- Services
		
- ShipGeoTracker.Database
	- Migration
	- Context

- ShipGeoTracker.Unittests
	
# Usage
- To use the ShipGeoTracker Solution, you can consume the following RESTful APIs:
	- /api/ships - GET, POST, PUT
	- /api/ships/{id}/closest-port - GET

# EndPoints
- Ships
	- GET /api/ships - Get a list of all ships in the system.
	- POST /api/ships - Add a new ship to the system.
	- PUT /api/ships/{id} - Update an existing ship's velocity.
	- GET /api/ships/{id}/closest-port - Get the details of the closest port to a given ship, including the estimated arrival time based on the velocity of the ship.	

# Future Enhancements
 - Enhance security by implementing authentication and authorization mechanisms for API endpoints.
 - Enable users to conveniently create and manage ports through the API.
 - Improve the accuracy of the estimated arrival time calculation by considering factors such as weather and traffic conditions.
 - Boost the quality of the codebase by adding additional unit and integration tests to improve code coverage.