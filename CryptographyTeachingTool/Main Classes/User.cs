using CryptographyTeachingTool.Data;
using CryptographyTeachingTool.Data.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyTeachingTool.MainClasses
{
    public class User
    {
        /// <summary>
        ///  This generic class will hold all essential information need by the algorithm. 
        ///  When fetching data from the database things like the connection string and the usersID are needed,
        ///  which is why these are stored in the class.
        /// </summary>

        // The attributes below correspond to each column in the Users table of the database and
        // are part of this object, so they can be sent around the application together (in an encapsulated manner).
        public int userID;
        public string username;
        public string firstName;
        public string role;
        private int loginID;

        public User(int uID, string Uname, string fName, string role, int login)
        {
            // This is the only constructor for the user class.
            this.userID = uID;
            this.username = Uname;
            this.firstName = fName;
            this.role = role;
            this.loginID = login;
        }

        public void SignOut()
        {
            // This method is used to provide a centralised place for uploading a Log-out time to the AuditLog database
            UserRepo.SignOut(userID, loginID);
        }
    }
}
