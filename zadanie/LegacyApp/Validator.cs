using System;

namespace LegacyApp;

public class Validator
{
    public static bool ValidateUserData(string firstName, string secondName, string email, DateTime dateOfBirth)
    {
        return ValidateName(firstName) &&
               ValidateName(secondName) &&
               ValidateEmail(email) &&
               ValidateAge(dateOfBirth);
    }

    private static bool ValidateName(string name)
    {
        return !string.IsNullOrEmpty(name);
    }

    private static bool ValidateEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }

    private static bool ValidateAge(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        
        int age = now.Year - dateOfBirth.Year;
        
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

        return age >= 21;
    }

    public static bool IsMeetingCreditRequirements(User user)
    {
        return !(user.HasCreditLimit && user.CreditLimit < 500);
    }
}