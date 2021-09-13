using Events.Repository.Pocos;
using Events.TestHelpers.Data;

namespace Events.MappersTests.TestData
{
    public class UserPocoToDtoDataCollection : ClassDataBase<User>
    {
        public UserPocoToDtoDataCollection() :
            base(new[]
            {
                Create(1, "username", "email", "firstnamssse", "latnameassa", "paswrdasas"),
                Create(2, "usernames", "emailaaas", "firstname", "latname", "paswrd"),
                Create(3, "usernamsse", "email@aaa", "firstname", "latname", "paswrd123123")
            })
        {
        }

        private static User Create(int userId, string username, string email, string firstName, string lastName, string password)
        {
            return new User
            {
                UserId = userId,
                UserName = username,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Password = password
            };
        }
    }
}