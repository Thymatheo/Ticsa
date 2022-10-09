USE master;
DROP DATABASE Ticsa;
CREATE DATABASE Ticsa;
USE Ticsa;

CREATE TABLE PartnerTypes(
	Id INT IDENTITY(1,1) NOT NULL,
	Label VARCHAR(255) NOT NULL,
	CONSTRAINT PK_PartnerTypes_Id PRIMARY KEY CLUSTERED (Id)
);
INSERT INTO PartnerTypes(Label) VALUES
	('Client'),
	('Producer')
;

CREATE TABLE Partners(
	Id INT IDENTITY(1,1) NOT NULL,
        IdPartnerType INT NOT NULL,
	FirstName VARCHAR(255) NOT NULL,
	LastName VARCHAR(255) NOT NULL,
	CompanyName VARCHAR(255) NOT NULL,
	Email VARCHAR(255) NOT NULL,
	PhoneNumber INT NULL,
	PostalAddress VARCHAR(255) NULL,
	PostalCode INT NULL,
	CONSTRAINT FK_PartnerTypes_Id_Partners_IdPartnerType FOREIGN KEY (IdPartnerType) REFERENCES PartnerTypes(Id),
	CONSTRAINT PK_Partners_Id PRIMARY KEY CLUSTERED (Id)
);

CREATE TABLE Orders(
	Id INT IDENTITY(1,1) NOT NULL,
	OrderDate DATETIME NOT NULL,
	OrderTag VARCHAR(255) NOT NULL,
	IdPartner INT NOT NULL,
	CONSTRAINT FK_Partners_Id_Orders_IdPartner FOREIGN KEY (IdPartner) REFERENCES Partners(Id),
	CONSTRAINT PK_Orders_Id PRIMARY KEY CLUSTERED (Id)
);

CREATE TABLE Gammes(
	Id INT IDENTITY(1,1) NOT NULL,
	Label VARCHAR(255) NOT NULL,
	Summary VARCHAR(255) NOT NULL,
        IdPartner INT NOT NULL,
	CONSTRAINT FK_Partners_Id_Gammes_IdPartner FOREIGN KEY (IdPartner) REFERENCES Partners(Id),
	CONSTRAINT PK_Gammes_Id PRIMARY KEY CLUSTERED (Id)
);

CREATE TABLE Lots(
	Id INT IDENTITY(1,1) NOT NULL,
        Label VARCHAR(255) NOT NULL,
	Quantity INT NOT NULL,
        IdGamme INT NOT NULL,
	EntryDate DATETIME2 NOT NULL,
	ExpirationDate DATETIME2 NOT NULL,
        CONSTRAINT FK_Gammes_Id_Lots_IdGamme FOREIGN KEY (IdGamme) REFERENCES Gammes(Id),
	CONSTRAINT PK_Lots_Id PRIMARY KEY CLUSTERED (Id)
);

CREATE TABLE OrderContents(
	Id INT IDENTITY(1,1) NOT NULL,
        IdOrder INT NOT NULL,
        IdLot INT NOT NULL,
	Quantity INT NOT NULL,
	CONSTRAINT FK_Orders_Id_OrderContents_IdOrder FOREIGN KEY (IdOrder) REFERENCES Orders(Id),
	CONSTRAINT FK_Lots_Id_OrderContents_IdLot FOREIGN KEY (IdLot) REFERENCES Lots(Id),
	CONSTRAINT PK_OrderContents_Id PRIMARY KEY CLUSTERED (Id)
);
GO
CREATE PROCEDURE GetPartnerTypess
AS
        SELECT
                Id = [PartnerTypes].[Id],
                Label = [PartnerTypes].[Label]
        FROM
                [PartnerTypes];
GO
CREATE PROCEDURE GetPartnerTypes
                @Id int
