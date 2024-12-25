using DesignPattern;
using System;


class Program {
    public static void Main(string[] args) {

        var fromEmployee =  Singleton.GetInstance;
        Singleton.PrintDetails("This is first Message");

        var fromstudent = Singleton.GetInstance;
        Singleton.PrintDetails("This is from Student");
        Console.ReadLine();


        FactoryPattern permanentEmployee = EmployeeFactory.CreateEmployee("permanent", "John", 160);
        FactoryPattern contractEmployee = EmployeeFactory.CreateEmployee("contract", "Jane", 120);

        // Display details
        Console.WriteLine($"Employee: {permanentEmployee.Name}, Type: Permanent, Hours Worked: {permanentEmployee.HoursWorked}, Bonus: {permanentEmployee.CalculateBonus()}");
        Console.WriteLine($"Employee: {contractEmployee.Name}, Type: Contract, Hours Worked: {contractEmployee.HoursWorked}, Bonus: {contractEmployee.CalculateBonus()}");
    }


}
        
}

