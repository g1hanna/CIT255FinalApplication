USE master;
GO

DROP DATABASE IF EXISTS SLICKIceDB;
GO
CREATE DATABASE SLICKIceDB;
GO

USE SLICKIceDB;
GO

CREATE TABLE Account (
	AccountID			INT		PRIMARY KEY,
	AccountUsername		VARCHAR(30),
	AccountPassword		VARCHAR(30),
	AccountFirstName	VARCHAR(50),
	AccountLastName		VARCHAR(70)
);
CREATE TABLE Item (
	ItemID			INT		PRIMARY KEY,
	ItemName		VARCHAR(70),
	ItemDescription	VARCHAR(200),
	ItemType		CHAR(3),
	ItemCondition	SMALLINT,
	ItemAvailable	BIT
);
CREATE TABLE Inventory (
	AccountID		INT,
	ItemID			INT,
	CONSTRAINT PK_Inventory PRIMARY KEY (AccountID, ItemID)
);
GO

