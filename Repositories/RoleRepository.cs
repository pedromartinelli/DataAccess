using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class RoleRepository
    {

        private readonly SqlConnection _connection;

        public RoleRepository(SqlConnection connection)
            => _connection = connection;

        public void Create(Role role)
            => _connection.Insert(role);

        public IEnumerable<Role> GetAll()
            => _connection.GetAll<Role>();

        public Role Get(int id)
            => _connection.Get<Role>(id);

        public void Update(Role role)
        {
            if (role.Id != 0) _connection.Update(role);
        }

        public void Delete(Role role)
        {
            if (role.Id != 0) _connection.Delete(role);
        }

        public void Delete(int id)
        {
            if (id == 0) return;

            var role = _connection.Get<Role>(id);
            _connection.Delete(role);
        }
    }
}
