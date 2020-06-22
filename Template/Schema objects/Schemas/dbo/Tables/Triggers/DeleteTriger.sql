CREATE TRIGGER [DeleteTriger]
	ON [dbo].[Klub]
	FOR  DELETE
	AS
	BEGIN
		DECLARE @ID_lige int
		SELECT @ID_lige = liga_id_lige  FROM deleted

		UPDATE Liga  
		SET broj_klubova = broj_klubova - 1 
		WHERE Liga.id_lige = @ID_lige
	END