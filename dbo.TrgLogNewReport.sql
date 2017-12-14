CREATE TRIGGER TrgLogNewReport ON  Reports
FOR INSERT
AS  
begin
    
    INSERT INTO Logs (DateTime, Text)
	VALUES (GETDATE(), 'Something good is about to happen...')
end