AS
        SELECT
                Id = [PartnerTypes].[Id],
                Label = [PartnerTypes].[Label]
        FROM
                [PartnerTypes]
        WHERE
                [PartnerTypes].[Id] = @Id;
GO
CREATE PROCEDURE GetPartnerss
AS
        SELECT
                Id = [Partners].[Id],
                IdPartnerType = [Partners].[IdPartnerType],
                FirstName = [Partners].[FirstName],
                LastName = [Partners].[LastName],
                CompanyName = [Partners].[CompanyName],
                Email = [Partners].[Email],
                PhoneNumber = [Partners].[PhoneNumber],
                PostalAddress = [Partners].[PostalAddress],
                PostalCode = [Partners].[PostalCode]
        FROM
                [Partners];
GO
CREATE PROCEDURE GetPartners
                @Id int
AS
        SELECT
                Id = [Partners].[Id],
                IdPartnerType = [Partners].[IdPartnerType],
                FirstName = [Partners].[FirstName],
                LastName = [Partners].[LastName],
                CompanyName = [Partners].[CompanyName],
                Email = [Partners].[Email],
                PhoneNumber = [Partners].[PhoneNumber],
                PostalAddress = [Partners].[PostalAddress],
                PostalCode = [Partners].[PostalCode]
        FROM
                [Partners]
        WHERE
                [Partners].[Id] = @Id;
GO
CREATE PROCEDURE GetPartnersByIdPartnerType
                @IdPartnerType int
AS
        SELECT
                Id = [Partners].[Id],
                IdPartnerType = [Partners].[IdPartnerType],
                FirstName = [Partners].[FirstName],
                LastName = [Partners].[LastName],
                CompanyName = [Partners].[CompanyName],
                Email = [Partners].[Email],
                PhoneNumber = [Partners].[PhoneNumber],
                PostalAddress = [Partners].[PostalAddress],
                PostalCode = [Partners].[PostalCode]
        FROM
                [Partners]
        WHERE
                [Partners].[IdPartnerType] = @IdPartnerType;
GO
CREATE PROCEDURE GetOrderss
AS
        SELECT
                Id = [Orders].[Id],
                OrderDate = [Orders].[OrderDate],
                OrderTag = [Orders].[OrderTag],
                IdPartner = [Orders].[IdPartner]
        FROM
                [Orders];
GO
CREATE PROCEDURE GetOrders
                @Id int
AS
        SELECT
                Id = [Orders].[Id],
                OrderDate = [Orders].[OrderDate],
                OrderTag = [Orders].[OrderTag],
                IdPartner = [Orders].[IdPartner]
        FROM
                [Orders]
        WHERE
                [Orders].[Id] = @Id;
GO
CREATE PROCEDURE GetOrdersByIdPartner
                @IdPartner int
AS
        SELECT
                Id = [Orders].[Id],
                OrderDate = [Orders].[OrderDate],
                OrderTag = [Orders].[OrderTag],
                IdPartner = [Orders].[IdPartner]
        FROM
                [Orders]
        WHERE
                [Orders].[IdPartner] = @IdPartner;
GO
CREATE PROCEDURE GetGammess
AS
        SELECT
                Id = [Gammes].[Id],
                Label = [Gammes].[Label],
                Summary = [Gammes].[Summary],
                IdPartner = [Gammes].[IdPartner]
        FROM
                [Gammes];
GO
CREATE PROCEDURE GetGammes
                @Id int
AS
        SELECT
                Id = [Gammes].[Id],
                Label = [Gammes].[Label],
                Summary = [Gammes].[Summary],
                IdPartner = [Gammes].[IdPartner]
        FROM
                [Gammes]
        WHERE
                [Gammes].[Id] = @Id;
GO
CREATE PROCEDURE GetGammesByIdPartner
                @IdPartner int
AS
        SELECT
                Id = [Gammes].[Id],
                Label = [Gammes].[Label],
                Summary = [Gammes].[Summary],
                IdPartner = [Gammes].[IdPartner]
        FROM
                [Gammes]
        WHERE
                [Gammes].[IdPartner] = @IdPartner;
