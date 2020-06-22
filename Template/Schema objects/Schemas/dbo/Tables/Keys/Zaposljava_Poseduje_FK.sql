ALTER TABLE Zaposljava
    ADD CONSTRAINT zaposljava_poseduje_fk FOREIGN KEY ( poseduje_klub_naziv,
                                                        poseduje_stadion_id_stadiona )
        REFERENCES Poseduje ( klub_naziv,
                              stadion_id_stadiona )