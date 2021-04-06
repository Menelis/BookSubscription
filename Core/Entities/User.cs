namespace Core.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public User() { }

        public User(string firstName, string lastName, string email, string username, string passwordHash = null, string id = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = username;
            PasswordHash = passwordHash;
            Id = id;            
        }
    }
}
