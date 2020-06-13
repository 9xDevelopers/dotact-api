USE [dotactdesign]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 6/7/2020 3:08:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [nchar](10) NOT NULL,
	[UniqueCode] [nchar](10) NULL,
	[Name] [nchar](10) NULL,
	[Image] [nchar](10) NULL,
	[Description] [nchar](10) NULL,
	[IsActive] [nchar](10) NULL,
	[IsDelete] [nchar](10) NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/7/2020 3:08:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [nchar](10) NOT NULL,
	[UniqueCode] [nchar](10) NULL,
	[Name] [nchar](10) NULL,
	[Image] [nchar](10) NULL,
	[Description] [nchar](10) NULL,
	[ParentId] [nchar](10) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 6/7/2020 3:08:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[Id] [nchar](10) NOT NULL,
	[Name] [nchar](10) NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Configuration]    Script Date: 6/7/2020 3:08:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configuration](
	[Id] [nchar](10) NOT NULL,
	[UniqueCode] [nchar](10) NULL,
	[CategoryId] [nchar](10) NULL,
	[Name] [nchar](10) NULL,
 CONSTRAINT [PK_Configuration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveryStatus]    Script Date: 6/7/2020 3:08:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryStatus](
	[Id] [nchar](10) NOT NULL,
	[Name] [nchar](10) NULL,
 CONSTRAINT [PK_DeliveryStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 6/7/2020 3:08:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [nchar](10) NOT NULL,
	[UniqueCode] [nchar](10) NULL,
	[UserId] [nchar](10) NULL,
	[TotalPrice] [nchar](10) NULL,
	[ShipperId] [nchar](10) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 6/7/2020 3:08:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderId] [nchar](10) NULL,
	[ProductDetailId] [nchar](10) NULL,
	[Quantity] [nchar](10) NULL,
	[Price] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 6/7/2020 3:08:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[OrderId] [nchar](10) NOT NULL,
	[StatusId] [nchar](10) NOT NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/7/2020 3:08:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [nchar](10) NOT NULL,
	[UniqueCode] [uniqueidentifier] NULL,
	[ProductName] [nchar](10) NULL,
	[CategoryId] [nchar](10) NULL,
	[BrandId] [nchar](10) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductConfiguration]    Script Date: 6/7/2020 3:08:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductConfiguration](
	[Id] [nchar](10) NOT NULL,
	[UniqueCode] [nchar](10) NULL,
	[ProductId] [nchar](10) NULL,
	[ConfigurationData] [nchar](10) NULL,
 CONSTRAINT [PK_ProductConfiguration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductDetail]    Script Date: 6/7/2020 3:08:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDetail](
	[ProductConfigurationId] [nchar](10) NOT NULL,
	[ColorId] [nchar](10) NOT NULL,
	[Price] [nchar](10) NULL,
	[InStock] [nchar](10) NULL,
 CONSTRAINT [PK_ProductDetail_1] PRIMARY KEY CLUSTERED 
(
	[ProductConfigurationId] ASC,
	[ColorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Configuration]  WITH CHECK ADD  CONSTRAINT [FK_Configuration_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Configuration] CHECK CONSTRAINT [FK_Configuration_Category]
GO
ALTER TABLE [dbo].[OrderStatus]  WITH CHECK ADD  CONSTRAINT [FK_OrderStatus_DeliveryStatus] FOREIGN KEY([StatusId])
REFERENCES [dbo].[DeliveryStatus] ([Id])
GO
ALTER TABLE [dbo].[OrderStatus] CHECK CONSTRAINT [FK_OrderStatus_DeliveryStatus]
GO
ALTER TABLE [dbo].[OrderStatus]  WITH CHECK ADD  CONSTRAINT [FK_OrderStatus_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderStatus] CHECK CONSTRAINT [FK_OrderStatus_Order]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Brand]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[ProductConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_ProductConfiguration_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductConfiguration] CHECK CONSTRAINT [FK_ProductConfiguration_Product]
GO
ALTER TABLE [dbo].[ProductDetail]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetail_Color] FOREIGN KEY([ColorId])
REFERENCES [dbo].[Color] ([Id])
GO
ALTER TABLE [dbo].[ProductDetail] CHECK CONSTRAINT [FK_ProductDetail_Color]
GO
ALTER TABLE [dbo].[ProductDetail]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetail_ProductConfiguration] FOREIGN KEY([ProductConfigurationId])
REFERENCES [dbo].[ProductConfiguration] ([Id])
GO
ALTER TABLE [dbo].[ProductDetail] CHECK CONSTRAINT [FK_ProductDetail_ProductConfiguration]
GO
