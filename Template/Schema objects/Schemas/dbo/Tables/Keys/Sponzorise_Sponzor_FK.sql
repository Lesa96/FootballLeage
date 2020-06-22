ALTER TABLE Sponzorise
    ADD CONSTRAINT sponzorise_sponzor_fk FOREIGN KEY ( sponzor_id_sponzora )
        REFERENCES Sponzor ( id_sponzora )