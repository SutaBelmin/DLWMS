USE [DLWMS_sos]
GO
SET IDENTITY_INSERT [dbo].[Fakulteti] ON 
GO
INSERT [dbo].[Fakulteti] ([ID], [Naziv], [Grad]) VALUES (1, N'Fakultet Informacijskih Tehnologija', N'Mostar')
GO
INSERT [dbo].[Fakulteti] ([ID], [Naziv], [Grad]) VALUES (2, N'Gradjevinski fakultet', N'Mostar')
GO
INSERT [dbo].[Fakulteti] ([ID], [Naziv], [Grad]) VALUES (3, N'Pravni fakultet', N'Mostar')
GO
INSERT [dbo].[Fakulteti] ([ID], [Naziv], [Grad]) VALUES (4, N'Agromediteranski fakultet', N'Mostar')
GO
INSERT [dbo].[Fakulteti] ([ID], [Naziv], [Grad]) VALUES (5, N'Poljoprivredni fakultet', N'Mostar')
GO
INSERT [dbo].[Fakulteti] ([ID], [Naziv], [Grad]) VALUES (6, N'Medincinski fakultet', N'Mostar')
GO
INSERT [dbo].[Fakulteti] ([ID], [Naziv], [Grad]) VALUES (7, N'Masinski fakultet', N'Mostar')
GO
SET IDENTITY_INSERT [dbo].[Fakulteti] OFF
GO
SET IDENTITY_INSERT [dbo].[KorisnickiNalog] ON 
GO
INSERT [dbo].[KorisnickiNalog] ([ID], [KorisnickoIme], [Lozinka], [Ime], [Prezime], [Vrsta_Korisnika], [DatumRodjenja], [DatumPrijave], [DLWMS_email], [Privatni_email], [FakultetID], [Discriminator]) VALUES (24, N'adi', N'adi', N'Adi', N'Hodzic', 0, CAST(N'2021-12-04T15:32:52.1870000' AS DateTime2), CAST(N'2021-12-04T15:32:52.1870000' AS DateTime2), NULL, N'adihodzic94@gmail.com', 1, N'Korisnik')
GO
INSERT [dbo].[KorisnickiNalog] ([ID], [KorisnickoIme], [Lozinka], [Ime], [Prezime], [Vrsta_Korisnika], [DatumRodjenja], [DatumPrijave], [DLWMS_email], [Privatni_email], [FakultetID], [Discriminator]) VALUES (25, N'adil', N'adil', N'Adil', N'Joldic', 1, CAST(N'2021-12-04T15:32:52.1870000' AS DateTime2), CAST(N'2021-12-04T15:32:52.1870000' AS DateTime2), NULL, NULL, 1, N'Korisnik')
GO
SET IDENTITY_INSERT [dbo].[KorisnickiNalog] OFF
GO
