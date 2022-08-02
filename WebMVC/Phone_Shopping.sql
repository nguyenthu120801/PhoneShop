CREATE DATABASE PHONE_SHOPPING
GO
USE PHONE_SHOPPING
GO
---------------------Account --------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
	[IsBlocked] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
------------------------ Category ---------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] identity(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
---------------------- Customer ----------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] identity(1,1) NOT NULL,
	[FullName] [varchar](50) NOT NULL,
	[phone] [varchar](50) NOT NULL,
	[email] [varchar](50)  NULL,
	[gender] [bit] NOT NULL,
	[username] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
-----------------------------Order --------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] identity(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[status] [varchar](50) NOT NULL,
	[TotalPrice] [int]  NOT NULL,
	[OrderDate] [date] NOT NULL,
	[ShippedDate] [date] NULL,
	[ShipID] [int] NULL,
    [address] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
--------------------------------Order Detail --------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderID] [int]  NOT NULL,
	[DetailID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[price] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
----------------------------- Product --------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int]  identity(1,1) NOT NULL,
	[ProductName] [varchar] (200)NOT NULL,
	[image] [varchar] (MAX) NOT NULL,
	[price] [int]  NOT NULL,
	[CategoryID] [int]  NOT NULL,
	[IsSell] [bit]  NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
--------------------------Shipper --------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipper](
	[ID] [int] identity(1,1) NOT NULL,
	[FullName] [varchar](50) NOT NULL,
	[phone] [varchar](50) NOT NULL,
	[email] [varchar](50)  NULL,
	[gender] [bit] NOT NULL,
	[active] [bit] NOT NULL,
	[username] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


-------------------- CONSTRAINT KEY -------------------
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD FOREIGN KEY([username])
REFERENCES [dbo].[Account] ([username])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([ShipID])
REFERENCES [dbo].[Shipper] ([ID])
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Shipper]  WITH CHECK ADD FOREIGN KEY([username])
REFERENCES [dbo].[Account] ([username])
GO

