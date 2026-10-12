using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyTeachingTool.Data
{
    public class DataClasses
    {
        /// <summary>
        /// This class will be used to hold the connection string for all classes that need to access the database.
        /// As I am designing my application so that only classes that inherit from this will make the queries
        /// to the database, which will keep the database part of my application separate from other
        /// areas (like the user interface). The repository classes will inherit from this class,
        /// which will ensure that if the connection string ever needs to be changed, it can be done
        /// through this class in one place, thus improving data integrity.
        /// </summary>

        // This string is used for creating a link to the database. It shows Microsoft.Data.SqlClient where the database is stored, in this case locally.
        static protected string CONNECTION_STRING = "Server=DESKTOP-TIHP928;Database=NEA;Trusted_Connection=True;Encrypt=False;";
    }
}
