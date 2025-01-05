using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Components.Model
{
    internal class AddTag
    {
      public string Tag { get; set; }

        public AddTag(string tag)
        {
            Tag = tag;
        }
    }
}
