using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj
{
    internal class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<Employee> GetValues(int Id)
        {
            List<Employee> values = new List<Employee>();
            return values.Where(x => x.ID == Id).ToList();
        }

        
    }
}
