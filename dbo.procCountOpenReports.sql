CREATE PROCEDURE [dbo].[procCountOpenReports]
AS
	SELECT COUNT(*) FROM Reports

RETURN