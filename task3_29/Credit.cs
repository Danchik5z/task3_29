namespace task3_29;

public class Credit
{
    public string BankName { get; set; }
    public double InterestRate { get; set; }
    public double LoanAmount { get; set; }
    public int LoanTerm { get; set; }

    public double CalculateMonthlyPayment()
    {
        double monthlyInterestRate = InterestRate / 12;
        double numberOfPayments = LoanTerm * 12;

        double monthlyPayment = LoanAmount * monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, numberOfPayments) / (Math.Pow(1 + monthlyInterestRate, numberOfPayments) - 1);

        return monthlyPayment;
    }

    public double CalculateTotalPayment()
    {
        double monthlyPayment = CalculateMonthlyPayment();
        double totalPayment = monthlyPayment * LoanTerm * 12;

        return totalPayment;
    }
}