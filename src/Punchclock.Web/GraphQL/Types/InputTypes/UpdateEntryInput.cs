using System;

namespace Punchclock.Web.GraphQL.Types.InputTypes
{
    public class UpdateEntryInput
    {
        public long Id { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public string? EmployeeId { get; set; }
    }
}