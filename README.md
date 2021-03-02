# Art Portable API
## Get started
### Prerequisites
* dotnet core SDK 3.1

### Run the application
* Clone the repository:  
`git clone https://github.com/boulder/artportable-backend.git`
* Run `dotnet run` in the root of the repo
* Go to [localhost:5001/swagger](https://localhost:5001/swagger) to see the Swagger

## Development
The API is written in ASP.NET Core 3.1 (latest LTS). It's a RESTful API supporting the ArtPortable WebApp.
### Database
A MySQL database is hosted in AWS RDS. The database is accessed and modified using a code-first approach through EF Core 5 (Entity Framework).

## Links
* [Frontend repo]("https://github.com/boulder/artportable-web")
