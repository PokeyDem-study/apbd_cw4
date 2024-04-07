using System;

namespace LegacyApp;

public class Validator
{
    public bool ValidateUserData(string firstName, string secondName, string email, DateTime dateOfBirth)
    {
        return ValidateName(firstName) &&
               ValidateName(secondName) &&
               ValidateEmail(email) &&
               ValidateAge(dateOfBirth);
    }

    public bool ValidateName(string name)
    {
        return string.IsNullOrEmpty(name);
    }

    public bool ValidateEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }

    public bool ValidateAge(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        
        int age = now.Year - dateOfBirth.Year;
        
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

        return age >= 21;
    }
}