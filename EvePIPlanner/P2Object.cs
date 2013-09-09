using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvePIPlanner
{
    public class P2Object : PIObject
    {
        public P2Object(int id, string name, PIObject.ObjectType type)
        {
            Id = id;
            Name = name;
            Type = type;
            objectList.AddRange(DBHandler.GetInstance().GetP1ComponentsByP2ID(id));
        }

        public override List<PIObject> GetComponents()
        {
            return objectList;
        }
    }
}
