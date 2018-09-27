CREATE TABLE [dbo].[facility]
(
    [id] UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(100) NOT NULL, 
    [short_name] NVARCHAR(20) NOT NULL,
    [group_id] INT NOT NULL REFERENCES [dbo].[facility_group](id),
    [access_token] NVARCHAR(100) NOT NULL,
    [geography] NVARCHAR(4) NOT NULL,
    [country] NCHAR(3) NOT NULL,
    [area_code] NVARCHAR(20) NULL,
    [tv_region_id] INT NULL,
    [tv_provider_id] NVARCHAR(100) NOT NULL,
    [tv_provider_name] NVARCHAR(100) NOT NULL,
    [tv_provider_type] NVARCHAR(10) NOT NULL,
    [is_active] BIT NOT NULL,
    [last_refresh]  DATETIME2(0) NULL,

    [dta000] DATETIME2(3) NOT NULL,
    [dtb000] DATETIME2(3) NULL,
    [dtc000] DATETIME2(3) NULL
)
