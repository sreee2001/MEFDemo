using Interfaces.Services;
using Services;
using System.ComponentModel.Composition;

namespace WalmartServices
{
    [Export(typeof(IEmployeeService))]
    [ExportMetadata("CompanyName", "Walmart")]

    public class WalmartEmployeeService: EmployeeService
    {
    }
}
