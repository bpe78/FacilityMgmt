CREATE PROCEDURE [dbo].[facility_group_get_all]
AS
BEGIN
    SELECT
        [id],
        [name]
    FROM [dbo].[facility_group]
    WHERE [dtc000] IS NULL
END
