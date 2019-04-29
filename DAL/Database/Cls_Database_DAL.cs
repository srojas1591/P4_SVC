using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL.Database
{
  public class Cls_Database_DAL
    {
        private string _sMjs_Error, _sString_Connection;

        public string sMjs_Error
        {
            get
            {
                return _sMjs_Error;
            }

            set
            {
                _sMjs_Error = value;
            }
        }

        public string sString_Connection
        {
            get
            {
                return _sString_Connection;
            }

            set
            {
                _sString_Connection = value;
            }
        }

        public SqlCommand Obj_SQL_CMD;
        public SqlDataAdapter Objs_SQL_Adapter;
        public SqlConnection Obj_SQL_Connection;
    }
}
