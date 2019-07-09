using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oic
{
    public struct FormularyDescription
    {
        private readonly string description;

        public class InvalidException : FormatException
        {
            public readonly string HelpText = "Description must be non-empty";
        }

        public FormularyDescription(string description)
        {
            if (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description))
            {
                throw new InvalidException();
            }

            this.description = description;
        }

        public override string ToString()
        {
            return description;
        }
    }
}
