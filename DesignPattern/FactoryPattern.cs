using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public abstract class FactoryPattern
    {
        public string Name { get; set; }
        public int HoursWorked { get; set; }

        public abstract decimal CalculateBonus();
    }
    public class PermanentEmployee : FactoryPattern
    {
        public override decimal CalculateBonus()
        {
            // Permanent employees get a fixed bonus of 20% of hours worked
            return HoursWorked * 20;
        }
    }

    public class ContractEmployee : FactoryPattern
    {
        public override decimal CalculateBonus()
        {
            // Contract employees get a fixed bonus of 10% of hours worked
            return HoursWorked * 10;
        }
    }

    // Step 3: Create the Factory Class
    public static class EmployeeFactory
    {
        public static FactoryPattern CreateEmployee(string employeeType, string name, int hoursWorked)
        {
            switch (employeeType.ToLower())
            {
                case "permanent":
                    return new PermanentEmployee { Name = name, HoursWorked = hoursWorked };
                case "contract":
                    return new ContractEmployee { Name = name, HoursWorked = hoursWorked };
                default:
                    throw new ArgumentException("Invalid employee type");
            }
        }
    }
}
