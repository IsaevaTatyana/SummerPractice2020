USE MyLibrary
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetBookings
AS
BEGIN 
SELECT * FROM Booking
END
GO

CREATE PROCEDURE AddBooking
@BookID INT, @VisitorID INT, @OrderDate DATE
AS
BEGIN
INSERT INTO Booking(BookID, VisitorID, OrderDate)
VALUES 
(@BookID, @VisitorID, @OrderDate)
END
GO


CREATE PROCEDURE RemoveBooking
@BookingID INT
AS
BEGIN
DELETE FROM Booking WHERE BookingID = @BookingID  
END
GO