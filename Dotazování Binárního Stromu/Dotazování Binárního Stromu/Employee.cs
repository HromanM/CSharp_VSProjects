using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotazování_Binárního_Stromu
{
    class Employee : IComparable<Employee>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Deparement { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return String.Format("Id: {0}, Jméno: {1} {2}, Odd.: {3}",
                    this.Id, this.Name, this.Surname, this.Deparement);
        }

        int IComparable<Employee>.CompareTo(Employee other)
        {
            if (other == null)
                return 1;
            if (this.Id > other.Id)
                return 1;
            if (this.Id < other.Id)
                return -1;
            return 0;
        }
    }
}
