using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvePIPlanner
{
    public class DBHandler
    {
        internal static DBHandler instance = null;

        internal SQLiteConnection connection;

        internal DBHandler()
        {
            connection = new SQLiteConnection("Data Source=evepidb.db;Version=3;");
            connection.Open();
        }
        

        public static DBHandler GetInstance()
        {
            if (instance == null)
            {
                instance = new DBHandler();
            }
            return (instance);
        }

        public Planet GetPlanetByName(string name)
        {
            Planet ret = null;
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.PLANET_GET_BY_NAME_PREPARED_STATEMENT_STRING;
                comm.Parameters.AddWithValue("@name", name);
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.ID_FIELD);
                    int nameColumn = reader.GetOrdinal(DBConstants.NAME_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    string nameValue = (reader.IsDBNull(nameColumn)) ? string.Empty : reader.GetString(nameColumn);
                    ret = new Planet(idValue, nameValue, PIObject.ObjectType.Planet);
                    break;
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public Planet GetPlanetByID(int id)
        {
            Planet ret = null;
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.PLANET_GET_BY_ID_PREPARED_STATEMENT_STRING;
                comm.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.ID_FIELD);
                    int nameColumn = reader.GetOrdinal(DBConstants.NAME_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    string nameValue = (reader.IsDBNull(nameColumn)) ? string.Empty : reader.GetString(nameColumn);
                    ret = new Planet(idValue, nameValue, PIObject.ObjectType.Planet);
                    break;
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public List<Planet> GetAllPlanetObjects()
        {
            List<Planet> ret = new List<Planet>();
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.PLANET_GET_ALL_PREPARED_STATEMENT_STRING;
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.ID_FIELD);
                    int nameColumn = reader.GetOrdinal(DBConstants.NAME_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    string nameValue = (reader.IsDBNull(nameColumn)) ? string.Empty : reader.GetString(nameColumn);
                    Planet obj = new Planet(idValue, nameValue, PIObject.ObjectType.Planet);
                    ret.Add(obj);
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public List<Planet> GetPlanetsFromRawPIID(int id)
        {
            List<Planet> ret = new List<Planet>();
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.RAW_PI_GET_PLANETS_BY_ID_PREPARED_STATEMENT_STRING;
                comm.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.PLANET_ID_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    Planet obj = GetPlanetByID(idValue);
                    ret.Add(obj);
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public RawPIObject GetRawPIByName(string name)
        {
            RawPIObject ret = null;
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.RAW_PI_GET_BY_NAME_PREPARED_STATEMENT_STRING;
                comm.Parameters.AddWithValue("@name", name);
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.ID_FIELD);
                    int nameColumn = reader.GetOrdinal(DBConstants.NAME_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    string nameValue = (reader.IsDBNull(nameColumn)) ? string.Empty : reader.GetString(nameColumn);
                    ret = new RawPIObject(idValue, nameValue, PIObject.ObjectType.Raw);
                    break;
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public RawPIObject GetRawPIByID(int id)
        {
            RawPIObject ret = null;
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.RAW_PI_GET_BY_ID_PREPARED_STATEMENT_STRING;
                comm.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.ID_FIELD);
                    int nameColumn = reader.GetOrdinal(DBConstants.NAME_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    string nameValue = (reader.IsDBNull(nameColumn)) ? string.Empty : reader.GetString(nameColumn);
                    ret = new RawPIObject(idValue, nameValue, PIObject.ObjectType.Raw);
                    break;
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public List<RawPIObject> GetAllRawPIObjects()
        {
            List<RawPIObject> ret = new List<RawPIObject>();
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.RAW_PI_GET_ALL_PREPARED_STATEMENT_STRING;
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.ID_FIELD);
                    int nameColumn = reader.GetOrdinal(DBConstants.NAME_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    string nameValue = (reader.IsDBNull(nameColumn)) ? string.Empty : reader.GetString(nameColumn);
                    RawPIObject obj = new RawPIObject(idValue, nameValue, PIObject.ObjectType.Raw);
                    ret.Add(obj);
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public P1Object GetP1ByName(string name)
        {
            P1Object ret = null;
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.P1_GET_BY_NAME_PREPARED_STATEMENT_STRING;
                comm.Parameters.AddWithValue("@name", name);
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.ID_FIELD);
                    int nameColumn = reader.GetOrdinal(DBConstants.NAME_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    string nameValue = (reader.IsDBNull(nameColumn)) ? string.Empty : reader.GetString(nameColumn);
                    ret = new P1Object(idValue, nameValue, PIObject.ObjectType.P1);
                    break;
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public P1Object GetP1ByID(int id)
        {
            P1Object ret = null;
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.P1_GET_BY_ID_PREPARED_STATEMENT_STRING;
                comm.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.ID_FIELD);
                    int nameColumn = reader.GetOrdinal(DBConstants.NAME_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    string nameValue = (reader.IsDBNull(nameColumn)) ? string.Empty : reader.GetString(nameColumn);
                    ret = new P1Object(idValue, nameValue, PIObject.ObjectType.P1);
                    break;
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public List<P1Object> GetAllP1Objects()
        {
            List<P1Object> ret = new List<P1Object>();
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.P1_GET_ALL_PREPARED_STATEMENT_STRING;
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.ID_FIELD);
                    int nameColumn = reader.GetOrdinal(DBConstants.NAME_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    string nameValue = (reader.IsDBNull(nameColumn)) ? string.Empty : reader.GetString(nameColumn);
                    P1Object obj = new P1Object(idValue, nameValue, PIObject.ObjectType.P1);
                    ret.Add(obj);
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public List<RawPIObject> GetRawComponentsByP1ID(int id)
        {
            List<RawPIObject> ret = new List<RawPIObject>();
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.P1_GET_RAW_COMPONENTS_BY_ID_PREPARED_STATEMENT_STRING;
                comm.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.RAW_PI_ID_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    RawPIObject obj = GetRawPIByID(idValue);
                    ret.Add(obj);
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public P2Object GetP2ByName(string name)
        {
            P2Object ret = null;
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.P2_GET_BY_NAME_PREPARED_STATEMENT_STRING;
                comm.Parameters.AddWithValue("@name", name);
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.ID_FIELD);
                    int nameColumn = reader.GetOrdinal(DBConstants.NAME_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    string nameValue = (reader.IsDBNull(nameColumn)) ? string.Empty : reader.GetString(nameColumn);
                    ret = new P2Object(idValue, nameValue, PIObject.ObjectType.P2);
                    break;
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public P2Object GetP2ByID(int id)
        {
            P2Object ret = null;
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.P2_GET_BY_ID_PREPARED_STATEMENT_STRING;
                comm.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.ID_FIELD);
                    int nameColumn = reader.GetOrdinal(DBConstants.NAME_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    string nameValue = (reader.IsDBNull(nameColumn)) ? string.Empty : reader.GetString(nameColumn);
                    ret = new P2Object(idValue, nameValue, PIObject.ObjectType.P2);
                    break;
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public List<P2Object> GetAllP2Objects()
        {
            List<P2Object> ret = new List<P2Object>();
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.P2_GET_ALL_PREPARED_STATEMENT_STRING;
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.ID_FIELD);
                    int nameColumn = reader.GetOrdinal(DBConstants.NAME_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    string nameValue = (reader.IsDBNull(nameColumn)) ? string.Empty : reader.GetString(nameColumn);
                    P2Object obj = new P2Object(idValue, nameValue, PIObject.ObjectType.P2);
                    ret.Add(obj);
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public List<P1Object> GetP1ComponentsByP2ID(int id)
        {
            List<P1Object> ret = new List<P1Object>();
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.P2_GET_P1_COMPONENTS_BY_ID_PREPARED_STATEMENT_STRING;
                comm.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.P1_ID_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    P1Object obj = GetP1ByID(idValue);
                    ret.Add(obj);
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public P3Object GetP3ByName(string name)
        {
            P3Object ret = null;
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.P3_GET_BY_NAME_PREPARED_STATEMENT_STRING;
                comm.Parameters.AddWithValue("@name", name);
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.ID_FIELD);
                    int nameColumn = reader.GetOrdinal(DBConstants.NAME_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    string nameValue = (reader.IsDBNull(nameColumn)) ? string.Empty : reader.GetString(nameColumn);
                    ret = new P3Object(idValue, nameValue, PIObject.ObjectType.P3);
                    break;
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public P3Object GetP3ByID(int id)
        {
            P3Object ret = null;
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.P3_GET_BY_ID_PREPARED_STATEMENT_STRING;
                comm.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.ID_FIELD);
                    int nameColumn = reader.GetOrdinal(DBConstants.NAME_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    string nameValue = (reader.IsDBNull(nameColumn)) ? string.Empty : reader.GetString(nameColumn);
                    ret = new P3Object(idValue, nameValue, PIObject.ObjectType.P3);
                    break;
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public List<P3Object> GetAllP3Objects()
        {
            List<P3Object> ret = new List<P3Object>();
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.P3_GET_ALL_PREPARED_STATEMENT_STRING;
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.ID_FIELD);
                    int nameColumn = reader.GetOrdinal(DBConstants.NAME_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    string nameValue = (reader.IsDBNull(nameColumn)) ? string.Empty : reader.GetString(nameColumn);
                    P3Object obj = new P3Object(idValue, nameValue, PIObject.ObjectType.P3);
                    ret.Add(obj);
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public List<P2Object> GetP2ComponentsByP3ID(int id)
        {
            List<P2Object> ret = new List<P2Object>();
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.P3_GET_P2_COMPONENTS_BY_ID_PREPARED_STATEMENT_STRING;
                comm.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.P2_ID_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    P2Object obj = GetP2ByID(idValue);
                    ret.Add(obj);
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public P4Object GetP4ByName(string name)
        {
            P4Object ret = null;
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.P4_GET_BY_NAME_PREPARED_STATEMENT_STRING;
                comm.Parameters.AddWithValue("@name", name);
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.ID_FIELD);
                    int nameColumn = reader.GetOrdinal(DBConstants.NAME_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    string nameValue = (reader.IsDBNull(nameColumn)) ? string.Empty : reader.GetString(nameColumn);
                    ret = new P4Object(idValue, nameValue, PIObject.ObjectType.P4);
                    break;
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public P4Object GetP4ByID(int id)
        {
            P4Object ret = null;
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.P4_GET_BY_ID_PREPARED_STATEMENT_STRING;
                comm.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.ID_FIELD);
                    int nameColumn = reader.GetOrdinal(DBConstants.NAME_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    string nameValue = (reader.IsDBNull(nameColumn)) ? string.Empty : reader.GetString(nameColumn);
                    ret = new P4Object(idValue, nameValue, PIObject.ObjectType.P4);
                    break;
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public List<P4Object> GetAllP4Objects()
        {
            List<P4Object> ret = new List<P4Object>();
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.P4_GET_ALL_PREPARED_STATEMENT_STRING;
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.ID_FIELD);
                    int nameColumn = reader.GetOrdinal(DBConstants.NAME_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    string nameValue = (reader.IsDBNull(nameColumn)) ? string.Empty : reader.GetString(nameColumn);
                    P4Object obj = new P4Object(idValue, nameValue, PIObject.ObjectType.P4);
                    ret.Add(obj);
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        public List<PIObject> GetPIComponentsByP4ID(int id)
        {
            List<PIObject> ret = new List<PIObject>();
            ret.AddRange(GetP1ComponentsByP4ID(id));
            ret.AddRange(GetP3ComponentsByP4ID(id));
            return (ret);
        }

        private List<P1Object> GetP1ComponentsByP4ID(int id)
        {
            List<P1Object> ret = new List<P1Object>();
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.P4_GET_P1_COMPONENTS_BY_ID_PREPARED_STATEMENT_STRING;
                comm.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.P1_ID_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    P1Object obj = GetP1ByID(idValue);
                    ret.Add(obj);
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

        private List<P3Object> GetP3ComponentsByP4ID(int id)
        {
            List<P3Object> ret = new List<P3Object>();
            using (SQLiteCommand comm = connection.CreateCommand())
            {
                comm.CommandText = DBConstants.P4_GET_P3_COMPONENTS_BY_ID_PREPARED_STATEMENT_STRING;
                comm.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int idColumn = reader.GetOrdinal(DBConstants.P3_ID_FIELD);
                    int idValue = (reader.IsDBNull(idColumn)) ? -1 : reader.GetInt32(idColumn);
                    P3Object obj = GetP3ByID(idValue);
                    ret.Add(obj);
                }
                reader.Close();
                reader = null;
            }
            return (ret);
        }

    }
}
