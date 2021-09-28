using System;

namespace LovePursuerAPI.Models.Responses
{
    public class MatchResponse
    {
        public string FirstName { get;}
        public string LastName { get; }
        public string Sex { get; }
        public string Sexuality { get; }
        public int Age { get; }
        public DateTime BirthDay { get; }

        public MatchResponse(string firstName, string lastName, string sex, string sexuality, int age, DateTime birthDay)
        {
            FirstName = firstName;
            LastName = lastName;
            Sex = sex;
            Sexuality = sexuality;
            Age = age;
            BirthDay = birthDay;
        }
    }
}