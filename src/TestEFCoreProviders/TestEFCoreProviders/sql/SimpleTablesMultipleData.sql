create database SimpleTablesMultipleData
go
use SimpleTablesMultipleData
-- Create a table for INT data type with an autogenerated ID column
CREATE TABLE Tbl_INT (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn INT
);

-- Create a table for SMALLINT data type with an autogenerated ID column
CREATE TABLE Tbl_SMALLINT (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn SMALLINT
);

-- Create a table for TINYINT data type with an autogenerated ID column
CREATE TABLE Tbl_TINYINT (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn TINYINT
);

-- Create a table for BIGINT data type with an autogenerated ID column
CREATE TABLE Tbl_BIGINT (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn BIGINT
);

-- Create a table for DECIMAL/NUMERIC data type with an autogenerated ID column
CREATE TABLE Tbl_DECIMAL (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn DECIMAL(18, 2)
);

-- Create a table for FLOAT data type with an autogenerated ID column
CREATE TABLE Tbl_FLOAT (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn FLOAT
);

-- Create a table for REAL data type with an autogenerated ID column
CREATE TABLE Tbl_REAL (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn REAL
);

-- Create a table for MONEY data type with an autogenerated ID column
CREATE TABLE Tbl_MONEY (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn MONEY
);

-- Create a table for CHAR data type with an autogenerated ID column
CREATE TABLE Tbl_CHAR (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn CHAR(10)
);

-- Create a table for VARCHAR data type with an autogenerated ID column
CREATE TABLE Tbl_VARCHAR (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn VARCHAR(255)
);

-- Create a table for NCHAR data type with an autogenerated ID column
CREATE TABLE Tbl_NCHAR (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn NCHAR(10)
);

-- Create a table for NVARCHAR data type with an autogenerated ID column
CREATE TABLE Tbl_NVARCHAR (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn NVARCHAR(255)
);

-- Create a table for TEXT data type with an autogenerated ID column
CREATE TABLE Tbl_TEXT (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn TEXT
);

-- Create a table for NTEXT data type with an autogenerated ID column
CREATE TABLE Tbl_NTEXT (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn NTEXT
);

-- Create a table for BINARY data type with an autogenerated ID column
CREATE TABLE Tbl_BINARY (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn BINARY(10)
);

-- Create a table for VARBINARY data type with an autogenerated ID column
CREATE TABLE Tbl_VARBINARY (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn VARBINARY(255)
);

-- Create a table for IMAGE data type with an autogenerated ID column
CREATE TABLE Tbl_IMAGE (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn IMAGE
);

-- Create a table for DATE data type with an autogenerated ID column
CREATE TABLE Tbl_DATE (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn DATE
);

-- Create a table for TIME data type with an autogenerated ID column
CREATE TABLE Tbl_TIME (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn TIME
);

-- Create a table for DATETIME data type with an autogenerated ID column
CREATE TABLE Tbl_DATETIME (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn DATETIME
);

-- Create a table for SMALLDATETIME data type with an autogenerated ID column
CREATE TABLE Tbl_SMALLDATETIME (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn SMALLDATETIME
);

-- Create a table for DATETIME2 data type with an autogenerated ID column
CREATE TABLE Tbl_DATETIME2 (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn DATETIME2
);

-- Create a table for DATETIMEOFFSET data type with an autogenerated ID column
CREATE TABLE Tbl_DATETIMEOFFSET (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn DATETIMEOFFSET
);

-- Create a table for BIT data type with an autogenerated ID column
CREATE TABLE Tbl_BIT (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn BIT
);

-- Create a table for UNIQUEIDENTIFIER data type with an autogenerated ID column
CREATE TABLE Tbl_UNIQUEIDENTIFIER (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn UNIQUEIDENTIFIER
);


-- Create a table for XML data type with an autogenerated ID column
CREATE TABLE Tbl_XML (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn XML
);

-- Create a table for JSON data type with an autogenerated ID column
CREATE TABLE Tbl_JSON (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn NVARCHAR(MAX) -- JSON data is often stored as text
);

-- Create a table for GEOMETRY data type with an autogenerated ID column
CREATE TABLE Tbl_GEOMETRY (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn GEOMETRY
);

-- Create a table for GEOGRAPHY data type with an autogenerated ID column
CREATE TABLE Tbl_GEOGRAPHY (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn GEOGRAPHY
);


-- Create a table for HIERARCHYID data type with an autogenerated ID column
CREATE TABLE Tbl_HIERARCHYID (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DataColumn HIERARCHYID
);
