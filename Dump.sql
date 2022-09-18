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
	EntryDate DATETIME NOT NULL,
	ExpirationDate DATETIME NOT NULL,
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

CREATE PROCEDURE PostPartnerTypes
                @InputLabelPartnerTypes varchar(255)
AS
        INSERT INTO [PartnerTypes] (
                [Label]
        )
        VALUES (
                @InputLabelPartnerTypes
        );
        SELECT
                *
        FROM
                [PartnerTypes]
        WHERE
                [PartnerTypes].[Id] = SCOPE_IDENTITY();
GO
CREATE PROCEDURE PostPartners
                @InputIdPartnerTypePartners int,
                @InputFirstNamePartners varchar(255),
                @InputLastNamePartners varchar(255),
                @InputCompanyNamePartners varchar(255),
                @InputEmailPartners varchar(255),
                @InputPhoneNumberPartners int,
                @InputPostalAddressPartners varchar(255),
                @InputPostalCodePartners int
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
                @InputIdPartnerTypePartners,
                @InputFirstNamePartners,
                @InputLastNamePartners,
                @InputCompanyNamePartners,
                @InputEmailPartners,
                @InputPhoneNumberPartners,
                @InputPostalAddressPartners,
                @InputPostalCodePartners
        );
        SELECT
                *
        FROM
                [Partners]
        WHERE
                [Partners].[Id] = SCOPE_IDENTITY();
GO
CREATE PROCEDURE PostOrders
                @InputOrderDateOrders datetime,
                @InputOrderTagOrders varchar(255),
                @InputIdPartnerOrders int
AS
        INSERT INTO [Orders] (
                [OrderDate],
                [OrderTag],
                [IdPartner]
        )
        VALUES (
                @InputOrderDateOrders,
                @InputOrderTagOrders,
                @InputIdPartnerOrders
        );
        SELECT
                *
        FROM
                [Orders]
        WHERE
                [Orders].[Id] = SCOPE_IDENTITY();
GO
CREATE PROCEDURE PostGammes
                @InputLabelGammes varchar(255),
                @InputSummaryGammes varchar(255),
                @InputIdPartnerGammes int
AS
        INSERT INTO [Gammes] (
                [Label],
                [Summary],
                [IdPartner]
        )
        VALUES (
                @InputLabelGammes,
                @InputSummaryGammes,
                @InputIdPartnerGammes
        );
        SELECT
                *
        FROM
                [Gammes]
        WHERE
                [Gammes].[Id] = SCOPE_IDENTITY();
GO
CREATE PROCEDURE PostLots
                @InputLabelLots varchar(255),
                @InputQuantityLots int,
                @InputIdGammeLots int,
                @InputEntryDateLots datetime,
                @InputExpirationDateLots datetime
AS
        INSERT INTO [Lots] (
                [Label],
                [Quantity],
                [IdGamme],
                [EntryDate],
                [ExpirationDate]
        )
        VALUES (
                @InputLabelLots,
                @InputQuantityLots,
                @InputIdGammeLots,
                @InputEntryDateLots,
                @InputExpirationDateLots
        );
        SELECT
                *
        FROM
                [Lots]
        WHERE
                [Lots].[Id] = SCOPE_IDENTITY();
GO
CREATE PROCEDURE PostOrderContents
                @InputIdOrderOrderContents int,
                @InputIdLotOrderContents int,
                @InputQuantityOrderContents int
AS
        INSERT INTO [OrderContents] (
                [IdOrder],
                [IdLot],
                [Quantity]
        )
        VALUES (
                @InputIdOrderOrderContents,
                @InputIdLotOrderContents,
                @InputQuantityOrderContents
        );
        SELECT
                *
        FROM
                [OrderContents]
        WHERE
                [OrderContents].[Id] = SCOPE_IDENTITY();
GO
CREATE PROCEDURE PutPartnerTypes
                @InputToPutLabelPartnerTypes varchar(255),
                @InputIdPartnerTypes int
AS
        UPDATE [PartnerTypes]
        SET
                [PartnerTypes].[Label] = @InputToPutLabelPartnerTypes
        WHERE
                [PartnerTypes].[Id] = @InputIdPartnerTypes;
GO
CREATE PROCEDURE PutPartners
                @InputToPutIdPartnerTypePartners int,
                @InputToPutFirstNamePartners varchar(255),
                @InputToPutLastNamePartners varchar(255),
                @InputToPutCompanyNamePartners varchar(255),
                @InputToPutEmailPartners varchar(255),
                @InputToPutPhoneNumberPartners int,
                @InputToPutPostalAddressPartners varchar(255),
                @InputToPutPostalCodePartners int,
                @InputIdPartners int
