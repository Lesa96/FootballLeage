ALTER TABLE Poseduje
    ADD CONSTRAINT poseduje_stadion_fk FOREIGN KEY ( stadion_id_stadiona )
        REFERENCES Stadion ( id_stadiona )