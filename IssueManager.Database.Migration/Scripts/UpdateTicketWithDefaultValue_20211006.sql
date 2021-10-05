BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tickets]') AND [c].[name] = N'UpdatedAt');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Tickets] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Tickets] ALTER COLUMN [UpdatedAt] datetime2 NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Statuses]') AND [c].[name] = N'UpdatedAt');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Statuses] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Statuses] ALTER COLUMN [UpdatedAt] datetime2 NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Attachments]') AND [c].[name] = N'UpdatedAt');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Attachments] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Attachments] ALTER COLUMN [UpdatedAt] datetime2 NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211005230835_UpdateTicketDefaultValues', N'5.0.9');
GO

COMMIT;
GO


