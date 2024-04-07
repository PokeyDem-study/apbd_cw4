using System;

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
                    using (var userCreditService = new UserCreditService())
                    {
                        int creditLimit = userCreditService.GetCreditLimit(LastName, DateOfBirth);
                        creditLimit *= 2;
                        CreditLimit = creditLimit;
                    }
                    break;
                
                default:
                    HasCreditLimit = true;
                    using (var userCreditService = new UserCreditService())
                    {
                        int creditLimit = userCreditService.GetCreditLimit(LastName, DateOfBirth);
                        CreditLimit = creditLimit;
                    }
                    break;
            }
        }

        public bool IsMeetingCreditRequirements()
        {
            return !(HasCreditLimit && CreditLimit < 500);
        }
    }
}