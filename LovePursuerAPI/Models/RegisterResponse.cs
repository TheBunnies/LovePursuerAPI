namespace LovePursuerAPI.Models
{
    public class RegisterResponse
    {
        public string Email { get;  }
        public string FirstName { get;  }
        public string LastName { get;  }
        public string Sex { get; }
        public RegisterResponse(string email, string firstName, string lastName, string sex)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Sex = sex;
        }
    }
}