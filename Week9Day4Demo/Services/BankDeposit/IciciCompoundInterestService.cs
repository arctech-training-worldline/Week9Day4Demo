namespace Week9Day4Demo.Services.BankDeposit
{
    public class IciciCompoundInterestService : IBankInterestService
    {
        public double Calculate(int principle, int numberOfYears, double rateOfInterest)
        {
            return (principle * numberOfYears * rateOfInterest) / 85;
        }
    }
}
