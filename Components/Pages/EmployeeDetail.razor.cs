using BethanysPieShopHRM.BethanysPieShopHRM.Shared.Domain;
using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace BethanysPieShopHRM.Components.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();
        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }
        public List<TimeRegistration> TimeRegistrations { get; set; } = [];

        [Inject]
        public ITimeRegistrationService TimeRegistrationService { get; set; }
        private float itemHeight = 50;
        protected async override  Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(EmployeeId);
            TimeRegistrations = await TimeRegistrationService.GetTimeRegistrationsForEmployee(EmployeeId);
        }
        public async ValueTask<ItemsProviderResult<TimeRegistration>>
            LoadTimeRegistrations(ItemsProviderRequest request)
        {
            int totalNumberOfTimeRegistrations = await TimeRegistrationService.GetTimeRegistrationCountForEmployeeId(EmployeeId);
            var numberOfTimeRegistrations = Math.Min(request.Count, totalNumberOfTimeRegistrations - request.StartIndex);
            var listItems = await TimeRegistrationService.GetPagedTimeRegistrationsForEmployee(EmployeeId, numberOfTimeRegistrations, request.StartIndex);
            return new ItemsProviderResult<TimeRegistration>(listItems, totalNumberOfTimeRegistrations);
        }
        private void ChangeHolidayState()
        {
            Employee.IsOnHoliday = !Employee.IsOnHoliday;
        }
    }
}
