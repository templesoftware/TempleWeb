using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;


namespace BusinessLayer
{
    public static class clsBussinessLayer
    {

        public static clsDataLayer objdatabaseLayer = new clsDataLayer();

        public  static Boolean ExecuteInsertUpdateDeleteQueryBL(string sqlstring, ref List<zParameters> zData)
        {
            return objdatabaseLayer.ExecuteInsertUpdateDeleteQuery( sqlstring, ref zData );
        }

    }
}
