using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oic
{
    public class Formulary
    {
        private readonly List<FormularyItemInternal> items = new List<FormularyItemInternal>();

        public FormularyItem Add(FormularyDescription description)
        {
            items.Add(new FormularyItemInternal { Description = description });

            return new FormularyItem(new FormularyID(items.Count - 1), description);
        }

        public IEnumerable<FormularyItem> All()
        {
            for (int i = 0; i < items.Count; i++)
            {
                yield return new FormularyItem(new FormularyID(i), items[i].Description);
            }
        }

        public FormularyItem UpdateDescription(FormularyItem item, FormularyDescription newDescription)
        {
            this.items[item.ID.ToInt()].Description = newDescription;

            return new FormularyItem(item.ID, newDescription);
        }
    }
}
