ALTER TABLE Poseduje
    ADD CONSTRAINT poseduje_klub_fk FOREIGN KEY ( klub_naziv )
        REFERENCES Klub ( naziv )