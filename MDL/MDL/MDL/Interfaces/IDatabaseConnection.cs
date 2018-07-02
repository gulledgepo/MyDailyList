using System;
using System.Collections.Generic;
using System.Text;

namespace MDL.Interfaces
{
    public interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}
