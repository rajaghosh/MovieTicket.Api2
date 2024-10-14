How to run for migration:
1. To create the migration file
-> Open the Package Manager Console
-> Check for the file listing using "dir" command. By default it will be the root.
-> We need to select the "MovieTicket.DBHelper" project. Use "cd MovieTicket.DBHelper" to get to the DB project folder.
-> Now we can run our migration command:

	COMMAND: dotnet ef migrations add InitialCreate

	This will create a migration folder with migration file
	Now to sync with DB we need to run another command

	COMMAND: dotnet ef database update --context MovieTicketDbContext
-> No again if we have DB object related changes we can again the migration using the command:
	
	COMMAND: dotnet ef migrations add <MigrationFileName>
	
	and then to sync we use the same command

	COMMAND: dotnet ef database update --context MovieTicketDbContext

---------------------------------------------------------
SQL QUERY 

USE <MovieTicket DB>
GO

SELECT * FROM [dbo].[Booking]
SELECT * FROM [dbo].[MovieListing]
SELECT * FROM [dbo].[MovieMaster]
SELECT * FROM [dbo].[TheatreMaster]
SELECT * FROM [dbo].[TheatreScreen]
SELECT * FROM [dbo].[UserMaster]