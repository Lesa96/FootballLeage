ALTER TABLE Sponzorise
    ADD CONSTRAINT sponzorise_liga_fk FOREIGN KEY ( liga_id_lige )
        REFERENCES Liga ( id_lige )