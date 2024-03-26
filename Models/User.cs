using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[User]")]
    public class User : Base
    {

        public User()
        {

        }

        public User(string name, string email, string passwordHash, string bio, string image, string slug)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            Bio = bio;
            Image = image;
            Slug = slug;
        }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;

        [Write(false)]
        public List<Role> Roles { get; set; } = new List<Role>();
    }
}
