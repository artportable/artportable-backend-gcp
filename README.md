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

#### Update database
The structure of the database can be changed using the EF Core CLI tools and migrations.
* Edit models and contexts in the Entities folder
* Add migration  
`dotnet ef migrations add <NAME>`
* Apply the changes  
`dotnet ef database update`.
* OR retrieve a SQL query and execute it manually  
`dotnet ef migrations script`

More about this can be found in [the EF Core documentation](https://docs.microsoft.com/en-us/ef/core/).

### Stripe
Stripe is used for handling card payments.

#### Webhooks
Webhooks are used for recieving feedback from Stripe, for example when a user paid their subscription.

Test events can be triggered with the Stripe CLI:
* Run `stripe listen --forward-to https://localhost:5001/api/stripe --skip-verify`
* Trigger events with `stripe trigger payment_intent.created`

## Links
* [Frontend repo]("https://github.com/boulder/artportable-web")