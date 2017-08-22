using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DatabaseLayer
{
    public static class zDataAccess
    {
        public static Boolean ExecuteProcedure(string zSPName, ref List<zParameters> zData, ref string zError)
        {
            try
            {
                IDataAccess dataaccess = GetDatabaseType();
                if (dataaccess != null)
                {
                    return dataaccess.ExecuteProcedure(zSPName, ref zData);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                zError = "TS_DataAccess : " + ex.Message;
                return false;
            }
        }

        public static DataSet ExecuteProcedureReturnDS(string zSPName, ref List<zParameters> zData, Boolean isReturnDataset, ref string zError)
        {
            try
            {
                IDataAccess dataaccess = GetDatabaseType();
                if (dataaccess != null)
                {
                    return dataaccess.ExecuteProcedureReturnDS(zSPName, ref zData, isReturnDataset);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                zError = "TS_DataAccess : " + ex.Message;
                return null;
            }
        }

        public static Boolean ExecuteInsertUpdateDeleteQuery(string zQuery, ref List<zParameters> zData, ref string zError)
        {
            try
            {
                IDataAccess dataaccess = GetDatabaseType();
                if (dataaccess != null)
                {
                    return dataaccess.ExecuteInsertUpdateDeleteQuery(zQuery, ref zData);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                zError = "TS_DataAccess : " + ex.Message;
                return false;
            }
        }

        private static IDataAccess GetDatabaseType()
        {
            IDataAccess dataaccess;
            string ConfiguredDBType = Convert.ToString(ConfigurationManager.AppSettings["Z_DB_TYPE"]);
            switch (ConfiguredDBType)
            {
                case "SQLSERVER":
                    dataaccess = new clsDataLayer();
                    break;
                //case "ORACLE":
                //    dataaccess = new ORACLE();
                //    break;
                default:
                    dataaccess = null;
                    break;
            }
            return dataaccess;
        }


        //LogisticsDAshboard_v1

        //public static DataSet ExecuteProcedure(string zSPName, ref List<zParameters> zData, Boolean isReturnDataset, ref string zError)
        //{
        //    try
        //    {
        //        IDataAccess dataaccess = GetDatabaseType();
        //        if (dataaccess != null)
        //        {
        //            return dataaccess.ExecuteProcedure_LDB(zSPName, ref zData, isReturnDataset);
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        zError = "TS_DataAccess : " + ex.Message;
        //        return null;
        //    }
        //}
    }
}
