SET IDENTITY_INSERT [dbo].[virksomheder] ON
INSERT INTO [dbo].[virksomheder] ([VirksomhedID], [CVR], [Virksomhedsnavn], [KontaktPerson], [Email], [Password], [Beskrivelse]) VALUES (1, N'42356789', N'Bubbles', N'Torben Jensen', N'bubbles@bubbles.dk', N'Bubbles1!', NULL)
INSERT INTO [dbo].[virksomheder] ([VirksomhedID], [CVR], [Virksomhedsnavn], [KontaktPerson], [Email], [Password], [Beskrivelse]) VALUES (2, N'34127865', N'Hildas Beer bar', N'Jytte Sørensen', N'jytte@hildasbeerbar.dk', N'HildasBeer2!', NULL)
INSERT INTO [dbo].[virksomheder] ([VirksomhedID], [CVR], [Virksomhedsnavn], [KontaktPerson], [Email], [Password], [Beskrivelse]) VALUES (3, N'56349865', N'Jazz it up', N'Simone Nielsen', N'info@jazzitup.com', N'Jazzitup3!', NULL)
INSERT INTO [dbo].[virksomheder] ([VirksomhedID], [CVR], [Virksomhedsnavn], [KontaktPerson], [Email], [Password], [Beskrivelse]) VALUES (4, N'67895432', N'Wine & Dine', N'Lars Clausen', N'wine@dine.com', N'Wine&dine4', NULL)
SET IDENTITY_INSERT [dbo].[virksomheder] OFF
