namespace LegacyApp;

public interface IUserCreditDefiner
{
    public void DefineCreditLimits(string clientType);

    public bool IsMeetingCreditRequirements();
}