AS
        UPDATE [Partners]
        SET
                [Partners].[IdPartnerType] = @InputToPutIdPartnerTypePartners,
                [Partners].[FirstName] = @InputToPutFirstNamePartners,
                [Partners].[LastName] = @InputToPutLastNamePartners,
                [Partners].[CompanyName] = @InputToPutCompanyNamePartners,
                [Partners].[Email] = @InputToPutEmailPartners,
                [Partners].[PhoneNumber] = @InputToPutPhoneNumberPartners,
                [Partners].[PostalAddress] = @InputToPutPostalAddressPartners,
                [Partners].[PostalCode] = @InputToPutPostalCodePartners
        WHERE
                [Partners].[Id] = @InputIdPartners;
GO
CREATE PROCEDURE PutOrders
                @InputToPutOrderDateOrders datetime,
                @InputToPutOrderTagOrders varchar(255),
                @InputToPutIdPartnerOrders int,
                @InputIdOrders int
AS
        UPDATE [Orders]
        SET
                [Orders].[OrderDate] = @InputToPutOrderDateOrders,
                [Orders].[OrderTag] = @InputToPutOrderTagOrders,
                [Orders].[IdPartner] = @InputToPutIdPartnerOrders
        WHERE
                [Orders].[Id] = @InputIdOrders;
GO
CREATE PROCEDURE PutGammes
                @InputToPutLabelGammes varchar(255),
                @InputToPutSummaryGammes varchar(255),
                @InputToPutIdPartnerGammes int,
                @InputIdGammes int
AS
        UPDATE [Gammes]
        SET
                [Gammes].[Label] = @InputToPutLabelGammes,
                [Gammes].[Summary] = @InputToPutSummaryGammes,
                [Gammes].[IdPartner] = @InputToPutIdPartnerGammes
        WHERE
                [Gammes].[Id] = @InputIdGammes;
GO
CREATE PROCEDURE PutLots
                @InputToPutLabelLots varchar(255),
                @InputToPutQuantityLots int,
                @InputToPutIdGammeLots int,
                @InputToPutEntryDateLots datetime,
                @InputToPutExpirationDateLots datetime,
                @InputIdLots int
AS
        UPDATE [Lots]
        SET
                [Lots].[Label] = @InputToPutLabelLots,
                [Lots].[Quantity] = @InputToPutQuantityLots,
                [Lots].[IdGamme] = @InputToPutIdGammeLots,
                [Lots].[EntryDate] = @InputToPutEntryDateLots,
                [Lots].[ExpirationDate] = @InputToPutExpirationDateLots
        WHERE
                [Lots].[Id] = @InputIdLots;
GO
CREATE PROCEDURE PutOrderContents
                @InputToPutIdOrderOrderContents int,
                @InputToPutIdLotOrderContents int,
                @InputToPutQuantityOrderContents int,
                @InputIdOrderContents int
AS
        UPDATE [OrderContents]
        SET
                [OrderContents].[IdOrder] = @InputToPutIdOrderOrderContents,
                [OrderContents].[IdLot] = @InputToPutIdLotOrderContents,
                [OrderContents].[Quantity] = @InputToPutQuantityOrderContents
        WHERE
                [OrderContents].[Id] = @InputIdOrderContents;
GO
CREATE PROCEDURE DeletePartnerTypes
                @InputIdPartnerTypes int
AS
        DELETE
        FROM
                [PartnerTypes]
        WHERE
                [PartnerTypes].[Id] = @InputIdPartnerTypes;
GO
CREATE PROCEDURE DeletePartners
                @InputIdPartners int
AS
        DELETE
        FROM
                [Partners]
        WHERE
                [Partners].[Id] = @InputIdPartners;
GO
CREATE PROCEDURE DeleteOrders
                @InputIdOrders int
AS
        DELETE
        FROM
                [Orders]
        WHERE
                [Orders].[Id] = @InputIdOrders;
GO
CREATE PROCEDURE DeleteGammes
                @InputIdGammes int
AS
        DELETE
        FROM
                [Gammes]
        WHERE
                [Gammes].[Id] = @InputIdGammes;
GO
CREATE PROCEDURE DeleteLots
                @InputIdLots int
AS
        DELETE
        FROM
                [Lots]
        WHERE
                [Lots].[Id] = @InputIdLots;
GO
CREATE PROCEDURE DeleteOrderContents
                @InputIdOrderContents int
AS
        DELETE
        FROM
                [OrderContents]
        WHERE
                [OrderContents].[Id] = @InputIdOrderContents;
GO
CREATE PROCEDURE GetAllPartnerTypes
AS
        SELECT
                Id = [PartnerTypes].[Id],
                Label = [PartnerTypes].[Label]
        FROM
                [PartnerTypes];
