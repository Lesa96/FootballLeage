CREATE TRIGGER [MyTrigger]
	ON [dbo].[Klub]
	AFTER  INSERT
	
	AS	
	BEGIN
		DECLARE @ID_lige int
		SELECT @ID_lige = liga_id_lige  FROM inserted

		UPDATE Liga  
		SET broj_klubova = broj_klubova + 1 
		WHERE Liga.id_lige = @ID_lige
	END
