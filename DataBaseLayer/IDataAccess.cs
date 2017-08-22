using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DatabaseLayer
{
    interface IDataAccess
    {
        Boolean ExecuteProcedure(string zSPName, ref List<zParameters> zData);
        DataSet ExecuteProcedureReturnDS(string zSPName, ref List<zParameters> zData, Boolean isReturnDataset);
        Boolean ExecuteInsertUpdateDeleteQuery(string zQuery, ref List<zParameters> zData);
    }
}
