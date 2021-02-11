--Brands
SET IDENTITY_INSERT [dbo].[Brands] ON
INSERT INTO [dbo].[Brands] ([BrandId], [BrandName]) VALUES (1, N'Mercedes-Benz')
INSERT INTO [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2, N'Hyundai')
INSERT INTO [dbo].[Brands] ([BrandId], [BrandName]) VALUES (3, N'Honda')
INSERT INTO [dbo].[Brands] ([BrandId], [BrandName]) VALUES (4, N'Toyota')
INSERT INTO [dbo].[Brands] ([BrandId], [BrandName]) VALUES (5, N'Ford')
INSERT INTO [dbo].[Brands] ([BrandId], [BrandName]) VALUES (6, N'BMW')
INSERT INTO [dbo].[Brands] ([BrandId], [BrandName]) VALUES (7, N'Porsche')
INSERT INTO [dbo].[Brands] ([BrandId], [BrandName]) VALUES (8, N'Nissan')
INSERT INTO [dbo].[Brands] ([BrandId], [BrandName]) VALUES (9, N'Volkswagen')
INSERT INTO [dbo].[Brands] ([BrandId], [BrandName]) VALUES (10, N'Audi')
INSERT INTO [dbo].[Brands] ([BrandId], [BrandName]) VALUES (11, N'Volvo')
INSERT INTO [dbo].[Brands] ([BrandId], [BrandName]) VALUES (12, N'Mazda')
INSERT INTO [dbo].[Brands] ([BrandId], [BrandName]) VALUES (13, N'Tesla')
INSERT INTO [dbo].[Brands] ([BrandId], [BrandName]) VALUES (14, N'Fiat')
INSERT INTO [dbo].[Brands] ([BrandId], [BrandName]) VALUES (15, N'Peugeot')
INSERT INTO [dbo].[Brands] ([BrandId], [BrandName]) VALUES (16, N'Renault')
INSERT INTO [dbo].[Brands] ([BrandId], [BrandName]) VALUES (17, N'Citroen')
INSERT INTO [dbo].[Brands] ([BrandId], [BrandName]) VALUES (18, N'Subaru')
SET IDENTITY_INSERT [dbo].[Brands] OFF

--Colors
SET IDENTITY_INSERT [dbo].[Colors] ON
INSERT INTO [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1, N'Black')
INSERT INTO [dbo].[Colors] ([ColorId], [ColorName]) VALUES (2, N'White')
INSERT INTO [dbo].[Colors] ([ColorId], [ColorName]) VALUES (3, N'Blue')
INSERT INTO [dbo].[Colors] ([ColorId], [ColorName]) VALUES (4, N'Red')
INSERT INTO [dbo].[Colors] ([ColorId], [ColorName]) VALUES (5, N'Green')
INSERT INTO [dbo].[Colors] ([ColorId], [ColorName]) VALUES (6, N'Grey')
INSERT INTO [dbo].[Colors] ([ColorId], [ColorName]) VALUES (7, N'Orange')
INSERT INTO [dbo].[Colors] ([ColorId], [ColorName]) VALUES (8, N'Dark Blue')
SET IDENTITY_INSERT [dbo].[Colors] OFF

--Cars

SET IDENTITY_INSERT [dbo].[Cars] ON
INSERT INTO [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [CarDescription]) VALUES (1, 1, 1, N'2018-01-01', CAST(560000.0000 AS Money), N'2018 Mercedes-AMG® GT C Coupe')
INSERT INTO [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [CarDescription]) VALUES (2, 1, 2, N'2018-01-01', CAST(540000.0000 AS Money), N'2018 Mercedes-AMG® GT C Coupe')
SET IDENTITY_INSERT [dbo].[Cars] OFF

