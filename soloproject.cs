using System;
using System.Collections.Generic;
public class Contractor
{
    public string Name { get; set; }
    public int ContractorNumber { get; set; }
    public DateTime StartDate { get; set; }

    public Contractor() { }

    public Contractor(string name, int contractorNumber, DateTime startDate)
    {
        Name = name;
        ContractorNumber = contractorNumber;
        StartDate = startDate;
    }
}
public class Subcontractor : Contractor
{
    public int Shift { get; set; } // 1 = Day, 2 = Night
    public double HourlyPayRate { get; set; }

    public Subcontractor() { }

    public Subcontractor(string name, int contractorNumber, DateTime startDate, int shift, double hourlyPayRate)
        : base(name, contractorNumber, startDate)
    {
        Shift = shift;
        HourlyPayRate = hourlyPayRate;
    }

    public float CalculatePay(int hoursWorked)
    {
        double pay = HourlyPayRate * hoursWorked;
        if (Shift == 2)
        {
            pay *= 1.03; // 3% differential
        }
        return (float)pay;
    }
}

 
class Program
{
    static void Main(string[] args)
    {
        List<Subcontractor> subcontractors = new List<Subcontractor>();
 
        Console.WriteLine("Subcontractor Manager");
 
        while (true)
        {
            Console.Write("Enter subcontractor name (or type 'exit' to finish): ");
            string name = Console.ReadLine();
            if (name.ToLower() == "exit") break;
 
            Console.Write("Enter contractor number: ");
            int number = int.Parse(Console.ReadLine());
 
            Console.Write("Enter start date (YYYY-MM-DD): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
 
            Console.Write("Enter shift (1 = Day, 2 = Night): ");
            int shift = int.Parse(Console.ReadLine());
 
            Console.Write("Enter hourly pay rate: ");
            double payRate = double.Parse(Console.ReadLine());
 
            Console.Write("Enter hours worked: ");
            int hours = int.Parse(Console.ReadLine());
 
            Subcontractor s = new Subcontractor(name, number, startDate, shift, payRate);
            subcontractors.Add(s);
 
            float pay = s.CalculatePay(hours);
            Console.WriteLine($"Total pay for {name}: ${pay:F2}\n");
        }
 
        Console.WriteLine("\n--- Subcontractor Summary ---");
        foreach (var s in subcontractors)
        {
            Console.WriteLine($"{s.Name} (#{s.ContractorNumber}) - Shift {s.Shift} - Start: {s.StartDate.ToShortDateString()} - Pay Rate: ${s.HourlyPayRate:F2}");
        }
    }
}