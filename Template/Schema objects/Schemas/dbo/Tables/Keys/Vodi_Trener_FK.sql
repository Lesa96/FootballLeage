ALTER TABLE Vodi
    ADD CONSTRAINT vodi_trener_fk FOREIGN KEY ( trener_id_trenera )
        REFERENCES Trener ( id_trenera )