using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BLL.Database
{
  public class Cls_Database_BLL
    {
        #region Metodos
        public DataTable ExecuteDataAdapter( string sNombre_SP, string sNombreParametro, SqlDbType DbType, string sValorParametro, ref string sMsj_Error)

        {
            Cls_Database_DAL Obj_Database_DAL = new Cls_Database_DAL();

            try
            {
                Obj_Database_DAL.sString_Connection = ConfigurationManager.ConnectionStrings["WIN_AUT"].ToString();

                Obj_Database_DAL.Obj_SQL_Connection = new SqlConnection(Obj_Database_DAL.sString_Connection);

                if (Obj_Database_DAL.Obj_SQL_Connection.State == ConnectionState.Closed)
                {
                    Obj_Database_DAL.Obj_SQL_Connection.Open();
                }

                Obj_Database_DAL.Objs_SQL_Adapter = new SqlDataAdapter(sNombre_SP, Obj_Database_DAL.Obj_SQL_Connection);

                Obj_Database_DAL.Objs_SQL_Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (sValorParametro != string.Empty)
                {
                    Obj_Database_DAL.Objs_SQL_Adapter.SelectCommand.Parameters.Add(sNombreParametro, DbType).Value = sValorParametro;
                }

                DataSet DS = new DataSet();

                Obj_Database_DAL.Objs_SQL_Adapter.Fill(DS);

                sMsj_Error = string.Empty;

                return DS.Tables[0];

            }
            catch (SqlException ex)
            {

                sMsj_Error = ex.Message.ToString();
                return null;
            }
            finally
            {
                if (Obj_Database_DAL.Obj_SQL_Connection != null)
                {
                    if (Obj_Database_DAL.Obj_SQL_Connection.State == ConnectionState.Open )
                    {
                        Obj_Database_DAL.Obj_SQL_Connection.Close();
                    }
                    Obj_Database_DAL.Obj_SQL_Connection.Dispose();
                }
            }
        }

        public bool ExecuteNonQuery(string sNombre_SP, DataTable dtParametros, ref string sMsj_Error)
        {
            Cls_Database_DAL Obj_Database_DAL = new Cls_Database_DAL();
            try
            {
                Obj_Database_DAL.sString_Connection = ConfigurationManager.ConnectionStrings[1].ToString();

                Obj_Database_DAL.Obj_SQL_Connection = new SqlConnection(Obj_Database_DAL.sString_Connection);

                if (Obj_Database_DAL.Obj_SQL_Connection.State == ConnectionState.Closed)
                {
                    Obj_Database_DAL.Obj_SQL_Connection.Open();
                }
                Obj_Database_DAL.Obj_SQL_CMD = new SqlCommand(sNombre_SP, Obj_Database_DAL.Obj_SQL_Connection);

                Obj_Database_DAL.Obj_SQL_CMD.CommandType = CommandType.StoredProcedure;

                if (dtParametros.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtParametros.Rows)
                    {
                        SqlDbType dbt = SqlDbType.VarChar;

                        switch (dr[1].ToString())
                        {
                            case "1":
                            dbt = SqlDbType.Int;
                            break;

                            case "2":
                                {
                                    dbt = SqlDbType.VarChar;
                                    break;
                                }

                            default:
                                break;
                        }
                        Obj_Database_DAL.Obj_SQL_CMD.Parameters.Add(dr[0].ToString(), dbt).Value = dr[2].ToString();
                    }
                }
                Obj_Database_DAL.Obj_SQL_CMD.ExecuteNonQuery();
                sMsj_Error = string.Empty;
                return true;
            }
            catch (SqlException ex)
            {

                sMsj_Error = ex.Message.ToString();
                return false;
            }
            finally
            {
                if (Obj_Database_DAL.Obj_SQL_Connection != null)
                {
                    if (Obj_Database_DAL.Obj_SQL_Connection.State == ConnectionState.Open)
                    {
                        Obj_Database_DAL.Obj_SQL_Connection.Close();
                    }
                    Obj_Database_DAL.Obj_SQL_Connection.Dispose();

                }
            }
        }

        public string ExecuteScalar(string sNombre_SP, DataTable dtParamentros, ref string sMsj_Error)
        {
            Cls_Database_DAL Obj_Database_DAL = new Cls_Database_DAL();

            try
            {
                Obj_Database_DAL.sString_Connection = ConfigurationManager.ConnectionStrings[1].ToString();

                Obj_Database_DAL.Obj_SQL_Connection = new SqlConnection(Obj_Database_DAL.sString_Connection);

                if (Obj_Database_DAL.Obj_SQL_Connection.State == ConnectionState.Closed)
                {
                    Obj_Database_DAL.Obj_SQL_Connection.Open();
                }
                Obj_Database_DAL.Obj_SQL_CMD = new SqlCommand(sNombre_SP, Obj_Database_DAL.Obj_SQL_Connection);

                Obj_Database_DAL.Obj_SQL_CMD.CommandType = CommandType.StoredProcedure;

                if (dtParamentros.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtParamentros.Rows)
                    {
                        SqlDbType dbt = SqlDbType.VarChar;

                        switch (dr[1].ToString())
                        {
                            case "1":
                                dbt = SqlDbType.Int;
                                break;
                            case "2":
                                {
                                    dbt = SqlDbType.VarChar;
                                    break;
                                }
                            default:
                                break;
                        }
                        Obj_Database_DAL.Obj_SQL_CMD.Parameters.Add(dr[0].ToString(), dbt).Value = dr[2].ToString();
                    }
                }
                string sValorScalar = Obj_Database_DAL.Obj_SQL_CMD.ExecuteScalar().ToString();
                sMsj_Error = string.Empty;
                return sValorScalar;
            }
            catch (SqlException ex)
            {

                sMsj_Error = ex.Message.ToString();
                return string.Empty;
            }
            finally
            {
                if (Obj_Database_DAL.Obj_SQL_Connection != null)
                {
                    if (Obj_Database_DAL.Obj_SQL_Connection.State == ConnectionState.Open )
                    {
                        Obj_Database_DAL.Obj_SQL_Connection.Close();
                    }
                    Obj_Database_DAL.Obj_SQL_Connection.Dispose();
                }
            }
        } 

        #endregion
    }






}
