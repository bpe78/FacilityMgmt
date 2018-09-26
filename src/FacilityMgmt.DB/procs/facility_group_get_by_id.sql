CREATE PROCEDURE [dbo].[facility_group_get_by_id]
    @id int
AS
BEGIN
    SELECT
        [id],
        [name]
    FROM [dbo].[facility_group]
    WHERE [id] = @id
END