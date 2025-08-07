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
            Console.WriteLine();

            Console.WriteLine("List of Employee Services");
            foreach (var employeeService in allEmployeeServices)
            {
                Console.WriteLine($"Employee Service: {employeeService.Metadata.CompanyName}");
                Console.WriteLine();
                // add employees to the Employee Service
                Console.WriteLine($"Adding Two Employees to {employeeService.Metadata.CompanyName} Employee Service...");

                employeeService.Value.AddEmployee(1, $"{employeeService.Metadata.CompanyName} Employee One");
                employeeService.Value.AddEmployee(2, $"{employeeService.Metadata.CompanyName} Employee Two");
                
                Console.WriteLine();

                // Fetch and print all employees from Employee Service
                Console.WriteLine($"Fetching all employees from {employeeService.Metadata.CompanyName} Employee Service");
                // print the entity 
                foreach (var entity in employeeService.Value.GetAllEmployees())
                {
                    Console.WriteLine(entity.ToString());
                }
            }
            Console.WriteLine();
        }


    }
}
