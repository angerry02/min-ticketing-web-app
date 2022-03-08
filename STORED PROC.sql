CREATE PROC dbo.GetTickets
AS
BEGIN
	
	SELECT *
	FROM Ticket
	ORDER BY dateCreated
	
END


--------------------------------

ALTER PROC dbo.GetTicket
(
	@ticketNo BIGINT
)
AS
BEGIN
	
	SELECT *
	FROM Ticket
	WHERE ticketNo=@ticketNo
	
END

--------------------------------

CREATE PROC dbo.DeleteTicket
(
	@ticketNo BIGINT
)
AS
BEGIN
	
	DELETE FROM Ticket
	WHERE ticketNo=@ticketNo
	
END