using Allevasoft.Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allevasoft.Services
{
    public interface ILeadService
    {
        long AddLead(LeadInfo _lead);
        List<LeadInfo> GetLeadsList(int limit, int offset, string order, string sort, string searchText, string firstName, string lastName, out int total);
    }
}
