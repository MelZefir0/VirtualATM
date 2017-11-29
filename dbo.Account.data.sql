SET IDENTITY_INSERT [dbo].[Account] ON
INSERT INTO [dbo].[Account] ([AccountId], [AccountHolderId], [AccountType], [Balance]) VALUES (30, 1, N'SAVINGS', CAST(3000.0000 AS Money))
INSERT INTO [dbo].[Account] ([AccountId], [AccountHolderId], [AccountType], [Balance]) VALUES (32, 7, N'SAVINGS', CAST(86765.0000 AS Money))
INSERT INTO [dbo].[Account] ([AccountId], [AccountHolderId], [AccountType], [Balance]) VALUES (33, 9, N'SAVINGS', CAST(67564.0000 AS Money))
INSERT INTO [dbo].[Account] ([AccountId], [AccountHolderId], [AccountType], [Balance]) VALUES (34, 3, N'CHECKING', CAST(2398688.0000 AS Money))
INSERT INTO [dbo].[Account] ([AccountId], [AccountHolderId], [AccountType], [Balance]) VALUES (35, 1, N'CHECKING', CAST(9000000000.0000 AS Money))
SET IDENTITY_INSERT [dbo].[Account] OFF
