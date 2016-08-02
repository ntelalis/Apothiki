CREATE TRIGGER insLocTrigger ON SXESI
FOR INSERT
AS
	DECLARE @Id Int;
	DECLARE @Location NVARCHAR(50);
	SELECT @Id=i.KoutiId from inserted i;
	SELECT @Location=Kouti.Location FROM Kouti WHERE Id=@Id;
	
	UPDATE Sxesi SET KoutiLocation=@Location WHERE KoutiId=@Id;