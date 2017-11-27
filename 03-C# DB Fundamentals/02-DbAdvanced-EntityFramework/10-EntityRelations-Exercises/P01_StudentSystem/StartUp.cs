using P01_StudentSystem.Data;
using System.Data.SqlClient;

namespace P01_StudentSystem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var db = new StudentSystemContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
            
        }
    }
}
