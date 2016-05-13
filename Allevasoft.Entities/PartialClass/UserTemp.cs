using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allevasoft.Entities.Classes
{
    public partial class UserTemp
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public Int32 UserId { get; set; }
    }
    public partial class ErrorLog
    {
        public long Id { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionMessage { get; set; }
        public string CustomErrorMessage { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<long> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
    }
}
