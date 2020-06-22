ALTER TABLE Zaposljava
    ADD CONSTRAINT zaposljava_obezbedjenje_fk FOREIGN KEY ( obezbedjenje_id_radnika )
        REFERENCES Obezbedjenje ( id_radnika )