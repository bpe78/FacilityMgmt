CREATE TABLE [dbo].[facility_group]
(
    [id] INT NOT NULL PRIMARY KEY,
    [name] NVARCHAR(25) NOT NULL,

    [dta000] DATETIME2(3) NOT NULL,
    [dtb000] DATETIME2(3) NULL,
    [dtc000] DATETIME2(3) NULL
)
