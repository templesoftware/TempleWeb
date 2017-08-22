using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class zParameters
    {
        public string ParameterName { get; set; }
        public enumParameterDataType ParameterDataType { get; set; }
        public enumParameterDirection ParameterDirection { get; set; }
        public string ParameterValue { get; set; }
        public int ParameterSize { get; set; }
        public enumDataType ParameterDataType_default { get; set; }
    }
    //Added for Datatype declaration
    public enum enumDataType
    {
        @String = 0,
        @Int = 1,
        @DateTime = 2,
        @Decimal = 3
    }

    public enum enumParameterDataType
    {
        @SQLBigint = 0,
        @SQLBinary = 1,
        @SQLBit = 2,
        @SQLChar = 3,
        @SQLDecimal = 5,
        @SQLDate = 31,
        @SQLDateTime = 4,
        @SQLInt = 8,
        @SQLMoney = 9,
        @SQLNVarChar = 12,
        @SQLTime = 32,
        //@numeric,
        @SQLSmallInt = 16,
        @SQLSmallMoney = 17,
        @SQLTinyInt = 20,
        @SQLFloat = 6,
        @SQLReal = 13,
        @SQLText = 18,
        @SQLVarchar = 22,
        @SQLNchar = 10,
        @SQLNText = 11,

        //Oracle
        //@OracleArray = 128,
        //@OracleBFile = 101,
        //@OracleBinaryDouble = 132,
        //@OracleBinaryFloat = 133,
        //@OracleBlob = 102,
        //@OracleByte = 103,
        //@OracleChar = 104,
        //@OracleClob = 105,
        //@OracleDate = 106,
        //@OracleDouble = 108,
        //@OracleInt16 = 111,
        //@OracleInt32 = 112,
        //@OracleInt64 = 113,
        //@OracleIntervalDS = 114,
        //@OracleIntervalYM = 115,
        //@OracleLong = 109,
        //@OracleLongRaw = 110,
        //@OracleNChar = 117,
        //@OracleNClob = 116,
        //@OracleNVarchar2 = 119,
        //@OracleObject = 129,
        //@OracleRaw = 120,
        //@OracleRef = 130,
        //@OracleRefCursor = 121,
        //@OracleSingle = 122,
        //@OracleTimeStamp = 123,
        //@OracleTimeStampLTZ = 124,
        //@OracleTimeStampTZ = 125,
        //@OracleVarChar2 = 126,
        //@OracleXmlType = 127
    }


    public enum enumParameterDirection
    {
        @Input = 1,
        @Output = 2,
        @InputOutput = 3,
        @ReturnValue = 6
    }
}
