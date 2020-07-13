USE MyLibrary
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetGivenBooks
AS
BEGIN 
SELECT * FROM GivenBook
END
GO

CREATE PROCEDURE AddGivenBook
@BookID INT, @VisitorID INT, @GivenDate DATE, @ReturnDate DATE
AS
BEGIN
INSERT INTO GivenBook(BookID, VisitorID, GivenDate, ReturnDate)
VALUES 
(@BookID, @VisitorID, @GivenDate, @ReturnDate)
END
GO


CREATE PROCEDURE RemoveGivenBook
@GiveID INT
AS
BEGIN
DELETE FROM GivenBook WHERE GiveID = @GiveID  
END
GO