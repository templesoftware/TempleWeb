using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseLayer;
using BusinessLayer;

namespace TempleManagement
{ 
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /*
        protected void btnclick_Click(object sender, EventArgs e)
        {

            List<zParameters> parameters = new List<zParameters>();
            string errorMessage = "";

            zParameters ID = new zParameters { ParameterName = "ID", ParameterDirection = enumParameterDirection.Input, ParameterDataType = enumParameterDataType.SQLInt, ParameterValue = 7.ToString() };
            parameters.Add(ID);

            zParameters STDNAME = new zParameters { ParameterName = "STUDENTNAME", ParameterDirection = enumParameterDirection.Input, ParameterDataType = enumParameterDataType.SQLVarchar, ParameterValue = "Suganya" };
            parameters.Add(STDNAME);

            Boolean st = clsBussinessLayer.ExecuteInsertUpdateDeleteQueryBL("insert into studentinfo(id,studentname) values(@ID,@STUDENTNAME)", ref parameters);
        }*/
    }
}