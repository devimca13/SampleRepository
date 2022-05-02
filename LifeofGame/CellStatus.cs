using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeofGame
{


   public class CellStatus
    {
       
            public bool Alive;
            public bool NextAlive;
            public List<CellStatus> cellstatus = new List<CellStatus>();
        
    }
}
