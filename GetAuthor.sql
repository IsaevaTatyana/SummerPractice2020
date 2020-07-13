USE MyLibrary
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetAuthors
AS
BEGIN 
SELECT * FROM Author
END
GO


CREATE PROCEDURE AddAuthor
@FirstName VARCHAR(200), @LastName VARCHAR(200),@MiddleName VARCHAR(200)
AS
BEGIN
INSERT INTO Author(FirstName, LastName, MiddleName)
VALUES 
(@FirstName, @LastName, @MiddleName)
END
GO


CREATE PROCEDURE RemoveAuthor
@AuthorID INT
AS
BEGIN
DELETE FROM  Author WHERE AuthorID = @AuthorID  
END
GO