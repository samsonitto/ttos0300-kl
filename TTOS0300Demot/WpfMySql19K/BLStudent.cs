using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTOS0300
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AsioID { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
