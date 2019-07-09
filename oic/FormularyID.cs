using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oic
{
    public struct FormularyID
    {
        private ulong id;

        public FormularyID(ulong id)
        {
            this.id = id;
        }

        public FormularyID(int id)
        {
            this.id = Convert.ToUInt64(id);
        }

        public FormularyID(long id)
        {
            this.id = Convert.ToUInt64(id);
        }

        public override string ToString()
        {
            return id.ToString();
        }
    }
}
