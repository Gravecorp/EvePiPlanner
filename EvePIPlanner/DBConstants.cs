using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvePIPlanner
{
    public class DBConstants
    {
        public static string RAW_PI_TABLENAME = "rawpi";
        public static string PLANET_TABLENAME = "planets";
        public static string PLANET_TO_RAW_PI_TABLENAME = "planettorawpilinktable";

        public static string P1_TO_RAW_PI_TABLENAME = "p1torawpilinktable";

        public static string P1_TABLENAME = "p1";

        public static string P2_TO_P1_TABLENAME = "p2top1linktable";

        public static string P2_TABLENAME = "p2";

        public static string P3_TO_P2_TABLENAME = "p3top2linktable";

        public static string P3_TABLENAME = "p3";

        public static string P4_TO_P1_TABLENAME = "p4top1linktable";
        public static string P4_TO_P3_TABLENAME = "p4top3linktable";

        public static string P4_TABLENAME = "p4";

        public static string PLANET_ID_FIELD = "planetid";
        public static string RAW_PI_ID_FIELD = "rawpiid";
        public static string P1_ID_FIELD = "p1id";
        public static string P2_ID_FIELD = "p2id";
        public static string P3_ID_FIELD = "p3id";
        public static string P4_ID_FIELD = "p4id";
        public static string NAME_FIELD = "name";
        public static string ID_FIELD = "id";

        public static string PLANET_GET_BY_ID_PREPARED_STATEMENT_STRING = string.Format("select {0}, {1} from {2} where {0}='@id'", ID_FIELD, NAME_FIELD, PLANET_TABLENAME);
        public static string PLANET_GET_BY_NAME_PREPARED_STATEMENT_STRING = string.Format("select {0}, {1} from {2} where {1}='@name'", ID_FIELD, NAME_FIELD, PLANET_TABLENAME);

        public static string RAW_PI_GET_PLANETS_BY_ID_PREPARED_STATEMENT_STRING = string.Format("select {0}, {1} from {2} where {0}='@id'", RAW_PI_ID_FIELD, PLANET_ID_FIELD, PLANET_TO_RAW_PI_TABLENAME);

        public static string RAW_PI_GET_BY_ID_PREPARED_STATEMENT_STRING = string.Format("select {0}, {1} from {2} where {0}='@id'", ID_FIELD, NAME_FIELD, RAW_PI_TABLENAME);
        public static string RAW_PI_GET_BY_NAME_PREPARED_STATEMENT_STRING = string.Format("select {0}, {1} from {2} where {1}='@name'", ID_FIELD, NAME_FIELD, RAW_PI_TABLENAME);

        public static string P1_GET_RAW_COMPONENTS_BY_ID_PREPARED_STATEMENT_STRING = string.Format("select {0}, {1} from {2} where {0}='@id'", P1_ID_FIELD, RAW_PI_ID_FIELD, P1_TO_RAW_PI_TABLENAME);

        public static string P1_GET_BY_ID_PREPARED_STATEMENT_STRING = string.Format("select {0}, {1} from {2} where {0}='@id'", ID_FIELD, NAME_FIELD, P1_TABLENAME);
        public static string P1_GET_BY_NAME_PREPARED_STATEMENT_STRING = string.Format("select {0}, {1} from {2} where {1}='@name'", ID_FIELD, NAME_FIELD, P1_TABLENAME);

        public static string P2_GET_P1_COMPONENTS_BY_ID_PREPARED_STATEMENT_STRING = string.Format("select {0}, {1} from {2} where {0}='@id'", P2_ID_FIELD, P1_ID_FIELD, P2_TO_P1_TABLENAME);

        public static string P2_GET_BY_ID_PREPARED_STATEMENT_STRING = string.Format("select {0}, {1} from {2} where {0}='@id'", ID_FIELD, NAME_FIELD, P2_TABLENAME);
        public static string P2_GET_BY_NAME_PREPARED_STATEMENT_STRING = string.Format("select {0}, {1} from {2} where {1}='@name'", ID_FIELD, NAME_FIELD, P2_TABLENAME);

        public static string P3_GET_P2_COMPONENTS_BY_ID_PREPARED_STATEMENT_STRING = string.Format("select {0}, {1} from {2} where {0}='@id'", P3_ID_FIELD, P2_ID_FIELD, P3_TO_P2_TABLENAME);

        public static string P3_GET_BY_ID_PREPARED_STATEMENT_STRING = string.Format("select {0}, {1} from {2} where {0}='@id'", ID_FIELD, NAME_FIELD, P3_TABLENAME);
        public static string P3_GET_BY_NAME_PREPARED_STATEMENT_STRING = string.Format("select {0}, {1} from {2} where {1}='@name'", ID_FIELD, NAME_FIELD, P3_TABLENAME);

        public static string P4_GET_P1_COMPONENTS_BY_ID_PREPARED_STATEMENT_STRING = string.Format("select {0}, {1} from {2} where {0}='@id'", P4_ID_FIELD, P1_ID_FIELD, P4_TO_P1_TABLENAME);
        public static string P4_GET_P3_COMPONENTS_BY_ID_PREPARED_STATEMENT_STRING = string.Format("select {0}, {1} from {2} where {0}='@id'", P4_ID_FIELD, P3_ID_FIELD, P4_TO_P3_TABLENAME);

        public static string P4_GET_BY_ID_PREPARED_STATEMENT_STRING = string.Format("select {0}, {1} from {2} where {0}='@id'", ID_FIELD, NAME_FIELD, P4_TABLENAME);
        public static string P4_GET_BY_NAME_PREPARED_STATEMENT_STRING = string.Format("select {0}, {1} from {2} where {1}='@name'", ID_FIELD, NAME_FIELD, P4_TABLENAME);
    }
}
