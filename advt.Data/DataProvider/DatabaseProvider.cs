using System;

namespace advt.Data
{

    public class DatabaseProvider
    {
        private DatabaseProvider()
        { }

        private static IDataProvider _instance = null;
        private static object lockHelper = new object();

        static DatabaseProvider()
        {
            GetProvider();
        }

        private static void GetProvider()
        {
            try
            {
                _instance = (IDataProvider)Activator.CreateInstance(Type.GetType(string.Format("advt.Data.{0}.DataProvider, advt.Data.{0}", "Sqlserver"), false, true));
            }
            catch
            {
                throw new Exception("Database Error!");
            }
        }

        public static IDataProvider GetInstance()
        {
            if (_instance == null)
            {
                lock (lockHelper)
                {
                    if (_instance == null)
                    {
                        GetProvider();
                    }
                }
            }
            return _instance;
        }

        public static void ResetDbProvider()
        {
            _instance = null;
        }
    }
}
