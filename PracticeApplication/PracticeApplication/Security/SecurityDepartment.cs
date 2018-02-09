using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApplication
{
    public class SecurityDepartment
    {
        public int departmentId { get; set; }
        public string departmentName { get; set; }
        public IList<SecurityRoom> Values { get;set;}
    }
}
