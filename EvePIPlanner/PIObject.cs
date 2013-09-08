using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvePIPlanner
{
    public class PIObject
    {
        public int Id = -1;
        public string Name = string.Empty;
        public PIObject.ObjectType Type = null;

        public virtual List<PIObject> GetComponents()
        {
            return null;
        }

        public class ObjectType
        {
            private ObjectType(string value)
            {
                Value = value;
            }

            public string Value { get; set; }

            public static ObjectType Planet { get { return new ObjectType("Planet"); } }
            public static ObjectType Raw { get { return new ObjectType("Raw"); } }
            public static ObjectType P1 { get { return new ObjectType("P1"); } }
            public static ObjectType P2 { get { return new ObjectType("P2"); } }
            public static ObjectType P3 { get { return new ObjectType("P3"); } }
            public static ObjectType P4 { get { return new ObjectType("P4"); } }

            public override string ToString()
            {
                return Value;
            }
        }
    }
}
