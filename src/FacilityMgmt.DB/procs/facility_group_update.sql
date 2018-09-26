CREATE PROCEDURE [dbo].[facility_group_update]
    @id INT,
    @name NVARCHAR(25)
AS
BEGIN
    UPDATE [dbo].[facility_group]
    SET
        [name] = @name,
        [dtb000] = CURRENT_TIMESTAMP
    WHERE [id] = @id;
END
