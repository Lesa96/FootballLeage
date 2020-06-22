ALTER TABLE Sudija
    ADD CONSTRAINT sudija_liga_fk FOREIGN KEY ( liga_id_lige )
        REFERENCES Liga ( id_lige )