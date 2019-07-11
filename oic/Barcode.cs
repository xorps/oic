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

        private Barcode(FormularyID id, string data)
        {
            if (string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data))
            {
                throw new InvalidBarcodeException();
            }
            this.FormularyID = id;
            this.Data = data;
        }

        public interface Result
        {
            T Match<T>(Func<Barcode, T> Ok, Func<T> Error);
            void Foreach(Action<Barcode> Ok, Action Error);
        }

        private class Ok : Result
        {
            private readonly Barcode barcode;

            public Ok(Barcode barcode) => this.barcode = barcode;

            public T Match<T>(Func<Barcode, T> Ok, Func<T> Error) => Ok(barcode);

            public void Foreach(Action<Barcode> Ok, Action Error) => Ok(barcode);
        }

        private class Error : Result
        {
            public T Match<T>(Func<Barcode, T> Ok, Func<T> Error) => Error();
            public void Foreach(Action<Barcode> Ok, Action Error) => Error();
        }

        public static Result Create(FormularyID id, string data)
        {
            if (string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data))
            {
                return new Error();
            }

            return new Ok(new Barcode(id, data));
        }

        public static Result Create(FormularyItem item, string data) => Create(item.ID, data);
    }
}
