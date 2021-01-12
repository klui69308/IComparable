using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Patient : IComparable
    {
        //Create a class named Patient that has the following data members: 
        //patient number(int), use a full accessor implementation, not automatic accessors.
        //patient name(string), use a full accessor implementation, not automatic accessors.
        //patient age(int), use a full accessor implementation, not automatic accessors.
        //amount due(double) from patient, use a full accessor implementation, not automatic accessors.
        protected int id;
        protected string name;
        protected int age;
        protected double amountDue;
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }
        public double AmountDue
        {
            get
            {
                return this.amountDue;
            }
            set
            {
                this.amountDue = value;
            }
        }
        //A class constructor that assigns default values of patient number = 9, name = "ZZZ", patient age = 0, patient amount due = 0.
        public Patient()
        {
            Id = 9;
            Name = "ZZZ";
            Age = 0;
            AmountDue = 0;
        }
        //A class constructor that takes four parameters to assign input values by way of the accessors for patient number, name, age, amount due.
        public Patient(int id, string name, int age, double amountDue)
        {
            Id = id;
            Name = name;
            Age = age;
            AmountDue = amountDue;
        }
        //The patient class should be set up so that its objects are comparable to each other based on object patient numbers (implement IComparable) 
        //and can be sorted by patient id number.  This means you will also have to override the object GetHashCode method and override the Equals(Object e)
        //class method to compare two patient objects by patient number.
        public int CompareTo(object obj)
        {
            Patient otherPatient = (Patient)(obj);
            return this.id.CompareTo(otherPatient.id);
        }
        public override bool Equals(object obj)
        {
            Patient patient = (Patient)(obj);
            if (this.id == patient.id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //You will override the patient object ToString method.  The overridden ToString method will return a string output as shown in the output example. 
        //You will return a string to the Console.Writeline in Main that will use the object GetType() method to display "Patient" followed by the patient 
        //number, name, age, and amount due formatted as currency as shown in the output example. 
        public override int GetHashCode()
        {
            return this.id;
        }
        public override string ToString()
        {
            return this.GetType().Name + " " + this.GetHashCode() + 
                   " " + this.name + " " + this.age + " " + 
                   "AmountDue is " + string.Format("{0:C2}", this.AmountDue,2);
        }
    }
    class Assignment5_Lui
    {
        
        static void Main(string[] args)
        {
            //instantiate an array of five (5) Patient objects.
            Patient[] patients = new Patient[5];
            //Implement a for-loop that will instantiate each Patient object in turn and assign it to an array element
            for (int i = 0; i < 5; i++)
            {
                Patient patient = new Patient();
                Console.Write("Enter patient number ");
                patient.Id= int.Parse(Console.ReadLine());
                patients[i] = patient;
                bool isDuplicate = false;
                //If it is a duplicate then implement a while loop that will prompt the user that the id entered is a duplicate and to reenter a valid patient 
                //id; then check again using Equals to compare the number entered to the other patient object id numbers entered in the array.
                do
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (patients[j].Equals(patients[i]) == true)
                        {
                            isDuplicate = true;
                            Console.WriteLine("Sorry, the patient number {0} is a duplicate.", patient.Id);
                            Console.Write("Please reenter ");
                            patient.Id = Convert.ToInt16(Console.ReadLine());
                            patients[i] = patient;
                        }
                        else
                        {
                            isDuplicate = patients[j].Equals(patients[i]);
                        }
                    }
                } while (isDuplicate == true);
                //once a valid id number is entered then request entries for the name, age and amount due for the current Patient object.
                Console.Write("Enter name ");
                patient.Name = Console.ReadLine();
                Console.Write("Enter age ");
                patient.Age = Convert.ToInt16(Console.ReadLine());
                Console.Write("Enter amount due ");
                patient.AmountDue = Convert.ToDouble(Console.ReadLine());
            }
            //Once all five Patient array objects have been entered you will sort the array of objects by patient id number.
            Array.Sort(patients);
            //Write an output line that will give the header "Payment Information".
            Console.WriteLine("\nPayment Information:\n");
            //Implement a for-loop that will call the static GetPaymentAmount method passing the each (this pointer) object in the Patient object array
            foreach (var obj in patients)
            {
                //use a console write to implement the overridden Patient object ToString method (see output example).
                //use a write line to display "Quarterly payment is " followed by the payment extracted from the current object payment due.
                Console.Write(obj.ToString());
                GetPaymentAmount(obj.AmountDue);
            }
        }
        public static void GetPaymentAmount(double amountDue)
        {
            //set a constant for the number of quarters in a year equal to 4.
            const double NumOfQuarter = 4.0;
            double payment;
            payment = amountDue / NumOfQuarter;
            Console.WriteLine(" Quarterly payment is {0}", payment);
        }
    }
}
