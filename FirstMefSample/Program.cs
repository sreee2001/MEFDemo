using System;
using System.Linq;

namespace FirstMefSample
{

    static class Program
    {
        static void Main(string[] args)
        {
            // Composition is performed in the constructor
            var provider = new ExtensibilityProvider();

            Console.WriteLine("Demo of Mef Capabilities!");
            Console.WriteLine();

            // get an instance of IBaseEntity
            var allEmployeeServices  = provider.EmployeeServices;

            // set properties
            Console.WriteLine($"Total Employee Services Found: {allEmployeeServices.Count()}");
            Console.WriteLine("List of Employee Services");
            foreach (var employeeService in allEmployeeServices)
            {
                Console.WriteLine($"Employee Service: {employeeService.Metadata.CompanyName}");
            }
            Console.WriteLine();

            // Get Starbucks Employee Service
            var starBucksEmployeeService = allEmployeeServices.Where(x => x.Metadata.CompanyName == "Starbucks").FirstOrDefault();

            // add employees to the Starbucks Employee Service
            Console.WriteLine("Adding Employees to Starbucks Employee Service...");

            starBucksEmployeeService.Value.AddEmployee(1, "Employee One");
            starBucksEmployeeService.Value.AddEmployee(2, "Employee Two");

            // Fetch and print all employees from Starbucks Employee Service
            Console.WriteLine("Fetching all employees from Starbucks Employee Service");
            // print the entity 
            foreach (var entity in starBucksEmployeeService.Value.GetAllEmployees())
            {
                Console.WriteLine(entity.ToString());
            }
        }


    }
}
