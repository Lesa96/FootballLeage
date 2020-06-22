ALTER TABLE transferistorija
    ADD CONSTRAINT transferistorija_igrac_fk FOREIGN KEY ( igrac_id_igraca )
        REFERENCES Igrac ( id_igraca );