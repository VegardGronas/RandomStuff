using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class TestClass
    {
        private string name = string.Empty;

        public TestClass(string name)
        {
            this.name = name;
        }

        public string TellMyName()
        {
            return "My name is " + name;
        }
    }
}
