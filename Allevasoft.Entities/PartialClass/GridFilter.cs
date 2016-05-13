using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allevasoft.Entities.Classes
{
    public class GridFilter
    {
        public int limit { get; set; }
        public int offset { get; set; }
        public string order { get; set; }
        public string sort { get; set; }
        public string search { get; set; }
    }

    public class LogInfoListFilters : GridFilter
    {
        public string SearchText { get; set; }
        public string ModuleName { get; set; }
        public string FieldName { get; set; }
        public string ModifiedBy { get; set; }
    }
    public class LogInfoReturnVal
    {
        public IEnumerable<LogInfo> LogsData;
        public int total;
    }
}
