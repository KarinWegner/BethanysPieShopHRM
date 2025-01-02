using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Components.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }
        protected override async void OnInitialized()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(EmployeeId);
        }
        private void ChangeHolidayState()
        {
            Employee.IsOnHoliday = !Employee.IsOnHoliday;
        }
    }
}
