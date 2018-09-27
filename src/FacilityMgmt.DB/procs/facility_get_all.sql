CREATE PROCEDURE [dbo].[facility_get_all]
    @group_id INT
AS
BEGIN
    SELECT [id]
          ,[name]
          ,[short_name]
          ,[group_id]
          ,[access_token]
          ,[geography]
          ,[country]
          ,[area_code]
          ,[tv_region_id]
          ,[tv_provider_id]
          ,[tv_provider_name]
          ,[tv_provider_type]
          ,[is_active]
          ,[last_refresh]
      FROM [dbo].[facility]
      WHERE ((@group_id = 0) OR ([group_id] = @group_id)) AND ([dtc000] IS NULL)
END