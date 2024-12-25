using DesignPattern;
using System;


class Program {
    public static void Main(string[] args) {

        var fromEmployee =  Singleton.GetInstance;
        Singleton.PrintDetails("This is first Message");

        var fromstudent = Singleton.GetInstance;
        Singleton.PrintDetails("This is from Student");
        Console.ReadLine();


}
        
}

