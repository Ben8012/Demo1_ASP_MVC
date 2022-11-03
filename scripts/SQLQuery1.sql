USE ASP_DEMO
GO
CREATE TABLE Contact (
    Id int PRIMARY KEY NOT NULL IDENTITY ,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255) NOT NULL,
    Email varchar(255) NOT NULL,
    SurName varchar(255),
    Phone varchar(255) NOT NULL,
    Birthdate DATETIME2,
);
GO 

INSERT INTO Contact(LastName,FirstName,Email,SurName,Phone,Birthdate)
VALUES (
	'Sterckx','Benjamin','ben@mail.com','ben','0465/123456', '1980-12-10'
);


DELETE FROM Contact WHERE Id in(2,3,4); 

SELECT * FROM Contact;
