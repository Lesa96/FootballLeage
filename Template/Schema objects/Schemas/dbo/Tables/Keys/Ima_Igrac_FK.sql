ALTER TABLE Ima
    ADD CONSTRAINT ima_igrac_fk FOREIGN KEY ( igrac_id_igraca )
        REFERENCES Igrac ( id_igraca )