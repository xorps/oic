using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oic
{
    public struct FormularyID
    {
        private readonly ulong id;

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

        public int ToInt()
        {
            return Convert.ToInt32(id);
        }

        public static bool operator ==(FormularyID a, FormularyID b)
        {
            return a.id == b.id;
        }

        public static bool operator !=(FormularyID a, FormularyID b)
        {
            return a.id != b.id;
        }

        public override bool Equals(object obj)
        {
            throw new InvalidOperationException();
        }

        public override int GetHashCode()
        {
            throw new InvalidOperationException();
        }
    }
}
