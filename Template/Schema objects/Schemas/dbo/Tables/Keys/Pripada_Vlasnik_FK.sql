ALTER TABLE Pripada
    ADD CONSTRAINT pripada_vlasnik_fk FOREIGN KEY ( vlasnik_id_vlasnika )
        REFERENCES Vlasnik ( id_vlasnika )