using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvePIPlanner
{
    public class P1Object : PIObject
    {
        public P1Object(int id, string name, PIObject.ObjectType type)
        {
            Id = id;
            Name = name;
            Type = type;
            objectList.AddRange(DBHandler.GetInstance().GetRawComponentsByP1ID(id));
        }

        public override List<PIObject> GetComponents()
        {
            return objectList;
        }
    }
}
