using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog;

class Program
{
    private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e!@#;TrustServerCertificate=true";

    static void Main(string[] args)
    {
        var connection = new SqlConnection(CONNECTION_STRING);
        connection.Open();
        ReadUsers(connection);
        ReadRoles(connection);
        //CreateUser();
        //UpdateUser();
        //DeleteUser(8);
        //ReadUsers();
        //ReadUser(2);
        connection.Close();
    }

    public static void ReadUsers(SqlConnection connection)
    {
        var repository = new UserRepository(connection);
        var users = repository.GetAll();

        foreach (var user in users)
            Console.WriteLine($"\n{user.Id} - {user.Name} - {user.Email}");
    }

    public static void ReadRoles(SqlConnection connection)
    {
        var repository = new RoleRepository(connection);
        var roles = repository.GetAll();

        foreach (var role in roles)
            Console.WriteLine($"\n{role.Id} - {role.Name}");
    }
}