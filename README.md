
# Meter Reader API

A .NET Core API that accepts a CSV file to be uploaded, validated and stored in a SQL Server Database. Please find an example of the CSV at the root level (Meter_Reading.csv). 



## Run Locally

### Sql Server

To run this project locally you'll need to set up Sql Server and update the connection string in appSettings.Development.json.

Something like this:

`
"ConnectionStrings": {
    "Default": "server=localhost;database=MeterReadings;user id=sa;password=MySqlserverPassword123!"
},
  `

Once you have SQL Server up and running you'll need to create the following tables.

#### 1. MeterReadings

```
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeterReadings](
	[Id] [uniqueidentifier] NOT NULL,
	[AccountId] [int] NOT NULL,
	[Updated] [datetime] NOT NULL,
	[Value] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MeterReadings] ADD  CONSTRAINT [PK_MeterReadings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
```

#### 2. UserAccounts
```
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccounts](
	[Id] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserAccounts] ADD  CONSTRAINT [PK_UserAccounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
```

The following queries also need to run against the UserAccounts table to populate it. This is needed for validation purposes. 

```
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (2344,'Tommy','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (2233,'Barry','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (8766,'Sally','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (2345,'Jerry','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (2346,'Ollie','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (2347,'Tara','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (2348,'Tammy','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (2349,'Simon','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (2350,'Colin','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (2351,'Gladys','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (2352,'Greg','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (2353,'Tony','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (2355,'Arthur','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (2356,'Craig','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (6776,'Laura','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (4534,'JOSH','TEST')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (1234,'Freya','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (1239,'Noddy','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (1240,'Archie','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (1241,'Lara','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (1242,'Tim','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (1243,'Graham','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (1244,'Tony','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (1245,'Neville','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (1246,'Jo','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (1247,'Jim','Test')
INSERT INTO [MeterReadings].[dbo].[UserAccounts] (Id, FirstName, LastName) VALUES (1248,'Pam','Test')
```

### Web API

Once that's done, right click on Meter.Api and set as start project and select "Run" ✅



## Roadmap

- Error handling and logging to be improved. 
- Improving application resiliency.
- Improving GUI 


## Feedback

If you have any feedback, please reach out to me at hiba.eldursi.dev@gmail.com

