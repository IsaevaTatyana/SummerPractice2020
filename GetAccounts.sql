USE MyLibrary
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetAccounts
AS
BEGIN 
SELECT * FROM Account
END
GO

CREATE PROCEDURE AddAccount
@Login_ VARCHAR(200), @Password_ VARCHAR(200)
AS
BEGIN
INSERT INTO Account(Login_, Password_)
VALUES 
(@Login_, @Password_)
END
GO


CREATE PROCEDURE RemoveAccount
@AccountID INT
AS
BEGIN
DELETE FROM  Account WHERE AccountID = @AccountID  
END
GO

/*DROP PROCEDURE Search*/

CREATE PROCEDURE Search
@Login_ VARCHAR(200), @Password_ VARCHAR(200)
AS
BEGIN
SELECT * FROM Account WHERE Login_ = @Login_ AND  Password_ = @Password_
END
GO