# Things to remember
1. Make sure to configure and unechekcout the appsettings.development.json so switching between computers doesn't cause issues
2. When updating the database, there was an issue updating the database because a table already existed, should look into avoiding this. Maybe via a script?
3. Write down all the dependencies (internal projects not Nugets)
4. Should find a way to create a user with the necessary privileges when interacting with the database. However, the database doesn't matter. We just need the right user.
5. When deploying make sure to change the appsettings.json (or the launchSettings.json) environment to production when moved to the right environment.
6. !! Make sure to update the database and migrations before continuing