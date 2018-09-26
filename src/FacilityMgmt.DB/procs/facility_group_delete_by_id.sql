CREATE PROCEDURE [dbo].[facility_group_delete_by_id]
    @id INT
AS
BEGIN
    UPDATE [dbo].[facility_group]
    SET
        [dtc000] = CURRENT_TIMESTAMP
    WHERE ([id] = @id) AND ([dtc000] IS NULL);
END
