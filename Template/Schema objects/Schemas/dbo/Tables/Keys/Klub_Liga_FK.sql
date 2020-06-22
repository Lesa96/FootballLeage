ALTER TABLE Klub
    ADD CONSTRAINT klub_liga_fk FOREIGN KEY ( liga_id_lige )
        REFERENCES Liga ( id_lige )