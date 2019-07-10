using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oic
{
    public class Barcode
    {
        public class InvalidBarcodeException : ArgumentException { }
        public FormularyID FormularyID { get; private set; }
        public string Data { get; private set; }

        public Barcode(FormularyID id, string data)
        {
            if (string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data))
            {
                throw new InvalidBarcodeException();
            }
            this.FormularyID = id;
            this.Data = data;
        }
    }
}
