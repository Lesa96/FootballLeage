CREATE TRIGGER [UpdateTriger]
	ON [dbo].[Klub]
	FOR  UPDATE
	AS
	BEGIN
		DECLARE @ID_Prethodne_lige int
		DECLARE @ID_Nove_lige int
		SELECT @ID_Prethodne_lige = liga_id_lige  FROM deleted
		SELECT @ID_Nove_lige = liga_id_lige FROM inserted

		UPDATE Liga  
		SET broj_klubova = broj_klubova - 1 
		WHERE Liga.id_lige = @ID_Prethodne_lige

		UPDATE Liga  
		SET broj_klubova = broj_klubova + 1 
		WHERE Liga.id_lige = @ID_Nove_lige
	END