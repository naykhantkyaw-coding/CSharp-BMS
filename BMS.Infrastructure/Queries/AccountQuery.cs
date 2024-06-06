namespace BMS.Infrastructure.Queries;

internal class AccountQuery
{
    public static string InsertQuery { get; } = @"INSERT INTO [dbo].[Tbl_Account]
                                           ([AccountNo]
                                           ,[CustomerNo]
                                           ,[AccountType]
                                           ,[Balance]
                                           ,[Password])
                                     VALUES
                                           (@AccountNo
                                           ,@CustomerNo
                                           ,@AccountType
                                           ,@Balance
                                           ,@Password)";

    public static string SelectAllQuery { get; } = @"SELECT [AccountId]
                                              ,[AccountNo]
                                              ,[CustomerNo]
                                              ,[AccountType]
                                              ,[Balance]
                                              ,[Password]
                                          FROM [dbo].[Tbl_Account]";

    public static string SelectQuery { get; } = @"SELECT [AccountId]
                                              ,[AccountNo]
                                              ,[CustomerNo]
                                              ,[AccountType]
                                              ,[Balance]
                                              ,[Password]
                                          FROM [dbo].[Tbl_Account]
                                          WHERE AccountId = @AccountId";

    public static string UpdateQuery { get; } = @"UPDATE [dbo].[Tbl_Account]
                                           SET [AccountNo] = @AccountNo
                                              ,[CustomerNo] = @CustomerNo
                                              ,[AccountType] = @AccountType
                                              ,[Balance] = @Balance
                                              ,[Password] = @Password
                                         WHERE AccountId = @AccountId";

    public static string DeleteQuery { get; } = @"DELETE FROM [dbo].[Tbl_Account]
                                            WHERE AccountId = @AccountId";
}
