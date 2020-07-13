USE MyLibrary
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetVisitor
AS
BEGIN 
SELECT * FROM Visitor
END
GO


CREATE PROCEDURE AddVisitor
@FirstName VARCHAR(200), @LastName VARCHAR(200),@MiddleName VARCHAR(200),@AccountID INT, @Phone VARCHAR(11), @Adress VARCHAR(200)
AS
BEGIN
INSERT INTO Visitor(FirstName, LastName, MiddleName, AccountID, Phone, Adress)
VALUES 
(@FirstName, @LastName, @MiddleName, @AccountID, @Phone, @Adress)
END
GO


CREATE PROCEDURE RemoveVisitor
@VisitorID INT
AS
BEGIN
DELETE FROM  Visitor WHERE VisitorID = @VisitorID  
END
GO