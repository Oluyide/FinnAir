# FinnAir

1. The Pre-assignment was done using Asp.net Core C# and it makes use of Postgres SQL as the database.

2. A multilayered Achitecture was used (the project contains 4 projects which are the FinnAir.Api, FinnAir.BusinessLogic,FinAir.DataAccessLayer and the FinnAir.Test).

3. In the FinAir.Api project  there is need to change username and password for the database connection-strings in the appsettings.json and appsettings.development.json to suit yours.

4. The Api documentation was done using Swagger. On the launch of the project the swagger page is expected to load.

5. There will also be need to run this command for the database initialization, which is "update-database -verbose".

6. However the APIs are secured using the JWT bearer AuthenticationScheme.

7. Logging was also implemented to monitor the status of the Endpoints and the general health of the app.
