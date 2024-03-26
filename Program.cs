using Blog.Models;
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
        //ReadRoles(connection);
        //ReadTags(connection);
        //ReadCategories(connection);
        CreateUser(connection);
        ReadUsers(connection);
        //UpdateUser();
        //DeleteUser(8);
        //ReadUsers();
        //ReadUser(2);
        connection.Close();
    }

    public static void CreateUser(SqlConnection connection)
    {
        var repository = new Repository<User>(connection);
        var user = new User("Rodrigo Nascimento", "rodrigo@email.com", "HASH", "bio", "https://", "rodrigo-nascimento");

        try
        {
            repository.Create(user);
            Console.WriteLine("\n Usuário cadastrado com sucesso!");
        }
        catch
        {
            Console.WriteLine("\n Falha no cadastro de usuário.");
        }
    }

    public static void ReadUsers(SqlConnection connection)
    {
        var repository = new Repository<User>(connection);
        var items = repository.GetAll();

        Console.WriteLine("\n-------- Users --------");
        foreach (var item in items)
            Console.WriteLine($"\n{item.Id} - {item.Name} - {item.Email}");
    }

    public static void ReadRoles(SqlConnection connection)
    {
        var repository = new Repository<Role>(connection);
        var items = repository.GetAll();

        Console.WriteLine("\n-------- Roles --------");
        foreach (var item in items)
            Console.WriteLine($"\n{item.Id} - {item.Name}");
    }

    public static void ReadTags(SqlConnection connection)
    {
        var repository = new Repository<Tag>(connection);
        var items = repository.GetAll();

        Console.WriteLine("\n-------- Tags --------");
        foreach (var item in items)
            Console.WriteLine($"\n{item.Id} - {item.Name}");
    }

    public static void ReadCategories(SqlConnection connection)
    {
        var repository = new Repository<Category>(connection);
        var items = repository.GetAll();

        Console.WriteLine("\n-------- Categories --------");
        foreach (var item in items)
            Console.WriteLine($"\n{item.Id} - {item.Name}");
    }
}