------------------------------------- INSERT ACCOUNT ---------------------------------
INSERT INTO [dbo].[Account]([username],[password],[RoleName],[IsBlocked]) VALUES('Admin','123','Admin',0)
INSERT INTO [dbo].[Account]([username],[password],[RoleName],[IsBlocked]) VALUES('AnhTuan','123','Customer',0)
INSERT INTO [dbo].[Account]([username],[password],[RoleName],[IsBlocked]) VALUES('Elvis','123','Customer',0)
INSERT INTO [dbo].[Account]([username],[password],[RoleName],[IsBlocked]) VALUES('Kirk','123','Shipper',0)
INSERT INTO [dbo].[Account]([username],[password],[RoleName],[IsBlocked]) VALUES('MinhDuc','123','Customer',0)
INSERT INTO [dbo].[Account]([username],[password],[RoleName],[IsBlocked]) VALUES('NhatAnh','123','Customer',0)
INSERT INTO [dbo].[Account]([username],[password],[RoleName],[IsBlocked]) VALUES('Nicky','123','Customer',0)
INSERT INTO [dbo].[Account]([username],[password],[RoleName],[IsBlocked]) VALUES('Niel','123','Customer',0)
INSERT INTO [dbo].[Account]([username],[password],[RoleName],[IsBlocked]) VALUES('QuangQuan','123','Customer',0)
INSERT INTO [dbo].[Account]([username],[password],[RoleName],[IsBlocked]) VALUES('Terrell','123','Shipper',0)
INSERT INTO [dbo].[Account]([username],[password],[RoleName],[IsBlocked]) VALUES('ThuThu','123','Customer',0)
INSERT INTO [dbo].[Account]([username],[password],[RoleName],[IsBlocked]) VALUES('Tommy','123','Shipper',0)
INSERT INTO [dbo].[Account]([username],[password],[RoleName],[IsBlocked]) VALUES('Ulises','123','Shipper',0)
INSERT INTO [dbo].[Account]([username],[password],[RoleName],[IsBlocked]) VALUES('Virge','123','Shipper',0)
INSERT INTO [dbo].[Account]([username],[password],[RoleName],[IsBlocked]) VALUES('VuongDepTrai','123','Customer',0)
INSERT INTO [dbo].[Account]([username],[password],[RoleName],[IsBlocked]) VALUES('Willey','123','Customer',0)
--------------------------------------------- INSERT CATEGORY-------------------------------------
INSERT INTO [dbo].[Category]([Name])VALUES ('Samsung')
INSERT INTO [dbo].[Category]([Name])VALUES ('Oppo')
INSERT INTO [dbo].[Category]([Name])VALUES ('Iphone')
INSERT INTO [dbo].[Category]([Name])VALUES ('Vivo')
INSERT INTO [dbo].[Category]([Name])VALUES ('Nokia')
---------------------------------------------- INSERT CUSTOMER ------------------------------------
INSERT INTO [dbo].[Customer]([FullName],[phone],[email],[gender],[username])VALUES('Nguyen Thi Thu','4533389559','oparagreen0@usnews.com',0,'ThuThu')
INSERT INTO [dbo].[Customer]([FullName],[phone],[email],[gender],[username])VALUES('Nguyen Anh Tuan','6298446654','kfleet1@artisteer.com',1,'AnhTuan')
INSERT INTO [dbo].[Customer]([FullName],[phone],[email],[gender],[username])VALUES('Chu Quang Quan','8851738015','fellcock2@earthlink.net',1,'QuangQuan')
INSERT INTO [dbo].[Customer]([FullName],[phone],[email],[gender],[username])VALUES('Ta Nhat Anh','9306711406','phatherell3@sun.com',1,'NhatAnh')
INSERT INTO [dbo].[Customer]([FullName],[phone],[email],[gender],[username])VALUES('Nguyen Minh Duc','5541282702','bkervin4@fotki.com',1,'MinhDuc')
INSERT INTO [dbo].[Customer]([FullName],[phone],[email],[gender],[username])VALUES('Nguyen Minh Vuong','9544569704','rrushworth5@topsy.com',1,'VuongDepTrai')
INSERT INTO [dbo].[Customer]([FullName],[phone],[email],[gender],[username])VALUES('Nicky Gaitone','7583151589','ngaitone6@cyberchimps.com',0,'Nicky')
INSERT INTO [dbo].[Customer]([FullName],[phone],[email],[gender],[username])VALUES('Elvis Dutton','3475443555','edutton7@angelfire.com',1,'Elvis')
INSERT INTO [dbo].[Customer]([FullName],[phone],[email],[gender],[username])VALUES('Niel Kerwood','5399463237','nkerwood8@nps.gov',1,'Niel')
INSERT INTO [dbo].[Customer]([FullName],[phone],[email],[gender],[username])VALUES('Willey Lefley','9561589898','wlefley9@squarespace.com',1,'Willey')
-----------------------------------------------INSERT SHIPPER --------------------------------------
INSERT INTO [dbo].[Shipper]([FullName],[phone],[email],[gender],[active],[username]) VALUES ('Kirk Nelson','6481628081','KirkNelson@upenn.edu',0,1,'Kirk')
INSERT INTO [dbo].[Shipper]([FullName],[phone],[email],[gender],[active],[username]) VALUES ('Ulises Ayliffe','6511678528','uayliffe1@yahoo.co.jp',0,1,'Ulises')
INSERT INTO [dbo].[Shipper]([FullName],[phone],[email],[gender],[active],[username]) VALUES ('Terrell Cordobes','7908661977','tcordobes2@europa.eu',1,1,'Terrell')
INSERT INTO [dbo].[Shipper]([FullName],[phone],[email],[gender],[active],[username]) VALUES ('Virge Aldred','2934629124','valdred3@wisc.edu',0,1,'Virge')
INSERT INTO [dbo].[Shipper]([FullName],[phone],[email],[gender],[active],[username]) VALUES ('Tommy Walbrun','9661305299','twalbrun4@rambler.ru',0,1,'Tommy')
-----------------------------------------------INSERT PRODUCT --------------------------------------
INSERT INTO [dbo].[Product]([ProductName],[image],[price],[CategoryID],[IsSell])VALUES('Samsung Galaxy S22 Ultra 5G','https://cdn.tgdd.vn/Products/Images/42/235838/Galaxy-S22-Ultra-Burgundy-600x600.jpg',28990000,1,1)
INSERT INTO [dbo].[Product]([ProductName],[image],[price],[CategoryID],[IsSell])VALUES('Samsung Galaxy A03','https://cdn.tgdd.vn/Products/Images/42/251856/samsung-galaxy-a03-xanh-thumb-600x600.jpg',2890000,1,1)
INSERT INTO [dbo].[Product]([ProductName],[image],[price],[CategoryID],[IsSell])VALUES('Samsung Galaxy A33 5G 6GB','https://cdn.tgdd.vn/Products/Images/42/246199/samsung-galaxy-a33-5g-xanh-thumb-600x600.jpg',7290000,1,1)
INSERT INTO [dbo].[Product]([ProductName],[image],[price],[CategoryID],[IsSell])VALUES('OPPO Reno7 series','https://cdn.tgdd.vn/Products/Images/42/271717/oppo-reno7-z-5g-thumb-1-1-600x600.jpg',10490000,2,1)
INSERT INTO [dbo].[Product]([ProductName],[image],[price],[CategoryID],[IsSell])VALUES('OPPO Find X5 Pro 5G','https://cdn.tgdd.vn/Products/Images/42/250622/oppo-find-x5-pro-den-thumb-600x600.jpg',30990000,2,1)
INSERT INTO [dbo].[Product]([ProductName],[image],[price],[CategoryID],[IsSell])VALUES('OPPO A76','https://cdn.tgdd.vn/Products/Images/42/270360/OPPO-A76-%C4%91en-600x600.jpg',5990000,2,1)
INSERT INTO [dbo].[Product]([ProductName],[image],[price],[CategoryID],[IsSell])VALUES('OPPO A16','https://cdn.tgdd.vn/Products/Images/42/240631/oppo-a16-silver-8-600x600.jpg',3790000,2,1)
INSERT INTO [dbo].[Product]([ProductName],[image],[price],[CategoryID],[IsSell])VALUES('iPhone 11','https://cdn.tgdd.vn/Products/Images/42/153856/iphone-xi-xanhla-600x600.jpg',12890000,3,1)
INSERT INTO [dbo].[Product]([ProductName],[image],[price],[CategoryID],[IsSell])VALUES('iPhone 13 Pro Max','https://cdn.tgdd.vn/Products/Images/42/230529/iphone-13-pro-max-gold-1-600x600.jpg',30890000,3,1)
INSERT INTO [dbo].[Product]([ProductName],[image],[price],[CategoryID],[IsSell])VALUES('iPhone 12 Pro Max 512GB','https://cdn.tgdd.vn/Products/Images/42/228744/iphone-12-pro-max-xanh-duong-new-600x600-600x600.jpg',30990000,3,1)
INSERT INTO [dbo].[Product]([ProductName],[image],[price],[CategoryID],[IsSell])VALUES('iPhone 13 Pro','https://cdn.tgdd.vn/Products/Images/42/230521/iphone-13-pro-sierra-blue-600x600.jpg',28190000,3,1)
INSERT INTO [dbo].[Product]([ProductName],[image],[price],[CategoryID],[IsSell])VALUES('Vivo Y15 series','https://cdn.tgdd.vn/Products/Images/42/249720/Vivo-y15s-2021-xanh-den-660x600.jpg',3090000,4,1)
INSERT INTO [dbo].[Product]([ProductName],[image],[price],[CategoryID],[IsSell])VALUES('Vivo V21 5G','https://cdn.tgdd.vn/Products/Images/42/238047/vivo-v21-5g-xanh-den-600x600.jpg',7890000,4,1)
INSERT INTO [dbo].[Product]([ProductName],[image],[price],[CategoryID],[IsSell])VALUES('Vivo Y55','https://cdn.tgdd.vn/Products/Images/42/278949/vivo-y55-den-thumb-600x600.jpg',6990000,4,1)
INSERT INTO [dbo].[Product]([ProductName],[image],[price],[CategoryID],[IsSell])VALUES('Vivo Y53s','https://cdn.tgdd.vn/Products/Images/42/240286/vivo-y53s-xanh-600x600.jpg',5490000,4,1)
INSERT INTO [dbo].[Product]([ProductName],[image],[price],[CategoryID],[IsSell])VALUES('Nokia G21','https://cdn.tgdd.vn/Products/Images/42/270207/nokia-g21-xanh-thumb-600x600.jpg',3840000,5,1)
INSERT INTO [dbo].[Product]([ProductName],[image],[price],[CategoryID],[IsSell])VALUES('Nokia G11','https://cdn.tgdd.vn/Products/Images/42/272148/Nokia-g11-x%C3%A1m-thumb-600x600.jpg',3240000,5,1)
INSERT INTO [dbo].[Product]([ProductName],[image],[price],[CategoryID],[IsSell])VALUES('Nokia G10','https://cdn.tgdd.vn/Products/Images/42/235995/Nokia%20g10%20xanh%20duong-600x600.jpg',3190000,5,1)
INSERT INTO [dbo].[Product]([ProductName],[image],[price],[CategoryID],[IsSell])VALUES('Nokia 215 4G','https://cdn.tgdd.vn/Products/Images/42/228366/nokia-215-xanh-ngoc-new-600x600-600x600.jpg',900000,5,1)
