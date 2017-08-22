using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System;


namespace DatabaseLayer
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class clsDataLayer : IDataAccess

    {
        //private string conn = ConfigurationManager.ConnectionStrings["TempleDB"].ToString();
        private readonly String connectionString_tsdb = Convert.ToString(ConfigurationManager.AppSettings["Z_CONNECTION_STRING_TSDB"]);

        //Insert delete and update function

        public Boolean ExecuteInsertUpdateDeleteQuery(string sqlstring, ref List<zParameters> zData)
        {
            {
                //int returnValue = 0;
                SqlConnection sqlConnection = new SqlConnection(connectionString_tsdb);
                sqlConnection.Open();

                try
                {
                    using (sqlConnection)
                    {
                        using (SqlCommand command = new SqlCommand(sqlstring, sqlConnection))
                        {
                            command.CommandText = sqlstring;
                            command.CommandType = CommandType.Text;

                            foreach (zParameters zparameter in zData)
                            {

                                //command.Parameters.Add("@" + zparameter.ParameterName, (System.Data.SqlDbType)zparameter.ParameterDataType).Value = zparameter.ParameterValue;
                                SqlParameter parameter = new SqlParameter();
                                parameter.ParameterName = "@" + zparameter.ParameterName;
                                parameter.SqlDbType = (System.Data.SqlDbType)zparameter.ParameterDataType;
                                parameter.Direction = (System.Data.ParameterDirection)zparameter.ParameterDirection;
                                if (zparameter.ParameterDirection == enumParameterDirection.Input)
                                {
                                    if (zparameter.ParameterDataType_default == enumDataType.String)
                                    {
                                        parameter.Value = zparameter.ParameterValue;
                                    }
                                    else if (zparameter.ParameterDataType_default == enumDataType.Int)
                                    {
                                        parameter.Value = Convert.ToInt32(zparameter.ParameterValue);
                                    }
                                    else if (zparameter.ParameterDataType_default == enumDataType.DateTime)
                                    {
                                        parameter.Value = Convert.ToDateTime(zparameter.ParameterValue);
                                    }
                                    else
                                    {
                                        parameter.Value = Convert.ToDateTime(zparameter.ParameterValue);
                                    }
                                }

                                //Add parameter size for Char, NVarChar, Text, Varchar, Nchar, NText
                                if (zparameter.ParameterDirection == enumParameterDirection.Output)
                                {
                                    if ((zparameter.ParameterDataType == enumParameterDataType.SQLNchar) ||
                                        //(zparameter.ParameterDataType == enumParameterDataType.SQLNText) ||
                                        (zparameter.ParameterDataType == enumParameterDataType.SQLNVarChar) ||
                                        (zparameter.ParameterDataType == enumParameterDataType.SQLChar) ||
                                        //(zparameter.ParameterDataType == enumParameterDataType.SQLText) ||
                                        (zparameter.ParameterDataType == enumParameterDataType.SQLVarchar))
                                        if (zparameter.ParameterSize > 0)
                                            parameter.Size = zparameter.ParameterSize;
                                        else
                                            throw new Exception("Parameter size is not defined - " + zparameter.ParameterName);
                                }


                                // Add the parameter to the Parameters collection. 
                                command.Parameters.Add(parameter);
                            }
                            //returnValue = command.ExecuteNonQuery();
                            command.ExecuteNonQuery();

                            foreach (zParameters zparameter in zData)
                            {
                                if (zparameter.ParameterDirection == enumParameterDirection.Output)
                                    zparameter.ParameterValue = command.Parameters["@" + zparameter.ParameterName].Value.ToString();
                            }
                        }
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Boolean ExecuteProcedure(string zSPName, ref List<zParameters> zData)
        {
            //int returnValue = 0;
            SqlConnection sqlConnection = new SqlConnection("Z_CONNECTION_STRING_TSDB");
            sqlConnection.Open();

            try
            {
                using (sqlConnection)
                {
                    using (SqlCommand command = new SqlCommand(zSPName, sqlConnection))
                    {
                        command.CommandText = zSPName;
                        command.CommandType = CommandType.StoredProcedure;

                        foreach (zParameters zparameter in zData)
                        {

                            //command.Parameters.Add("@" + zparameter.ParameterName, (System.Data.SqlDbType)zparameter.ParameterDataType).Value = zparameter.ParameterValue;
                            SqlParameter parameter = new SqlParameter();
                            parameter.ParameterName = "@" + zparameter.ParameterName;
                            parameter.SqlDbType = (System.Data.SqlDbType)zparameter.ParameterDataType;
                            parameter.Direction = (System.Data.ParameterDirection)zparameter.ParameterDirection;
                            if (zparameter.ParameterDirection == enumParameterDirection.Input)
                            {
                                if (zparameter.ParameterDataType_default == enumDataType.String)
                                {
                                    parameter.Value = zparameter.ParameterValue;
                                }
                                else if (zparameter.ParameterDataType_default == enumDataType.Int)
                                {
                                    parameter.Value = Convert.ToInt32(zparameter.ParameterValue);
                                }
                                else if (zparameter.ParameterDataType_default == enumDataType.DateTime)
                                {
                                    parameter.Value = Convert.ToDateTime(zparameter.ParameterValue);
                                }
                                else
                                {
                                    parameter.Value = Convert.ToDateTime(zparameter.ParameterValue);
                                }
                            }

                            //Add parameter size for Char, NVarChar, Text, Varchar, Nchar, NText
                            if (zparameter.ParameterDirection == enumParameterDirection.Output)
                            {
                                if ((zparameter.ParameterDataType == enumParameterDataType.SQLNchar) ||
                                    //(zparameter.ParameterDataType == enumParameterDataType.SQLNText) ||
                                    (zparameter.ParameterDataType == enumParameterDataType.SQLNVarChar) ||
                                    (zparameter.ParameterDataType == enumParameterDataType.SQLChar) ||
                                    //(zparameter.ParameterDataType == enumParameterDataType.SQLText) ||
                                    (zparameter.ParameterDataType == enumParameterDataType.SQLVarchar))
                                    if (zparameter.ParameterSize > 0)
                                        parameter.Size = zparameter.ParameterSize;
                                    else
                                        throw new Exception("Parameter size is not defined - " + zparameter.ParameterName);
                            }


                            // Add the parameter to the Parameters collection. 
                            command.Parameters.Add(parameter);
                        }
                        //returnValue = command.ExecuteNonQuery();
                        command.ExecuteNonQuery();

                        foreach (zParameters zparameter in zData)
                        {
                            if (zparameter.ParameterDirection == enumParameterDirection.Output)
                                zparameter.ParameterValue = command.Parameters["@" + zparameter.ParameterName].Value.ToString();
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet ExecuteProcedureReturnDS(string zSPName, ref List<zParameters> zData, Boolean isReturnDataset)
        {
            SqlConnection sqlConnection = new SqlConnection("Z_CONNECTION_STRING_TSDB ");
            sqlConnection.Open();

            try
            {
                using (sqlConnection)
                {
                    using (SqlCommand command = new SqlCommand(zSPName, sqlConnection))
                    {

                        command.CommandText = zSPName;
                        command.CommandType = CommandType.StoredProcedure;

                        foreach (zParameters zparameter in zData)
                        {

                            SqlParameter parameter = new SqlParameter();
                            parameter.ParameterName = "@" + zparameter.ParameterName;
                            parameter.SqlDbType = (System.Data.SqlDbType)zparameter.ParameterDataType;
                            parameter.Direction = (System.Data.ParameterDirection)zparameter.ParameterDirection;
                            if (zparameter.ParameterDirection == enumParameterDirection.Input)
                                parameter.Value = zparameter.ParameterValue;

                            //Add parameter size for Char, NVarChar, Text, Varchar, Nchar, NText
                            if (zparameter.ParameterDirection == enumParameterDirection.Output)
                            {
                                if ((zparameter.ParameterDataType == enumParameterDataType.SQLNchar) ||
                                    //(zparameter.ParameterDataType == enumParameterDataType.SQLNText) ||
                                    (zparameter.ParameterDataType == enumParameterDataType.SQLNVarChar) ||
                                    (zparameter.ParameterDataType == enumParameterDataType.SQLChar) ||
                                    //(zparameter.ParameterDataType == enumParameterDataType.SQLText) ||
                                    (zparameter.ParameterDataType == enumParameterDataType.SQLVarchar))
                                    if (zparameter.ParameterSize > 0)
                                        parameter.Size = zparameter.ParameterSize;
                                    else
                                        throw new Exception("Parameter size is not defined - " + zparameter.ParameterName);
                            }

                            // Add the parameter to the Parameters collection. 
                            command.Parameters.Add(parameter);

                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            // Fill the DataSet using default values for DataTable names, etc
                            DataSet dataset = new DataSet();
                            da.Fill(dataset);

                            foreach (zParameters zparameter in zData)
                            {
                                if (zparameter.ParameterDirection == enumParameterDirection.Output)
                                    zparameter.ParameterValue = command.Parameters["@" + zparameter.ParameterName].Value.ToString();
                            }

                            return dataset;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Insert items into combobox

        public DataTable GetData()
        {
            DataTable dt = new DataTable();

            SqlConnection objsql = new SqlConnection("conn");

            string CMD = "Select * from TBL where ";
            SqlDataAdapter da = new SqlDataAdapter(CMD, objsql);
            da.Fill(dt);

            return dt;
        }

        //Select query with return dataset
        public object LoadDB(string tblName)
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * from " + tblName;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }


    }

}