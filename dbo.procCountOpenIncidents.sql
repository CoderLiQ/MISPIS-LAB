CREATE PROCEDURE [dbo].[procCountOpenIncidents]
AS
	SELECT COUNT(*) FROM Incidents

RETURN