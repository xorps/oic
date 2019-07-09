using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oic
{
    public class FormularyItem
    {
        public FormularyID ID { get; private set; }
        public FormularyDescription Description { get; private set; }

        public FormularyItem(FormularyID ID, FormularyDescription Description)
        {
            this.ID = ID;
            this.Description = Description;
        }
    }
}
