ALTER TABLE Igrac
    ADD CONSTRAINT igrac_vodi_fk FOREIGN KEY ( vodi_id_trenera,
                                               vodi_naziv )
        REFERENCES Vodi ( trener_id_trenera,
                          klub_naziv )