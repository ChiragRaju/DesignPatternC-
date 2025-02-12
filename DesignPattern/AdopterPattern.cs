using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{

    // The Adapter Pattern is a structural design pattern that allows two incompatible interfaces to work together by creating a bridge (adapter) between them. It acts as a wrapper that translates the interface of a class into another interface that the client expects.


    //Adaptee 
    public interface IWeightMachinePounds
    {
        double GetWeight();
    }

    //concreate class 
    public class WeightMachinePounds : IWeightMachinePounds
    {
        public double GetWeight()
        {
            return 150;
        }
    }

    public interface IWeightMachineKgs
    {
        double GetWeightKgs();
    }


    public class WeightMachineAdapter : IWeightMachineKgs
    {
        private readonly IWeightMachinePounds _weightMachinePounds;
        public WeightMachineAdapter(IWeightMachinePounds weightMachinePounds)
        {
            _weightMachinePounds = weightMachinePounds;
        }
        public double GetWeightKgs()
        {
            double ConvertPoundsToWeights = _weightMachinePounds.GetWeight();
            return ConvertPoundsToWeights * 0.433;
        }
    }

    class AdaptorPattern
    {
        static void Main(string[] args)
        {
            // Using Adapter to get weight in Kg
            IWeightMachinePounds weightMachine = new WeightMachinePounds();
            IWeightMachineKgs weightMachineAdapter = new WeightMachineAdapter(weightMachine);

            Console.WriteLine("Weight in Pounds: " + weightMachine.GetWeight());
            Console.WriteLine("Weight in Kg: " + weightMachineAdapter.GetWeightKgs());
        }
    }
}

      //┌──────────────────────┐
      //│ IWeightMachine       │  (Target Interface)
      //│  + GetWeightInKg()   │
      //└──────────────────────┘
      //       ▲
      //       │
      //┌──────────────────────┐
      //│ WeightMachineAdapter │  (Adapter)
      //│ + GetWeightInKg()    │ ---> Converts lbs to kg
      //└──────────────────────┘
      //       ▲
      //       │
      //┌──────────────────────┐
      //│ IWeightMachineLbs    │  (Adaptee Interface)
      //│ + GetWeightInPounds()│
      //└──────────────────────┘
      //       ▲
      //       │
      //┌──────────────────────┐
      //│ WeightMachine        │  (Adaptee)
      //│ + GetWeightInPounds()│ ---> Returns weight in lbs
      //└──────────────────────┘
