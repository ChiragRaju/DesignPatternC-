using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class AbstractFactory
    {
        public abstract class Employee
        {
            public string Name { get; set; }
            public int HoursWorked { get; set; }
            public abstract decimal CalculateBonus();
        }

        // Step 2: Implement Concrete Employee Types
        public class PermanentEmployee : Employee
        {
            public override decimal CalculateBonus()
            {
                return HoursWorked * 20; // 20% bonus per hour worked
            }
        }

        public class ContractEmployee : Employee
        {
            public override decimal CalculateBonus()
            {
                return HoursWorked * 10; // 10% bonus per hour worked
            }
        }

        // Step 3: Define Abstract Factory Interface
        public interface IEmployeeFactory
        {
            Employee CreateEmployee(string name, int hoursWorked);
        }

        // Step 4: Implement Concrete Factories
        public class PermanentEmployeeFactory : IEmployeeFactory
        {
            public Employee CreateEmployee(string name, int hoursWorked)
            {
                return new PermanentEmployee { Name = name, HoursWorked = hoursWorked };
            }
        }

        public class ContractEmployeeFactory : IEmployeeFactory
        {
            public Employee CreateEmployee(string name, int hoursWorked)
            {
                return new ContractEmployee { Name = name, HoursWorked = hoursWorked };
            }
        }

        // Step 5: Usage
        class Program
        {
            static void Main()
            {
                // Create a Permanent Employee using the Abstract Factory
                IEmployeeFactory permanentFactory = new PermanentEmployeeFactory();
                Employee permanentEmployee = permanentFactory.CreateEmployee("Alice", 40);
                Console.WriteLine($"{permanentEmployee.Name} Bonus: {permanentEmployee.CalculateBonus()}");
                // Output: Alice Bonus: 800

                // Create a Contract Employee using the Abstract Factory
                IEmployeeFactory contractFactory = new ContractEmployeeFactory();
                Employee contractEmployee = contractFactory.CreateEmployee("Bob", 40);
                Console.WriteLine($"{contractEmployee.Name} Bonus: {contractEmployee.CalculateBonus()}");
                // Output: Bob Bonus: 400
            }
        }
        }
}
