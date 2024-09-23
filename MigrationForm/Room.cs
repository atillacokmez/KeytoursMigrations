using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationForm
{
    public class Room
    {
        public List<Person> Adult { get; set; }
        public List<Person> Child { get; set; }

        public int MinChildAge() => this.Child.Min(m => m.Age);

        public int MaxChildAge() => this.Child.Max(m => m.Age);
    }
}
