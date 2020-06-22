CREATE PROCEDURE [dbo].[GetFreeTrenerProcedura]
	
AS
BEGIN
  	SELECT ime_trenera 
	FROM Trener JOIN Vodi ON Trener.id_trenera != Vodi.trener_id_trenera
	ORDER BY Trener.ime_trenera
END

