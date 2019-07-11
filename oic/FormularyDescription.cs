using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oic
{
    using static Result<FormularyDescription, string>;

    public struct FormularyDescription
    {
        private readonly string description;

        private FormularyDescription(string description) => this.description = description;

        public override string ToString() => description;

        public static Result<FormularyDescription, string> Create(string description) =>
            (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description)) ? Error("Description must be non-empty") : Ok(new FormularyDescription(description));
    }
}
