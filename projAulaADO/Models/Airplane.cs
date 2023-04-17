using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAulaADO.Models
{
    public class Airplane
    {
        #region Properties
        public int Id {get; set;}
        public string Name { get; set;}
        public int NumberOfPassagers { get; set;}
        public string Description { get; set;}
        public Engine Engine { get; set;}
        #endregion

        public override string ToString()
        {
            return $"\nId: {this.Id}\nName: {this.Name}\nNumber of Passagers: " +
                $"{this.NumberOfPassagers}\nDescription: {this.Description}\nEngine: {this.Engine.Description}";
        }
    }
}
