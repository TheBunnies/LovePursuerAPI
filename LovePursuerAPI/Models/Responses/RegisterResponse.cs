using System;

namespace LovePursuerAPI.Models.Responses
{
    public class RegisterResponse
    {
        public string Email { get;  }
        public string FirstName { get;  }
        public string LastName { get;  }
        public string Sex { get; }
        public string Sexuality { get; }
        public DateTime BirthDay { get; }
        public RegisterResponse(string email, string firstName, string lastName, string sex, string sexuality, DateTime birthDay)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Sex = sex;
            Sexuality = sexuality;
            BirthDay = birthDay;
        }
    }
}