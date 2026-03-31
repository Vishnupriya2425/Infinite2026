
using System;


class BaseDisplay { 

    public void ShowHeader(string title)
    {
        Console.WriteLine("\n====================================");
        Console.WriteLine(title);
        Console.WriteLine("====================================");
    }
}


class Accounts : BaseDisplay
{
    private int accountNo;
    private string customerName;
    private string accountType;
    private double balance;

    public Accounts(int accNo, string custName, string accType, double bal)
    {
        accountNo = accNo;
        customerName = custName;
        accountType = accType;
        balance = bal;
    }

    public void Credit(double amount)
    {
        balance += amount;
        Console.WriteLine("Deposited: " + amount);
    }

    public void Debit(double amount)
    {
        if (amount > balance)
            Console.WriteLine("Insufficient Balance!");
        else
        {
            balance -= amount;
            Console.WriteLine("Withdrawn: " + amount);
        }
    }

    public void UpdateBalance(char transactionType, double amount)
    {
        if (transactionType == 'D' || transactionType == 'd')
            Credit(amount);
        else if (transactionType == 'W' || transactionType == 'w')
            Debit(amount);
        else
            Console.WriteLine("Invalid Transaction Type!");
    }

    public void ShowData()
    {
        ShowHeader("ACCOUNT DETAILS");
        Console.WriteLine("Account No: " + accountNo);
        Console.WriteLine("Customer Name: " + customerName);
        Console.WriteLine("Account Type: " + accountType);
        Console.WriteLine("Balance: " + balance);
    }
}


class Student : BaseDisplay
{
    private int rollNo;
    private string name;
    private string className;
    private int semester;
    private string branch;
    private int[] marks = new int[5];

    public Student(int rno, string name, string cls, int sem, string br)
    {
        rollNo = rno;
        this.name = name;
        className = cls;
        semester = sem;
        branch = br;
    }

    public void GetMarks()
    {
        Console.WriteLine("\nEnter 5 subject marks:");
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Mark {i + 1}: ");
            marks[i] = Convert.ToInt32(Console.ReadLine());
        }
    }

    public void DisplayResult()
    {
        int total = 0;
        bool fail = false;

        for (int i = 0; i < 5; i++)
        {
            if (marks[i] < 35)
                fail = true;

            total += marks[i];
        }

        double avg = total / 5.0;

        Console.WriteLine("\nAverage Marks: " + avg);

        if (fail)
            Console.WriteLine("Result: FAILED (One or more subjects < 35)");
        else if (avg < 50)
            Console.WriteLine("Result: FAILED (Average < 50)");
        else
            Console.WriteLine("Result: PASSED");
    }

    public void DisplayData()
    {
        ShowHeader("STUDENT DETAILS");
        Console.WriteLine("Roll No: " + rollNo);
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Class: " + className);
        Console.WriteLine("Semester: " + semester);
        Console.WriteLine("Branch: " + branch);

        Console.WriteLine("Marks: " + string.Join(", ", marks));
    }
}


class SaleDetails : BaseDisplay
{
    private int salesNo;
    private int productNo;
    private double price;
    private int qty;
    private string dateOfSale;
    private double totalAmount;

    public SaleDetails(int sNo, int pNo, double price, int qty, string date)
    {
        salesNo = sNo;
        productNo = pNo;
        this.price = price;
        this.qty = qty;
        dateOfSale = date;
    }

    public void Sales()
    {
        totalAmount = price * qty;
    }

    public void ShowData()
    {
        ShowHeader("SALE DETAILS");
        Console.WriteLine("Sales No: " + salesNo);
        Console.WriteLine("Product No: " + productNo);
        Console.WriteLine("Price: " + price);
        Console.WriteLine("Quantity: " + qty);
        Console.WriteLine("Date of Sale: " + dateOfSale);
        Console.WriteLine("Total Amount: " + totalAmount);
    }
}


class Program
{
    static void Main(string[] args)
    {
        Accounts acc = new Accounts(101, "Vishnu", "Savings", 5000);
        acc.UpdateBalance('D', 2000);
        acc.UpdateBalance('W', 1500);
        acc.ShowData();

        Student stu = new Student(1, "Priya", "BSc", 3, "CSE");
        stu.GetMarks();
        stu.DisplayData();
        stu.DisplayResult();

        SaleDetails sale = new SaleDetails(1001, 501, 250.50, 4, "31-03-2026");
        sale.Sales();
        sale.ShowData();

        Console.WriteLine("\nProgram Completed.");
    }
}