GO
CREATE PROCEDURE GetLotss
AS
        SELECT
                Id = [Lots].[Id],
                Label = [Lots].[Label],
                Quantity = [Lots].[Quantity],
                IdGamme = [Lots].[IdGamme],
                EntryDate = [Lots].[EntryDate],
                ExpirationDate = [Lots].[ExpirationDate]
        FROM
                [Lots];
GO
CREATE PROCEDURE GetLots
                @Id int
AS
        SELECT
                Id = [Lots].[Id],
                Label = [Lots].[Label],
                Quantity = [Lots].[Quantity],
                IdGamme = [Lots].[IdGamme],
                EntryDate = [Lots].[EntryDate],
                ExpirationDate = [Lots].[ExpirationDate]
        FROM
                [Lots]
        WHERE
                [Lots].[Id] = @Id;
GO
CREATE PROCEDURE GetLotsByIdGamme
                @IdGamme int
AS
        SELECT
                Id = [Lots].[Id],
                Label = [Lots].[Label],
                Quantity = [Lots].[Quantity],
                IdGamme = [Lots].[IdGamme],
                EntryDate = [Lots].[EntryDate],
                ExpirationDate = [Lots].[ExpirationDate]
        FROM
                [Lots]
        WHERE
                [Lots].[IdGamme] = @IdGamme;
GO
CREATE PROCEDURE GetOrderContentss
AS
        SELECT
                Id = [OrderContents].[Id],
                IdOrder = [OrderContents].[IdOrder],
                IdLot = [OrderContents].[IdLot],
                Quantity = [OrderContents].[Quantity]
        FROM
                [OrderContents];
GO
CREATE PROCEDURE GetOrderContents
                @Id int
AS
        SELECT
                Id = [OrderContents].[Id],
                IdOrder = [OrderContents].[IdOrder],
                IdLot = [OrderContents].[IdLot],
                Quantity = [OrderContents].[Quantity]
        FROM
                [OrderContents]
        WHERE
                [OrderContents].[Id] = @Id;
GO
CREATE PROCEDURE GetOrderContentsByIdOrder
                @IdOrder int
AS
        SELECT
                Id = [OrderContents].[Id],
                IdOrder = [OrderContents].[IdOrder],
                IdLot = [OrderContents].[IdLot],
                Quantity = [OrderContents].[Quantity]
        FROM
                [OrderContents]
        WHERE
                [OrderContents].[IdOrder] = @IdOrder;
GO
CREATE PROCEDURE GetOrderContentsByIdLot
                @IdLot int
AS
        SELECT
                Id = [OrderContents].[Id],
                IdOrder = [OrderContents].[IdOrder],
                IdLot = [OrderContents].[IdLot],
                Quantity = [OrderContents].[Quantity]
        FROM
                [OrderContents]
        WHERE
                [OrderContents].[IdLot] = @IdLot;
GO
CREATE PROCEDURE PostPartnerTypes
                @Label varchar(255)
AS
        INSERT INTO [PartnerTypes] (
                [Label]
        )
        VALUES (
                @Label
        );
        SELECT
                Id = [PartnerTypes].[Id],
                Label = [PartnerTypes].[Label]
        FROM
                [PartnerTypes]
        WHERE
                [PartnerTypes].[Id] = SCOPE_IDENTITY();
GO
CREATE PROCEDURE PostPartners
                @IdPartnerType int,
                @FirstName varchar(255),
                @LastName varchar(255),
                @CompanyName varchar(255),
                @Email varchar(255),
                @PhoneNumber int,
                @PostalAddress varchar(255),
                @PostalCode int
