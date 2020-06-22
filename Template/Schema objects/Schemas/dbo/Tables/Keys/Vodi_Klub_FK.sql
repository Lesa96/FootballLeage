ALTER TABLE Vodi
    ADD CONSTRAINT vodi_klub_fk FOREIGN KEY ( klub_naziv )
        REFERENCES Klub ( naziv )