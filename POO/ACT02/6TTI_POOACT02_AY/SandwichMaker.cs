using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TTI_POOACT02_AY
{
    internal class SandwichMaker
    {
        private string[] _proteine = { "jambon", "fromage", "roast beef", "salami" };
        private string[] _condiments = { "mayonnaise", "moutarde", "ketchup", "sauce barbecue" };
        private string[] _pain = { "pain blanc", "pain complet", "baguette", "pain aux céréales" };
        private string[] _crudites = { "laitue", "tomate", "oignon", "cornichon" };

        public SandwichMaker() { }

        public string ComposeSandwich()
        {
            Random random = new Random();
            string proteine = _proteine[random.Next(_proteine.Length)];
            string condiment = _condiments[random.Next(_condiments.Length)];
            string pain = _pain[random.Next(_pain.Length)];
            string crudites = _crudites[random.Next(_crudites.Length)];

            return "Voici votre sandwich : " + pain + ", " + proteine + ", " + crudites + ", " + condiment;
        }
    }
}
