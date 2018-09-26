CREATE PROCEDURE [dbo].[facility_group_create]
    @name NVARCHAR(25)
AS
BEGIN
    INSERT INTO [dbo].[facility_group] ([name], [dta000])
    VALUES (@name, CURRENT_TIMESTAMP);

    SELECT SCOPE_IDENTITY();
END
