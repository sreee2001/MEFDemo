using System;

namespace FirstMefSample
{

    static class Program
    {
        static void Main(string[] args)
        {
            // Composition is performed in the constructor
            var provider = new ExtensibilityProvider();

            Console.WriteLine("Demo of Mef Capabilities!");
            Console.WriteLine("Entity is of type IBaseEntity from Interfaces Library, implemented in Models");

            // get an instance of IBaseEntity
            var starbucksEmployeeService  = provider.StarbucksEmployeeService;

            // set properties
            starbucksEmployeeService.AddEmployee(1, "Employee One");
            starbucksEmployeeService.AddEmployee(2, "Employee Two");

            // print the entity 
            foreach (var entity in starbucksEmployeeService.GetAllEmployees())
            {
                Console.WriteLine(entity.ToString());
            }
        }


    }
}
