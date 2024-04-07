using System;
using System.Dynamic;

namespace LegacyApp
{
    public class User : IUserCreditDefiner
    {
        public object Client { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }
        public void DefineCreditLimits(string clientType)
        {
            
            switch (clientType)
            {
                case "VeryImportantClient":
                    HasCreditLimit = false;
                    break;
                
                case "ImportantClient":
                    int creditLimit = GetCreditLimit();
                    creditLimit *= 2;
                    CreditLimit = creditLimit;
                    break;
                
                default:
                    HasCreditLimit = true;
                    CreditLimit = GetCreditLimit();
                    break;
            }
        }

        public int GetCreditLimit()
        {
            using (var userCreditService = new UserCreditService())
                return userCreditService.GetCreditLimit(LastName, DateOfBirth);
        }
    }
}