SET IDENTITY_INSERT Account ON

INSERT INTO [dbo].[Account] ([AccountId], [AccountHolderId], [AccountType], [Balance]) VALUES (30, 1, N'SAVINGS', CAST(3000.0000 AS Money))
INSERT INTO [dbo].[Account] ([AccountId], [AccountHolderId], [AccountType], [Balance]) VALUES (31, 2, N'CHECKING', CAST(709483824.0000 AS Money))
INSERT INTO [dbo].[Account] ([AccountId], [AccountHolderId], [AccountType], [Balance]) VALUES (32, 3, N'SAVINGS', CAST(86765.0000 AS Money))
INSERT INTO [dbo].[Account] ([AccountId], [AccountHolderId], [AccountType], [Balance]) VALUES (33, 4, N'SAVINGS', CAST(67564.0000 AS Money))
INSERT INTO [dbo].[Account] ([AccountId], [AccountHolderId], [AccountType], [Balance]) VALUES (34, 5, N'CHECKING', CAST(2398688.0000 AS Money))
INSERT INTO [dbo].[Account] ([AccountId], [AccountHolderId], [AccountType], [Balance]) VALUES (35, 6, N'CHECKING', CAST(9000000000.0000 AS Money))
GO