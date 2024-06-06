using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace BMS.Infrastructure.DB;

public class DBConnection
{
    public static SqlConnectionStringBuilder ConnectionBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = "DESKTOP-1U67J66",     // server name
        InitialCatalog = "BMS",     // database name
        UserID = "sa",                         //user name
        Password = "sa@123",                  //server password
        TrustServerCertificate = true,
    };
}
