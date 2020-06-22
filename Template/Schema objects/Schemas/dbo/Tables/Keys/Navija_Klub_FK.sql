ALTER TABLE Navija
    ADD CONSTRAINT navija_klub_fk FOREIGN KEY ( klub_naziv )
        REFERENCES Klub ( naziv );