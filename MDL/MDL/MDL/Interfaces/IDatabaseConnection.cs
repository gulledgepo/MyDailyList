using System;
using System.Collections.Generic;
using System.Text;

namespace MDL.Interfaces
{
    public interface IDatabaseConnection
    {
        //This file works with the Android and UWP files to access the appropriate storage locations
        SQLite.SQLiteConnection DbConnection();
    }
}
