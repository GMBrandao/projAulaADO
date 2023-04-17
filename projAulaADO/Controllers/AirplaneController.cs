using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projAulaADO.Models;
using projAulaADO.Services;

namespace projAulaADO.Controllers
{
    internal class AirplaneController
    {

        public bool Insert(Airplane airplane)
        {
            return new AirplaneService().Insert(airplane);
        }

        public List<Airplane> FindAll()
        {
            return new AirplaneService().FindAll();
        }

    }
}
