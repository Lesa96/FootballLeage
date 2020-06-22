ALTER TABLE Igrac
    ADD CONSTRAINT igrac_klub_fk FOREIGN KEY ( naziv_kluba )
        REFERENCES Klub ( naziv )