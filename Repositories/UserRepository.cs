using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository
    {
        private SqlConnection _connection = new SqlConnection("");

        public void CreateUser(User user)
            => _connection.Insert(user);

        public IEnumerable<User> GetAll()
            => _connection.GetAll<User>();

        public User Get(int id)
            => _connection.Get<User>(id);

        public void UpdateUser(User user)
            => _connection.Update(user);

        public void DeleteUser(int id)
        {
            var user = _connection.Get<User>(id);
            _connection.Delete(user);
        }
    }
}
