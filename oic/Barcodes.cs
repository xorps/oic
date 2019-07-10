using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oic
{
    public class Barcodes
    {
        public class BarcodeInUseException : ArgumentException { }

        private List<Barcode> barcodes = new List<Barcode>();

        public void Add(Barcode barcode)
        {
            if (barcodes.Any(it => it.Data == barcode.Data))
            {
                throw new BarcodeInUseException();
            }

            barcodes.Add(barcode);
        }

        public IEnumerable<Barcode> AllFor(FormularyID id)
        {
            return barcodes.Where(it => it.FormularyID == id);
        }
    }
}