AS
        INSERT INTO [Partners] (
                [IdPartnerType],
                [FirstName],
                [LastName],
                [CompanyName],
                [Email],
                [PhoneNumber],
                [PostalAddress],
                [PostalCode]
        )
        VALUES (
                @IdPartnerType,
                @FirstName,
                @LastName,
                @CompanyName,
                @Email,
                @PhoneNumber,
                @PostalAddress,
                @PostalCode
        );
        SELECT
                Id = [Partners].[Id],
                IdPartnerType = [Partners].[IdPartnerType],
                FirstName = [Partners].[FirstName],
                LastName = [Partners].[LastName],
                CompanyName = [Partners].[CompanyName],
                Email = [Partners].[Email],
                PhoneNumber = [Partners].[PhoneNumber],
                PostalAddress = [Partners].[PostalAddress],
                PostalCode = [Partners].[PostalCode]
        FROM
                [Partners]
        WHERE
                [Partners].[Id] = SCOPE_IDENTITY();
GO
CREATE PROCEDURE PostOrders
                @OrderDate datetime,
                @OrderTag varchar(255),
                @IdPartner int
AS
        INSERT INTO [Orders] (
                [OrderDate],
                [OrderTag],
                [IdPartner]
        )
        VALUES (
                @OrderDate,
                @OrderTag,
                @IdPartner
        );
        SELECT
                Id = [Orders].[Id],
                OrderDate = [Orders].[OrderDate],
                OrderTag = [Orders].[OrderTag],
                IdPartner = [Orders].[IdPartner]
        FROM
                [Orders]
        WHERE
                [Orders].[Id] = SCOPE_IDENTITY();
GO
CREATE PROCEDURE PostGammes
                @Label varchar(255),
                @Summary varchar(255),
                @IdPartner int
AS
        INSERT INTO [Gammes] (
                [Label],
                [Summary],
                [IdPartner]
        )
        VALUES (
                @Label,
                @Summary,
                @IdPartner
        );
        SELECT
                Id = [Gammes].[Id],
                Label = [Gammes].[Label],
                Summary = [Gammes].[Summary],
                IdPartner = [Gammes].[IdPartner]
        FROM
                [Gammes]
        WHERE
                [Gammes].[Id] = SCOPE_IDENTITY();
GO
CREATE PROCEDURE PostLots
                @Label varchar(255),
                @Quantity int,
                @IdGamme int,
                @EntryDate datetime2,
                @ExpirationDate datetime2
AS
        INSERT INTO [Lots] (
                [Label],
                [Quantity],
                [IdGamme],
                [EntryDate],
                [ExpirationDate]
        )
        VALUES (
                @Label,
                @Quantity,
                @IdGamme,
                @EntryDate,
                @ExpirationDate
        );
        SELECT
                Id = [Lots].[Id],
                Label = [Lots].[Label],
                Quantity = [Lots].[Quantity],
                IdGamme = [Lots].[IdGamme],
                EntryDate = [Lots].[EntryDate],
                ExpirationDate = [Lots].[ExpirationDate]
        FROM
                [Lots]
        WHERE
                [Lots].[Id] = SCOPE_IDENTITY();
GO
CREATE PROCEDURE PostOrderContents
                @IdOrder int,
                @IdLot int,
                @Quantity int
AS
        INSERT INTO [OrderContents] (
                [IdOrder],
                [IdLot],
                [Quantity]
        )
        VALUES (
                @IdOrder,
                @IdLot,
                @Quantity
        );
        SELECT
                Id = [OrderContents].[Id],
                IdOrder = [OrderContents].[IdOrder],
                IdLot = [OrderContents].[IdLot],
                Quantity = [OrderContents].[Quantity]
        FROM
                [OrderContents]
        WHERE
                [OrderContents].[Id] = SCOPE_IDENTITY();
GO
CREATE PROCEDURE DeletePartnerTypes
                @Id int
AS
        DELETE
        FROM
                [PartnerTypes]
        WHERE
                [PartnerTypes].[Id] = @Id;
