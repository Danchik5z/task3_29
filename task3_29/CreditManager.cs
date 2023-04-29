namespace task3_29;

public class CreditManager
{
    private List<Credit> _credits;

    public CreditManager()
    {
        _credits = new List<Credit>();
    }

    public void AddCredit(Credit credit)
    {
        _credits.Add(credit);
    }

    public List<Credit> FindCredits(double loanAmount, int loanTerm)
    {
        List<Credit> matchingCredits = new List<Credit>();

        foreach (Credit credit in _credits)
        {
            if (credit.LoanAmount >= loanAmount && credit.LoanTerm >= loanTerm)
            {
                matchingCredits.Add(credit);
            }
        }

        return matchingCredits;
    }

    public Credit SelectCredit(List<Credit> matchingCredits, bool allowEarlyRepayment, bool allowCreditLineIncrease)
    {
        Credit selectedCredit = null;
        double lowestTotalPayment = double.MaxValue;

        foreach (Credit credit in matchingCredits)
        {
            double totalPayment = credit.CalculateTotalPayment();
            if (allowEarlyRepayment && allowCreditLineIncrease)
            {
                if (totalPayment < lowestTotalPayment)
                {
                    lowestTotalPayment = totalPayment;
                    selectedCredit = credit;
                }
            }
            else if (allowEarlyRepayment)
            {
                if (totalPayment < lowestTotalPayment && credit.InterestRate >= 0.1)
                {
                    lowestTotalPayment = totalPayment;
                    selectedCredit = credit;
                }
            }
            else if (allowCreditLineIncrease)
            {
                if (totalPayment < lowestTotalPayment && credit.InterestRate < 0.1)
                {
                    lowestTotalPayment = totalPayment;
                    selectedCredit = credit;
                }
            }
        }

        return selectedCredit;
    }
}