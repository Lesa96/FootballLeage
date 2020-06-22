ALTER TABLE Pripada
    ADD CONSTRAINT pripada_klub_fk FOREIGN KEY ( klub_naziv )
        REFERENCES Klub ( naziv )