-- =============================================
CREATE TRIGGER TrgLogNewIncident ON  Incidents
FOR INSERT
AS  
begin
    
    INSERT INTO Logs (DateTime, Text)
	VALUES (GETDATE(), 'Something bad happened...')
end