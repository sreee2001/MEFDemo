using Interfaces.Entities;
using Interfaces.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace FirstMefSample
{
    public class ExtensibilityProvider
    {
        //[Import(typeof(IEmployeeService))]
        //private IEmployeeService _employeeService; // Note: MEF Binding only supports field injection

        [ImportMany]
        IEnumerable<Lazy<IEmployeeService, ICompanyData>> _employeeServices; // Note: MEF Binding only supports field injection


        public IEnumerable<Lazy<IEmployeeService, ICompanyData>> EmployeeServices => _employeeServices;

        public ExtensibilityProvider()
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();

            //Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new AssemblyCatalog(GetType().Assembly));
            
            // Adds all the parts found in the Models assembly
            //catalog.Catalogs.Add(new AssemblyCatalog(typeof(Entity).Assembly));
            
            // catalog.Catalogs.Add(new DirectoryCatalog(extensionsPath));
            // Scan a directory and add all libraries (DLLs) to the catalog
            var extensionsPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Extensions");
            if (System.IO.Directory.Exists(extensionsPath))
            {
                 catalog.Catalogs.Add(new DirectoryCatalog(extensionsPath, "*.dll"));
            }


            //Create the CompositionContainer with the parts in the catalog
            var container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }
    }
}
