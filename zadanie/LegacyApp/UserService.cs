using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {

            if (!Validator.ValidateUserData(firstName, lastName, email, dateOfBirth))
                return false;

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
            
            user.DefineCreditLimits(client.Type);

            if (!Validator.IsMeetingCreditRequirements(user))
                return false;

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