GO
CREATE PROCEDURE GetAllPartners
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
CREATE PROCEDURE GetAllOrders
AS
        SELECT
                Id = [Orders].[Id],
                OrderDate = [Orders].[OrderDate],
                OrderTag = [Orders].[OrderTag],
                IdPartner = [Orders].[IdPartner]
        FROM
                [Orders];
GO
CREATE PROCEDURE GetAllGammes
AS
        SELECT
                Id = [Gammes].[Id],
                Label = [Gammes].[Label],
                Summary = [Gammes].[Summary],
                IdPartner = [Gammes].[IdPartner]
        FROM
                [Gammes];
GO
CREATE PROCEDURE GetAllLots
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
CREATE PROCEDURE GetAllOrderContents
AS
        SELECT
                Id = [OrderContents].[Id],
                IdOrder = [OrderContents].[IdOrder],
                IdLot = [OrderContents].[IdLot],
                Quantity = [OrderContents].[Quantity]
        FROM
                [OrderContents];
GO
CREATE PROCEDURE GetPartnerTypes
                @InputIdPartnerTypes int
AS
        SELECT
                Id = [PartnerTypes].[Id],
                Label = [PartnerTypes].[Label]
        FROM
                [PartnerTypes]
        WHERE
                [PartnerTypes].[Id] = @InputIdPartnerTypes;
GO
CREATE PROCEDURE GetPartners
                @InputIdPartners int
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
                [Partners].[Id] = @InputIdPartners;
GO
CREATE PROCEDURE GetOrders
                @InputIdOrders int
AS
        SELECT
                Id = [Orders].[Id],
                OrderDate = [Orders].[OrderDate],
                OrderTag = [Orders].[OrderTag],
                IdPartner = [Orders].[IdPartner]
        FROM
                [Orders]
        WHERE
                [Orders].[Id] = @InputIdOrders;
GO
CREATE PROCEDURE GetGammes
                @InputIdGammes int
AS
        SELECT
                Id = [Gammes].[Id],
                Label = [Gammes].[Label],
                Summary = [Gammes].[Summary],
                IdPartner = [Gammes].[IdPartner]
        FROM
                [Gammes]
        WHERE
                [Gammes].[Id] = @InputIdGammes;
GO
CREATE PROCEDURE GetLots
                @InputIdLots int
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
                [Lots].[Id] = @InputIdLots;
GO
CREATE PROCEDURE GetOrderContents
                @InputIdOrderContents int
AS
        SELECT
                Id = [OrderContents].[Id],
                IdOrder = [OrderContents].[IdOrder],
                IdLot = [OrderContents].[IdLot],
                Quantity = [OrderContents].[Quantity]
        FROM
                [OrderContents]
        WHERE
                [OrderContents].[Id] = @InputIdOrderContents;
GO
CREATE PROCEDURE GetAllPartnersByIdPartnerType
                @InputIdPartnerTypePartners int
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
                [Partners].[IdPartnerType] = @InputIdPartnerTypePartners;
GO
CREATE PROCEDURE GetAllOrdersByIdPartner
                @InputIdPartnerOrders int
AS
        SELECT
                Id = [Orders].[Id],
                OrderDate = [Orders].[OrderDate],
                OrderTag = [Orders].[OrderTag],
                IdPartner = [Orders].[IdPartner]
        FROM
                [Orders]
        WHERE
                [Orders].[IdPartner] = @InputIdPartnerOrders;
GO
CREATE PROCEDURE GetAllGammesByIdPartner
                @InputIdPartnerGammes int
AS
        SELECT
                Id = [Gammes].[Id],
                Label = [Gammes].[Label],
                Summary = [Gammes].[Summary],
                IdPartner = [Gammes].[IdPartner]
        FROM
                [Gammes]
        WHERE
                [Gammes].[IdPartner] = @InputIdPartnerGammes;
GO
CREATE PROCEDURE GetAllLotsByIdGamme
                @InputIdGammeLots int
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
                [Lots].[IdGamme] = @InputIdGammeLots;
GO
CREATE PROCEDURE GetAllOrderContentsByIdOrder
                @InputIdOrderOrderContents int
AS
        SELECT
                Id = [OrderContents].[Id],
                IdOrder = [OrderContents].[IdOrder],
                IdLot = [OrderContents].[IdLot],
                Quantity = [OrderContents].[Quantity]
        FROM
                [OrderContents]
        WHERE
                [OrderContents].[IdOrder] = @InputIdOrderOrderContents;
GO
CREATE PROCEDURE GetAllOrderContentsByIdLot
                @InputIdLotOrderContents int
AS
        SELECT
                Id = [OrderContents].[Id],
                IdOrder = [OrderContents].[IdOrder],
                IdLot = [OrderContents].[IdLot],
                Quantity = [OrderContents].[Quantity]
        FROM
                [OrderContents]
        WHERE
                [OrderContents].[IdLot] = @InputIdLotOrderContents;
GO