namespace Week9Day4Demo.Services.BankDeposit
{
    public class CompoundInterestService
    {
        public double Calculate(int principle, int numberOfYears, double rateOfInterest)
        {
            return principle * numberOfYears * rateOfInterest / 85;
            //return Math.Pow(principle * (1 + principle / 100), numberOfYears);
        }
    }
}
