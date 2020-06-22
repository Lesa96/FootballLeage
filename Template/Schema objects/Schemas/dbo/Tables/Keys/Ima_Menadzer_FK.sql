ALTER TABLE Ima
    ADD CONSTRAINT ima_menadzer_fk FOREIGN KEY ( menadzer_id_menagera )
        REFERENCES Menadzer ( id_menagera )