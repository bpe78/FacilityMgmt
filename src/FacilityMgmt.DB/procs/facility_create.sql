CREATE PROCEDURE [dbo].[facility_create]
    @name NVARCHAR(100), 
    @short_name NVARCHAR(20),
    @group_id INT,
    @access_token NVARCHAR(100),
    @geography NVARCHAR(4),
    @country NCHAR(3),
    @postal_code NVARCHAR(20),
    @tv_region_id INT,
    @tv_provider_id NVARCHAR(100),
    @tv_rovider_name NVARCHAR(100),
    @tv_provider_type NVARCHAR(10),
    @last_refresh DATETIME2(0)
AS
BEGIN
    DECLARE @insertedId table([id] UNIQUEIDENTIFIER);

    INSERT INTO [dbo].[facility] ([name], [short_name], [group_id], [access_token], [geography], [country], [postal_code], [tv_region_id], [tv_provider_id], [tv_rovider_name], [tv_provider_type], [last_refresh], [dta000])
    OUTPUT INSERTED.[id] INTO @insertedId
    VALUES (@name, @short_name, @group_id, @access_token, @geography, @country, @postal_code, @tv_region_id, @tv_provider_id, @tv_rovider_name, @tv_provider_type, NULL, CURRENT_TIMESTAMP);
        
    SELECT [id] FROM @insertedId;
END