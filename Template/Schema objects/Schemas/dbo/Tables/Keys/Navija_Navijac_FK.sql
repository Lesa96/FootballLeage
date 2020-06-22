ALTER TABLE Navija
    ADD CONSTRAINT navija_navijac_fk FOREIGN KEY ( navijac_id_navijaca )
        REFERENCES Navijac ( id_navijaca );