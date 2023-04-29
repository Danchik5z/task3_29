using task3_29;

CreditManager manager = new CreditManager();

// добавляем кредиты
Credit credit1 = new Credit { BankName = "Сбербанк", InterestRate = 0.12, LoanAmount = 100000, LoanTerm = 12 };
Credit credit2 = new Credit { BankName = "Альфа-банк", InterestRate = 0.11, LoanAmount = 150000, LoanTerm = 24 };
Credit credit3 = new Credit { BankName = "ВТБ", InterestRate = 0.13, LoanAmount = 200000, LoanTerm = 36 };

manager.AddCredit(credit1);
manager.AddCredit(credit2);
manager.AddCredit(credit3);

// ищем доступные кредиты
List<Credit> matchingCredits = manager.FindCredits(120000, 18);

// выбираем оптимальный кредит с возможностью досрочного погашения
Credit selectedCredit = manager.SelectCredit(matchingCredits, true, false);

Console.WriteLine("Выбранный кредит: " + selectedCredit.BankName);
Console.WriteLine("Ежемесячный платеж: " + selectedCredit.CalculateMonthlyPayment());
Console.WriteLine("Общая сумма выплат: " + selectedCredit.CalculateTotalPayment());