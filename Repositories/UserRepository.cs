﻿using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository
    {
        public void CreateUser()
        {
            //var sql = @"
            //    INSERT INTO 
            //        [User] ([Name], [Email], [PasswordHash], [Bio], [Image], [Slug])
            //    VALUES
            //        ( @Name, @Email, @PasswordHash, @Bio, @Image, @Slug )
            //    ";

            var user = new User("Rodrigo Augusto", "rodrigo@email.com", "HASH", "bio", "https://", "rodrigo-augusto");

            using var connection = new SqlConnection(CONNECTION_STRING);

            // Escrevendo sql e utilizando o método Execute do Dapper
            //connection.Execute(sql, new
            //{
            //    user.Name,
            //    user.Email,
            //    user.PasswordHash,
            //    user.Bio,
            //    user.Image,
            //    user.Slug
            //});

            // Utilizando o método Insert do Dapper.Contrib
            connection.Insert<User>(user);

            Console.WriteLine("\n Cadastro realizado com sucesso!");
        }

        public IEnumerable<User> GetAll()
        {
            using var connection = new SqlConnection(CONNECTION_STRING);

            //var sql = @"SELECT [Id], [Name], [Image] FROM [User]";

            // Escrevendo SQL e utilizando o método "Query" do Dapper
            //return connection.Query<User>(sql);

            // Utilizando o método "GetAll" do Dapper.Contrib
            return connection.GetAll<User>();
        }

        public void ReadUser(int userId)
        {
            using var connection = new SqlConnection(CONNECTION_STRING);

            var sql = @"SELECT [Id], [Name] FROM [User] WHERE [Id] = @Id";

            //  Escrevendo SQL e utilizando o método "Query" do Dapper
            var users = connection.Query<User>(sql, new
            {
                Id = userId
            });

            //  Utilizando o método "Get" do Dapper.Contrib
            //var user = connection.Get<User>(userId);
            //Console.WriteLine($"\n {user.Id} - {user.Name}");

            foreach (var user in users)
            {
                Console.WriteLine($"\n{user.Id} - {user.Name}");
            }
        }

        public void UpdateUser()
        {
            //var sql = @"
            //    Update
            //        [User]
            //    SET
            //        [Name] = @Name, [Email] = @Email, [PasswordHash] = @PasswordHash,
            //        [Bio] = @Bio, [Image] = @Image, [Slug] = @Slug
            //    WHERE
            //        [Id] = @Id

            //    ";

            var user = new User("Rodrigo Augusto da Rocha", "rodrigo@email.com", "HASH", "bio", "https://", "rodrigo-augusto");
            user.Id = 7;

            using var connection = new SqlConnection(CONNECTION_STRING);

            //  Escrevendo sql e utilizando o método Execute do Dapper
            //var rows = connection.Execute(sql, new
            //{
            //    user.Id,
            //    user.Name,
            //    user.Email,
            //    user.PasswordHash,
            //    user.Bio,
            //    user.Image,
            //    user.Slug
            //});

            // Utilizando o método Update do Dapper.Contrib
            var rows = connection.Update<User>(user);

            Console.WriteLine($"\n {rows} linha atualizada com sucesso!");
        }

        public void DeleteUser(int userId)
        {
            //var sql = @"DELETE FROM [User] WHERE [Id] = @Id";

            using var connection = new SqlConnection(CONNECTION_STRING);

            //var rows = connection.Execute(sql, new
            //{
            //    Id = userId
            //});

            var user = connection.Get<User>(userId);
            connection.Delete(user);

            Console.WriteLine($"Exclusão realizada com sucesso");
        }
    }
}
