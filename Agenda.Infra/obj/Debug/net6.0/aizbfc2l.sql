IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Eventos] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(20) NOT NULL,
    [Data] datetime2 NOT NULL,
    [Descricao] varchar(100) NOT NULL,
    [CodigoCorEvento] varchar(10) NULL,
    CONSTRAINT [PK_Eventos] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221116200928_Initial-Create', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Eventos] ADD [UsuarioId] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [UsuarioTeste] (
    [Id] int NOT NULL IDENTITY,
    [NomeUsuario] nvarchar(max) NULL,
    [NomeCompleto] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    CONSTRAINT [PK_UsuarioTeste] PRIMARY KEY ([Id])
);
GO

CREATE INDEX [IX_Eventos_UsuarioId] ON [Eventos] ([UsuarioId]);
GO

ALTER TABLE [Eventos] ADD CONSTRAINT [FK_Eventos_UsuarioTeste_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [UsuarioTeste] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221121213542_Second-Database', N'6.0.10');
GO

COMMIT;
GO

