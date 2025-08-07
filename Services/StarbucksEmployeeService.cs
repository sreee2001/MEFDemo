using Interfaces.Services;
using System.ComponentModel.Composition;

namespace Services
{
    [Export(typeof(IEmployeeService))]
    [ExportMetadata("CompanyName", "Starbucks")]
    public class StarbucksEmployeeService : EmployeeService
    {
        // Additional properties or methods specific to Starbucks employees can be added here
    }
}
