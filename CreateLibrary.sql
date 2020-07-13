/*C:\Users\vasil\OneDrive\Документы\SQL Server Management Studio*/
USE master;
GO 

IF EXISTS(SELECT * from sys.databases WHERE name ='MyLibrary')  
BEGIN  
    DROP DATABASE MyLibrary;  
END  


CREATE DATABASE MyLibrary
GO

USE MyLibrary
GO

CREATE TABLE Account
(AccountID INT IDENTITY(1,1) CONSTRAINT PK_AccountID not null PRIMARY KEY,
Login_ VARCHAR(200) not null,
Password_ VARCHAR(200) not null)
GO

CREATE TABLE Visitor
(VisitorID INT IDENTITY(1,1) CONSTRAINT PK_VisitorID not null PRIMARY KEY,
FirstName VARCHAR(200) not null,
LastName VARCHAR(200) not null,
MiddleName VARCHAR(200),
AccountID INT not null,
Phone VARCHAR(11) not null,
Adress VARCHAR(200) not null,
FOREIGN KEY (AccountID) REFERENCES Account(AccountID))
GO

CREATE TABLE Author
(AuthorID INT IDENTITY(1,1) CONSTRAINT PK_AuthorID not null PRIMARY KEY,
FirstName VARCHAR(200) not null,
LastName VARCHAR(200) not null,
MiddleName VARCHAR(200))
GO

/*CREATE TABLE City
(CityID INT IDENTITY(1,1) CONSTRAINT PK_CityID not null PRIMARY KEY,
NameOfCity VARCHAR(500) not null)
GO

CREATE TABLE Publisher
(PublisherID INT IDENTITY(1,1) CONSTRAINT PK_PublisherID not null PRIMARY KEY,
NameOfPublisher VARCHAR(200) not null,
CityID INT not null,
FOREIGN KEY (CityID) REFERENCES City(CityID))
GO*/

CREATE TABLE Book 
(BookID INT IDENTITY(1,1) CONSTRAINT PK_BookId not null PRIMARY KEY,
Names VARCHAR(200) not null, 
PublicYear INT not null,
Publisher VARCHAR(200) not null,
CountOfPages INT not null,
Price INT not null,
CountCopy INT not null,
StatusBook VARCHAR(200) not null)
/*FOREIGN KEY (PublisherID) REFERENCES Publisher(PublisherID)*/
GO

CREATE TABLE ConnectAuthorBook
(BookID INT not null,
AuthorID INT not null,
PRIMARY KEY (BookID, AuthorID),
FOREIGN KEY (AuthorID) REFERENCES Author(AuthorID),
FOREIGN KEY (BookID) REFERENCES Book(BookID))
GO

CREATE TABLE GivenBook
(GiveID INT IDENTITY(1,1) CONSTRAINT PK_GiveID  not null PRIMARY KEY,
BookID INT not null,
VisitorID INT not null,
GivenDate DATE not null,
ReturnDate DATE not null,
FOREIGN KEY (BookID) REFERENCES Book(BookID),
FOREIGN KEY (VisitorID) REFERENCES Visitor(VisitorID))
GO

CREATE TABLE Booking
(BookingID INT IDENTITY(1,1) CONSTRAINT PK_BookingID not null PRIMARY KEY,
BookID INT not null,
VisitorID INT not null,
OrderDate DATE not null,
FOREIGN KEY (BookId) REFERENCES Book(BookId),
FOREIGN KEY (VisitorID) REFERENCES Visitor(VisitorID))
GO  