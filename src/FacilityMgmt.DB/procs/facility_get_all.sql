CREATE PROCEDURE [dbo].[facility_get_all]
AS
BEGIN
    SELECT [id]
          ,[name]
          ,[short_name]
          ,[group_id]
          ,[access_token]
          ,[geography]
          ,[country]
          ,[postal_code]
          ,[tv_region_id]
          ,[tv_provider_id]
          ,[tv_rovider_name]
          ,[tv_provider_type]
          ,[last_refresh]
      FROM [dbo].[facility]
      WHERE [dtc000] IS NULL
END