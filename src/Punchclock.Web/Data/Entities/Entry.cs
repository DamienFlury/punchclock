using System;

namespace Punchclock.Web.Data.Entities
{
    public class Entry
    {
        public long Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}