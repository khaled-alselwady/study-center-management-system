using System.Configuration;

namespace StudyCenter_DataAccess
{
    static class clsDataAccessSettings
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    }
}