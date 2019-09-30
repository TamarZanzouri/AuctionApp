CREATE DATABASE Auction;
GO

/* Change to the Music database */
USE Auction;
GO

/* Create tables */
CREATE TABLE Members (
    Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name nvarchar(Max) NOT NULL,
    Email NVARCHAR(Max) NOT NULL,
    Password NVARCHAR(MAX) NOT NULL,
    ActiveFrom DATETIME NOT NULL,
    DateDeleted DATETIME NULL
);

Create table Product(
    Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name nvarchar(Max) NOT NULL,
    Description nvarchar(Max) NOT NULL,
    Image NVARCHAR(Max) NOT NULL,
    ActiveFrom DATETIME NOT NULL,
    EndDate DATETIME NULL
);


CREATE TABLE MemberToProduct (
    Id int IDENTITY(1,1) PRIMARY KEY,
    MemberId int  NOT NULL,
    ProductId int NOT NULL,
    ActiveFrom DATETIME NULL

    CONSTRAINT FK_MemberToProduct_Members FOREIGN KEY (MemberId)     
    REFERENCES dbo.Members (Id),
    CONSTRAINT FK_MemberToProduct_Product FOREIGN KEY (ProductId)     
    REFERENCES dbo.Product (Id)  
);

CREATE TABLE MemberToBid
 (
     Id int IDENTITY(1,1) not null PRIMARY KEY,
     MemberId int REFERENCES Members(Id) NOT NULL,
     ProductId int REFERENCES Product(Id) NOT NULL,
     BidAmount int NOT NULL,
     ActiveFrom DATETIME NULL
);
GO