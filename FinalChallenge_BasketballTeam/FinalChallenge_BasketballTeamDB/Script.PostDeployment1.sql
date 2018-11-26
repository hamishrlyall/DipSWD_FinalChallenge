/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF '$(LoadTestData)' = 'true'

BEGIN

SET IDENTITY_INSERT Manager ON

INSERT INTO Manager (managerID, [Name], Team) VALUES
(99, 'Hamish', 'Hawthorn Bobcats'),
(98, 'Jim', 'Auburn Crows'),
(97, 'Jam', 'Glenferrie Clubbers');


SET IDENTITY_INSERT Manager OFF
SET IDENTITY_INSERT Fixture ON

INSERT INTO Fixture (fixtureID, managerID, Team, teamManager, fixtureDateTime, Venue, Spent) VALUES
(99, 99, 'Hawthorn Bobcats', 'Hamish', '2018/11/23 09:00:00.000', 'Hawthorn Basketball Court', 200.00),
(98, 98, 'Auburn Crows','Jim', '2018/11/15 10:30:00.000', 'Auburn Primary School', 250.00),
(97, 97, 'Glenferrie Clubbers', 'Jam', '2018/11/10 11:30:00.000', 'Glenferrie Aquatic Centre', 300.00),
(96, 99, 'Hawthorn Bobcats', 'Hamish', '2018/12/10 09:00:00.000', 'Hawthorn Basketball Court', 200.00);

SET IDENTITY_INSERT Fixture OFF


--INSERT INTO Manager ([Name], Team, totalSpent)
--SELECT [Name], Team, totalSpent FROM MANAGER

--SET IDENTITY_INSERT Manager ON
UPDATE Manager 
SET totalSpent = (SELECT SUM(Spent) FROM Fixture WHERE Fixture.managerID = Manager.managerID)
FROM Manager
--SET IDENTITY_INSERT Manager OFF


END;