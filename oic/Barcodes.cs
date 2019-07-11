using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oic
{
    public class Barcodes
    {
        public interface AddResult
        {
            T Match<T>(Func<T> Ok, Func<T> BarcodeInUse);
            void Foreach(Action Ok, Action BarcodeInUse);
        }

        private class Ok : AddResult
        {
            public T Match<T>(Func<T> Ok, Func<T> BarcodeInUse) => Ok();
            public void Foreach(Action Ok, Action BarcodeInUse) => Ok();
        }

        private class BarcodeInUse : AddResult
        {
            public T Match<T>(Func<T> Ok, Func<T> BarcodeInUse) => BarcodeInUse();
            public void Foreach(Action Ok, Action BarcodeInUse) => BarcodeInUse();
        }

        private List<Barcode> barcodes = new List<Barcode>();

        public AddResult Add(Barcode barcode)
        {
            if (barcodes.Any(it => it.Data == barcode.Data))
            {
                return new BarcodeInUse();
            }

            barcodes.Add(barcode);

            return new Ok();
        }

        public IEnumerable<Barcode> AllFor(FormularyID id)
        {
            return barcodes.Where(it => it.FormularyID == id);
        }
    }
}
