namespace LovePursuerAPI.Models
{
    public class RegisterResponse
    {
        public RegisterResponse(string username, string firstName, string lastName)
        {
            Username = username;
            FirstName = firstName;
            LastName = lastName;
        }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}