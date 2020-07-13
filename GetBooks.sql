
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

USE MyLibrary
GO

CREATE PROCEDURE GetBooks
AS
BEGIN 
SELECT * FROM Book
END
GO

CREATE PROCEDURE AddBook
@Names VARCHAR(200), @PublicYear INT, @Publisher VARCHAR(200), @CountOfPages INT, @Price INT, @CountCopy INT, @StatusBook VARCHAR(200)
AS
BEGIN
INSERT INTO Book (Names, PublicYear, Publisher, CountOfPages, Price, CountCopy, StatusBook)
VALUES 
(@Names, @PublicYear, @Publisher, @CountOfPages, @Price, @CountCopy, @StatusBook)
END
GO

CREATE PROCEDURE RemoveBook
@BookID INT
AS
BEGIN
DELETE FROM  Book WHERE BookID = @BookID  
END
GO