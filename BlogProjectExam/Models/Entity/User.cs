using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace BlogProjectExam.Models.Entity
{
    [Table("Users")]
    public class User
    {
        public User() { }

        public User(string name, string lastname,string username,string password, string email)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            LastName = lastname ?? throw new ArgumentNullException(nameof(lastname));
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }
        public User(int id,string name, string lastname, string username, string password, string email)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            LastName = lastname ?? throw new ArgumentNullException(nameof(lastname));
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
    }
}