GO
CREATE PROCEDURE DeletePartners
                @Id int
AS
        DELETE
        FROM
                [Partners]
        WHERE
                [Partners].[Id] = @Id;
GO
CREATE PROCEDURE DeleteOrders
                @Id int
AS
        DELETE
        FROM
                [Orders]
        WHERE
                [Orders].[Id] = @Id;
GO
CREATE PROCEDURE DeleteGammes
                @Id int
AS
        DELETE
        FROM
                [Gammes]
        WHERE
                [Gammes].[Id] = @Id;
GO
CREATE PROCEDURE DeleteLots
                @Id int
AS
        DELETE
        FROM
                [Lots]
        WHERE
                [Lots].[Id] = @Id;
GO
CREATE PROCEDURE DeleteOrderContents
                @Id int
AS
        DELETE
        FROM
                [OrderContents]
        WHERE
                [OrderContents].[Id] = @Id;
GO
CREATE PROCEDURE PutPartnerTypes
                @Label varchar(255),
                @Id int
AS
        UPDATE [PartnerTypes]
        SET
                [PartnerTypes].[Label] = @Label
        WHERE
                [PartnerTypes].[Id] = @Id;
GO
CREATE PROCEDURE PutPartners
                @IdPartnerType int,
                @FirstName varchar(255),
                @LastName varchar(255),
                @CompanyName varchar(255),
                @Email varchar(255),
                @PhoneNumber int,
                @PostalAddress varchar(255),
                @PostalCode int,
                @Id int
AS
        UPDATE [Partners]
        SET
                [Partners].[IdPartnerType] = @IdPartnerType,
                [Partners].[FirstName] = @FirstName,
                [Partners].[LastName] = @LastName,
                [Partners].[CompanyName] = @CompanyName,
                [Partners].[Email] = @Email,
                [Partners].[PhoneNumber] = @PhoneNumber,
                [Partners].[PostalAddress] = @PostalAddress,
                [Partners].[PostalCode] = @PostalCode
        WHERE
                [Partners].[Id] = @Id;
GO
CREATE PROCEDURE PutOrders
                @OrderDate datetime,
                @OrderTag varchar(255),
                @IdPartner int,
                @Id int
AS
        UPDATE [Orders]
        SET
                [Orders].[OrderDate] = @OrderDate,
                [Orders].[OrderTag] = @OrderTag,
                [Orders].[IdPartner] = @IdPartner
        WHERE
                [Orders].[Id] = @Id;
GO
CREATE PROCEDURE PutGammes
                @Label varchar(255),
                @Summary varchar(255),
                @IdPartner int,
                @Id int
AS
        UPDATE [Gammes]
        SET
                [Gammes].[Label] = @Label,
                [Gammes].[Summary] = @Summary,
                [Gammes].[IdPartner] = @IdPartner
        WHERE
                [Gammes].[Id] = @Id;
GO
CREATE PROCEDURE PutLots
                @Label varchar(255),
                @Quantity int,
                @IdGamme int,
                @EntryDate datetime2,
                @ExpirationDate datetime2,
                @Id int
AS
        UPDATE [Lots]
        SET
                [Lots].[Label] = @Label,
                [Lots].[Quantity] = @Quantity,
                [Lots].[IdGamme] = @IdGamme,
                [Lots].[EntryDate] = @EntryDate,
                [Lots].[ExpirationDate] = @ExpirationDate
        WHERE
                [Lots].[Id] = @Id;
GO
CREATE PROCEDURE PutOrderContents
                @IdOrder int,
                @IdLot int,
                @Quantity int,
                @Id int
AS
        UPDATE [OrderContents]
        SET
                [OrderContents].[IdOrder] = @IdOrder,
                [OrderContents].[IdLot] = @IdLot,
                [OrderContents].[Quantity] = @Quantity
        WHERE
                [OrderContents].[Id] = @Id;
GO