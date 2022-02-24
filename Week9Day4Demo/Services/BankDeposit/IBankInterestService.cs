namespace Week9Day4Demo.Services.BankDeposit
{
    public interface IBankInterestService
    {
        public double Calculate(int principle, int numberOfYears, double rateOfInterest);
    }
}
