-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

-- ************************************** [dbo].[WithdrawalStatus]

CREATE TABLE [dbo].[WithdrawalStatus]
(
 [ID]   int IDENTITY (1, 1) NOT NULL ,
 [Name] varchar(50) NOT NULL ,

 CONSTRAINT [PK_WithdrawalStatus] PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO








-- ************************************** [dbo].[WalletAccountCategories]

CREATE TABLE [dbo].[WalletAccountCategories]
(
 [ID]                  int IDENTITY (1, 1) NOT NULL ,
 [Name]                varchar(50) NOT NULL ,
 [RegistrationDefault] bit NOT NULL CONSTRAINT [DF_WalletAccountCategories_RegistrationDefault] DEFAULT 0 ,
 [CreatedAt]           datetime NOT NULL CONSTRAINT [DF_WalletCategories_CreatedAt] DEFAULT GETDATE() ,
 [UpdatedAt]           datetime NOT NULL CONSTRAINT [DF_WalletCategories_UpdatedAt] DEFAULT GETDATE() ,

 CONSTRAINT [PK_WalletCategories] PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO








-- ************************************** [dbo].[TransaferStatuses]

CREATE TABLE [dbo].[TransaferStatuses]
(
 [ID]   int IDENTITY (1, 1) NOT NULL ,
 [Name] varchar(50) NOT NULL ,

 CONSTRAINT [PK_TransaferStatuses] PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO








-- ************************************** [dbo].[TransactionTypes]

CREATE TABLE [dbo].[TransactionTypes]
(
 [ID]        int IDENTITY (1, 1) NOT NULL ,
 [Name]      varchar(50) NOT NULL ,
 [CreatedAt] datetime NOT NULL CONSTRAINT [DF_TransactionTypes_CreatedAt] DEFAULT GETDATE() ,
 [UpdatedAt] datetime NOT NULL CONSTRAINT [DF_TransactionTypes_UpdatedAt] DEFAULT GETDATE() ,

 CONSTRAINT [PK_TransactionTypes] PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO








-- ************************************** [dbo].[TransactionStatuses]

CREATE TABLE [dbo].[TransactionStatuses]
(
 [ID]   int IDENTITY (1, 1) NOT NULL ,
 [Name] varchar(50) NOT NULL ,

 CONSTRAINT [PK_TransactionStatus] PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO








-- ************************************** [dbo].[PaymentMethods]

CREATE TABLE [dbo].[PaymentMethods]
(
 [ID]              int IDENTITY (1, 1) NOT NULL ,
 [Name]            varchar(50) NOT NULL ,
 [Icon]            varchar(255) NULL ,
 [ExternalCharges] decimal(3,2) NOT NULL ,
 [InternalCharges] decimal(3,2) NOT NULL ,
 [AllowDeposit]    bit NOT NULL CONSTRAINT [DF_PaymentMethods_AllowDeposit] DEFAULT 0 ,
 [AllowTransfer]   bit NOT NULL CONSTRAINT [DF_PaymentMethods_AllowTransfer] DEFAULT 0 ,
 [AllowWithdrawal] bit NOT NULL CONSTRAINT [DF_PaymentMethods_AllowWithdrawal] DEFAULT 0 ,
 [CreatedAt]       datetime NOT NULL CONSTRAINT [DF_PaymentMethods_CreatedAt] DEFAULT GETDATE() ,
 [UpdatedAt]       datetime NOT NULL CONSTRAINT [DF_PaymentMethods_UpdatedAt] DEFAULT GETDATE() ,

 CONSTRAINT [PK_PaymentMethods] PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO








-- ************************************** [dbo].[Currencies]

CREATE TABLE [dbo].[Currencies]
(
 [ID]                int IDENTITY (1, 1) NOT NULL ,
 [Name]              varchar(50) NOT NULL ,
 [Symbol]            varchar(3) NOT NULL ,
 [Code]              varchar(4) NOT NULL ,
 [AddOnRegistration] bit NOT NULL CONSTRAINT [DF_Currencies_AddOnRegistration] DEFAULT 0 ,
 [CreatedAt]         datetime NOT NULL CONSTRAINT [DF_Currencies_CreatedAt] DEFAULT GETDATE() ,
 [UpdatedAt]         datetime NOT NULL CONSTRAINT [DF_Currencies_UpdatedAt] DEFAULT GETDATE() ,

 CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO








-- ************************************** [dbo].[Countries]

CREATE TABLE [dbo].[Countries]
(
 [ID]                int IDENTITY (1, 1) NOT NULL ,
 [DefaultCurrencyID] int NOT NULL ,
 [Name]              varchar(50) NOT NULL ,
 [Code]              varchar(50) NOT NULL ,
 [PhoneCode]         varchar(5) NOT NULL ,
 [CreatedAt]         datetime NOT NULL CONSTRAINT [DF_Countries_CreatedAt] DEFAULT GETDATE() ,
 [UpdatedAt]         datetime NOT NULL CONSTRAINT [DF_Countries_UpdatedAt] DEFAULT GETDATE() ,

 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED ([ID] ASC),
 CONSTRAINT [FK_Countries_DefaultCurrencyID] FOREIGN KEY ([DefaultCurrencyID])  REFERENCES [dbo].[Currencies]([ID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_Countries_DefaultCurrencyID] ON [dbo].[Countries] 
 (
  [DefaultCurrencyID] ASC
 )

GO







-- ************************************** [dbo].[Users]

CREATE TABLE [dbo].[Users]
(
 [ID]           int IDENTITY (1, 1) NOT NULL ,
 [CountryID]    int NOT NULL ,
 [FirstName]    varchar(50) NOT NULL ,
 [LastName]     varchar(50) NOT NULL ,
 [Email]        varchar(50) NULL ,
 [Password]     varchar(100) NOT NULL ,
 [Phone]        varchar(20) NULL ,
 [DateOfBirth]  varchar(20) NOT NULL ,
 [AddressLine1] varchar(50) NOT NULL ,
 [AddressLine2] varchar(50) NOT NULL ,
 [IsActive]     bit NOT NULL CONSTRAINT [DF_Users_IsActive] DEFAULT 0 ,
 [CreatedAt]    datetime NOT NULL CONSTRAINT [DF_Users_CreatedAt] DEFAULT GETDATE() ,
 [UpdatedAt]    datetime NOT NULL CONSTRAINT [DF_Users_UpdatedAt] DEFAULT GETDATE() ,

 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([ID] ASC),
 CONSTRAINT [FK_Users_CountryID] FOREIGN KEY ([CountryID])  REFERENCES [dbo].[Countries]([ID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_Users_CountryID] ON [dbo].[Users] 
 (
  [CountryID] ASC
 )

GO







-- ************************************** [dbo].[WalletAccounts]

CREATE TABLE [dbo].[WalletAccounts]
(
 [ID]                      int IDENTITY (1, 1) NOT NULL ,
 [UserID]                  int NOT NULL ,
 [CurrencyID]              int NOT NULL ,
 [WalletAccountCategoryID] int NOT NULL ,
 [WalletAccountCode]       varchar(50) NOT NULL ,
 [Name]                    varchar(50) NOT NULL ,
 [Balance]                 money NOT NULL CONSTRAINT [DF_Wallets_Balance] DEFAULT 0 ,
 [IsDefault]               bit NOT NULL CONSTRAINT [DF_Wallets_IsDefault] DEFAULT 0 ,
 [CreatedAt]               datetime NOT NULL CONSTRAINT [DF_Wallets_CreatedAt] DEFAULT GETDATE() ,
 [UpdatedAt]               datetime NOT NULL CONSTRAINT [DF_Wallets_UpdatedAt] DEFAULT GETDATE() ,

 CONSTRAINT [PK_Wallets] PRIMARY KEY CLUSTERED ([ID] ASC),
 CONSTRAINT [Ind_wallets_walletCode] UNIQUE NONCLUSTERED ([WalletAccountCode] ASC),
 CONSTRAINT [FK_Wallets_CurrencyID] FOREIGN KEY ([CurrencyID])  REFERENCES [dbo].[Currencies]([ID]),
 CONSTRAINT [FK_Wallets_UserID] FOREIGN KEY ([UserID])  REFERENCES [dbo].[Users]([ID]),
 CONSTRAINT [FK_Wallets_WalletCategoryID] FOREIGN KEY ([WalletAccountCategoryID])  REFERENCES [dbo].[WalletAccountCategories]([ID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_Wallets_CurrencyID] ON [dbo].[WalletAccounts] 
 (
  [CurrencyID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_Wallets_UserID] ON [dbo].[WalletAccounts] 
 (
  [UserID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_Wallets_WalletCategoryID] ON [dbo].[WalletAccounts] 
 (
  [WalletAccountCategoryID] ASC
 )

GO







-- ************************************** [dbo].[UserSettings]

CREATE TABLE [dbo].[UserSettings]
(
 [ID]                             int IDENTITY (1, 1) NOT NULL ,
 [UserID]                         int NOT NULL ,
 [LowBalanceNotifyAmount]         money NOT NULL ,
 [MinimumTransactionNotifyAmount] money NOT NULL ,
 [AcceptedMarketingNotifications] bit NOT NULL CONSTRAINT [DF_UserSettings_AcceptedMarketingNotifications] DEFAULT 0 ,
 [TwoStepAuthEnabled]             bit NOT NULL CONSTRAINT [DF_UserSettings_TwoStepAuthEnabled] DEFAULT 0 ,

 CONSTRAINT [PK_UserSettings] PRIMARY KEY CLUSTERED ([ID] ASC),
 CONSTRAINT [FK_UserSettings_UserID] FOREIGN KEY ([UserID])  REFERENCES [dbo].[Users]([ID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_UserSettings_UserID] ON [dbo].[UserSettings] 
 (
  [UserID] ASC
 )

GO







-- ************************************** [dbo].[TrustedDevices]

CREATE TABLE [dbo].[TrustedDevices]
(
 [ID]     int IDENTITY (1, 1) NOT NULL ,
 [UserID] int NOT NULL ,
 [Name]   varchar(50) NOT NULL ,
 [IP]     varchar(50) NOT NULL ,

 CONSTRAINT [PK_TrustedDevices] PRIMARY KEY CLUSTERED ([ID] ASC),
 CONSTRAINT [FK_TrustedDevices_UserID] FOREIGN KEY ([UserID])  REFERENCES [dbo].[Users]([ID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_TrustedDevices_UserID] ON [dbo].[TrustedDevices] 
 (
  [UserID] ASC
 )

GO







-- ************************************** [dbo].[Transactions]

CREATE TABLE [dbo].[Transactions]
(
 [ID]                  int IDENTITY (1, 1) NOT NULL ,
 [UserID]              int NOT NULL ,
 [TransactionTypeID]   int NOT NULL ,
 [PaymentMethodID]     int NOT NULL ,
 [TransactionStatusID] int NOT NULL ,
 [AmountBeforeCharges] money NOT NULL ,
 [Charges]             money NOT NULL ,
 [AmountAfterCharges]  money NOT NULL ,
 [CreatedAt]           datetime NOT NULL ,
 [UpdatedAt]           datetime NOT NULL ,

 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([ID] ASC),
 CONSTRAINT [FK_Transactions_PaymentMethodID] FOREIGN KEY ([PaymentMethodID])  REFERENCES [dbo].[PaymentMethods]([ID]),
 CONSTRAINT [FK_Transactions_TransactionStatusID] FOREIGN KEY ([TransactionStatusID])  REFERENCES [dbo].[TransactionStatuses]([ID]),
 CONSTRAINT [FK_Transactions_TransactionTypeID] FOREIGN KEY ([TransactionTypeID])  REFERENCES [dbo].[TransactionTypes]([ID]),
 CONSTRAINT [FK_Transactions_UserID] FOREIGN KEY ([UserID])  REFERENCES [dbo].[Users]([ID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_Transactions_PaymentMethodID] ON [dbo].[Transactions] 
 (
  [PaymentMethodID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_Transactions_TransactionStatusID] ON [dbo].[Transactions] 
 (
  [TransactionStatusID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_Transactions_TransactionTypeID] ON [dbo].[Transactions] 
 (
  [TransactionTypeID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_Transactions_UserID] ON [dbo].[Transactions] 
 (
  [UserID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [Ind_Transactions_CreatedAt] ON [dbo].[Transactions] 
 (
  [CreatedAt] ASC
 )

GO







-- ************************************** [dbo].[SavedPaymentMethods]

CREATE TABLE [dbo].[SavedPaymentMethods]
(
 [ID]             int IDENTITY (1, 1) NOT NULL ,
 [UserID]         int NOT NULL ,
 [Balance]        money NOT NULL CONSTRAINT [DF_SavedPaymentMethods_Balance] DEFAULT 0 ,
 [MethodIdentity] varchar(50) NOT NULL ,
 [MethodPassword] varchar(50) NOT NULL ,
 [CreatedAt]      datetime NOT NULL CONSTRAINT [DF_SavedPaymentMethods_CreatedAt] DEFAULT GETDATE() ,
 [UpdatedAt]      datetime NOT NULL CONSTRAINT [DF_SavedPaymentMethods_UpdatedAt] DEFAULT GETDATE() ,

 CONSTRAINT [PK_SavedPaymentMethods] PRIMARY KEY CLUSTERED ([ID] ASC),
 CONSTRAINT [FK_SavedPaymentMethods_UserID] FOREIGN KEY ([UserID])  REFERENCES [dbo].[Users]([ID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_SavedPaymentMethods_UserID] ON [dbo].[SavedPaymentMethods] 
 (
  [UserID] ASC
 )

GO







-- ************************************** [dbo].[SavedCards]

CREATE TABLE [dbo].[SavedCards]
(
 [ID]           int IDENTITY (1, 1) NOT NULL ,
 [UserID]       int NOT NULL ,
 [CardType]     varchar(50) NOT NULL ,
 [MaskedNumber] varchar(50) NOT NULL ,
 [ExpiryDate]   varchar(20) NOT NULL ,
 [CreatedAt]    datetime NOT NULL CONSTRAINT [DF_SavedCards_CreatedAt] DEFAULT GETDATE() ,
 [UpdatedAt]    datetime NOT NULL CONSTRAINT [DF_SavedCards_UpdatedAt] DEFAULT GETDATE() ,

 CONSTRAINT [PK_SavedCards] PRIMARY KEY CLUSTERED ([ID] ASC),
 CONSTRAINT [FK_SavedCards_UserID] FOREIGN KEY ([UserID])  REFERENCES [dbo].[Users]([ID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_SavedCards_UserID] ON [dbo].[SavedCards] 
 (
  [UserID] ASC
 )

GO







-- ************************************** [dbo].[Recipients]

CREATE TABLE [dbo].[Recipients]
(
 [ID]        int IDENTITY (1, 1) NOT NULL ,
 [UserID]    int NOT NULL ,
 [FirstName] varchar(50) NOT NULL ,
 [LastName]  varchar(50) NOT NULL ,
 [Email]     varchar(50) NULL ,
 [Phone]     varchar(20) NULL ,
 [CreatedAt] datetime NOT NULL CONSTRAINT [DF_Recipients_CreatedAt] DEFAULT GETDATE() ,
 [UpdatedAt] datetime NOT NULL CONSTRAINT [DF_Recipients_UpdatedAt] DEFAULT GETDATE() ,

 CONSTRAINT [PK_Recipients] PRIMARY KEY CLUSTERED ([ID] ASC),
 CONSTRAINT [FK_Recipients_UserID] FOREIGN KEY ([UserID])  REFERENCES [dbo].[Users]([ID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_Recipients_UserID] ON [dbo].[Recipients] 
 (
  [UserID] ASC
 )

GO







-- ************************************** [dbo].[BankAccounts]

CREATE TABLE [dbo].[BankAccounts]
(
 [ID]           int IDENTITY (1, 1) NOT NULL ,
 [UserID]       int NOT NULL ,
 [IsDefault]    bit NOT NULL CONSTRAINT [DF_BankAccounts_IsDefault] DEFAULT 0 ,
 [Beneficiary]  varchar(50) NOT NULL ,
 [Name]         varchar(50) NOT NULL ,
 [Number]       varchar(50) NOT NULL ,
 [IBANumber]    varchar(50) NOT NULL ,
 [SwiftCode]    varchar(50) NOT NULL ,
 [Currency]     varchar(50) NOT NULL ,
 [AddressLine1] varchar(50) NULL ,
 [AddressLine2] varchar(50) NULL ,
 [City]         varchar(50) NOT NULL ,
 [Country]      varchar(50) NOT NULL ,
 [CreatedAt]    datetime NOT NULL CONSTRAINT [DF_BankAccounts_CreatedAt] DEFAULT GETDATE() ,
 [UpdatedAt]    datetime NOT NULL CONSTRAINT [DF_BankAccounts_UpdatedAt] DEFAULT GETDATE() ,

 CONSTRAINT [PK_BankAccounts] PRIMARY KEY CLUSTERED ([ID] ASC),
 CONSTRAINT [FK_BankAccounts_UserID] FOREIGN KEY ([UserID])  REFERENCES [dbo].[Users]([ID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_BankAccounts_UserID] ON [dbo].[BankAccounts] 
 (
  [UserID] ASC
 )

GO







-- ************************************** [dbo].[WithdrawalRequests]

CREATE TABLE [dbo].[WithdrawalRequests]
(
 [ID]                 int IDENTITY (1, 1) NOT NULL ,
 [UserID]             int NOT NULL ,
 [WithdrawalStatusID] int NOT NULL ,
 [TransactionID]      int NOT NULL ,

 CONSTRAINT [PK_WithdrawalRequests] PRIMARY KEY CLUSTERED ([ID] ASC),
 CONSTRAINT [FK_WithdrawalRequests_TransactionID] FOREIGN KEY ([TransactionID])  REFERENCES [dbo].[Transactions]([ID]),
 CONSTRAINT [FK_WithdrawalRequests_UserID] FOREIGN KEY ([UserID])  REFERENCES [dbo].[Users]([ID]),
 CONSTRAINT [FK_WithdrawalRequests_WithdrawalStatusID] FOREIGN KEY ([WithdrawalStatusID])  REFERENCES [dbo].[WithdrawalStatus]([ID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_WithdrawalRequests_TransactionID] ON [dbo].[WithdrawalRequests] 
 (
  [TransactionID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_WithdrawalRequests_UserID] ON [dbo].[WithdrawalRequests] 
 (
  [UserID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_WithdrawalRequests_WithdrawalStatusID] ON [dbo].[WithdrawalRequests] 
 (
  [WithdrawalStatusID] ASC
 )

GO







-- ************************************** [dbo].[Transfers]

CREATE TABLE [dbo].[Transfers]
(
 [ID]               int IDENTITY (1, 1) NOT NULL ,
 [TransactionID]    int NOT NULL ,
 [TransferStatusID] int NOT NULL ,
 [ToEmail]          varchar(50) NULL ,
 [ToPhone]          varchar(20) NULL ,
 [CreatedAt]        datetime NOT NULL CONSTRAINT [DF_Transfers_CreatedAt] DEFAULT GETDATE() ,
 [UpdatedAt]        datetime NOT NULL CONSTRAINT [DF_Transfers_UpdatedAt] DEFAULT GETDATE() ,

 CONSTRAINT [PK_Transfers] PRIMARY KEY CLUSTERED ([ID] ASC),
 CONSTRAINT [FK_Transafers_TransferStatusID] FOREIGN KEY ([TransferStatusID])  REFERENCES [dbo].[TransaferStatuses]([ID]),
 CONSTRAINT [FK_Transfers_TransactionID] FOREIGN KEY ([TransactionID])  REFERENCES [dbo].[Transactions]([ID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_Transafers_TransferStatusID] ON [dbo].[Transfers] 
 (
  [TransferStatusID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_Transfers_TransactionID] ON [dbo].[Transfers] 
 (
  [TransactionID] ASC
 )

GO







