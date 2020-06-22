CREATE FUNCTION [dbo].[Prosek]
(
	@param1 float,
	@param2 float
)
RETURNS FLOAT
AS
BEGIN
	RETURN @param1 / @param2
END
