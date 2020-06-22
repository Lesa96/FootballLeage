CREATE TABLE [dbo].[Igrac]
(
	
	id_igraca			INTEGER NOT NULL,         
    ime_igraca        VARCHAR(20),
    prezime_igraca    VARCHAR(30),
    vodi_id_trenera  INTEGER ,
    vodi_naziv     VARCHAR(30) ,
	naziv_kluba		VARCHAR(30),
	odigranih_utakmica INTEGER,
	postignutih_golova INTEGER,
	godine_igraca INTEGER,
	prosek_golova FLOAT
)
