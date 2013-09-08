using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvePIPlanner
{
    public class RawPIObject : PIObject
    {
        public RawPIObject(int id, string name, PIObject.ObjectType type)
        {
            Id = id;
            Name = name;
            Type = type;
        }

        public override List<PIObject> GetComponents()
        {
            return DBHandler.GetInstance().GetPlanetsFromRawPIID(Id).ConvertAll(x => new PIObject { Id = x.Id, Name = x.Name, Type = x.Type });
        }
    }
}
