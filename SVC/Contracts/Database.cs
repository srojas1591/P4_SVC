using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BLL.Database;
using DAL.Database;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace SVC.Contracts
{
   public class Database : Interfaces.IDatabase
    {
        public DataTable ListarDatos(string sNombreSP, ref string sMsj_Error)
        {
            Cls_Database_BLL Obj_Database_BLL = new Cls_Database_BLL();
            return Obj_Database_BLL.ExecuteDataAdapter(sNombreSP, "", SqlDbType.VarChar, "", ref sMsj_Error);
        }
        public DataTable FiltrarDatos(string sNombreSP, string sNombreParametro, SqlDbType DbType, string sValorParametro, ref string sMsj_Error)
        {
            Cls_Database_BLL Obj_Database_BLL = new Cls_Database_BLL();

            return Obj_Database_BLL.ExecuteDataAdapter(sNombreSP, sNombreParametro, DbType, sValorParametro, ref sMsj_Error);
        }
        public bool Inserta_DatosSinIndentity(string sNombreSP, DataTable dtParametros, ref string sMsj_Error)
        {
            Cls_Database_BLL Obj_Database_BLL = new Cls_Database_BLL();

            return Obj_Database_BLL.ExecuteNonQuery(sNombreSP, dtParametros, ref sMsj_Error);
        }
        public string InsertaDatosConIdentity(string sNombreSP, DataTable dtParametros, ref string sValorScalar, ref string sMsj_Error)
        {
            Cls_Database_BLL Obj_Database_BLL = new Cls_Database_BLL();

            return Obj_Database_BLL.ExecuteScalar(sNombreSP, dtParametros, ref sMsj_Error).ToString();
        }
        public bool Modifica_Datos(string sNombreSP, DataTable dtParametros, ref string sMsj_Error)
        {
            Cls_Database_BLL Obj_Database_BLL = new Cls_Database_BLL();

            return Obj_Database_BLL.ExecuteNonQuery(sNombreSP, dtParametros, ref sMsj_Error);
        }
        public bool Elimina_Datos(string sNombreSP, DataTable dtParametros, ref string sMsj_Error)
        {
            Cls_Database_BLL Obj_Database_BLL = new Cls_Database_BLL();

            return Obj_Database_BLL.ExecuteNonQuery(sNombreSP, dtParametros, ref sMsj_Error);
        }
    }
}
