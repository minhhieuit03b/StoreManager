using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHVatLieuXayDung.DA_Layer;
using System.Data;
using System.Data.SqlClient;

namespace CHVatLieuXayDung.BL_Layer
{
    class BLChiNhanh
    {
        DataProvider dp;
        public BLChiNhanh(string dbsource, string id, string pass)
        {
            dp = new DataProvider(dbsource, id, pass);
            dp.InitialConnectionString(dbsource, id, pass);
        }
        public DataTable LayBangChiNhanh()
        {
            return dp.ExecuteQueryDataTable("spLayBangChiNhanh", CommandType.StoredProcedure);
        }
        public DataTable LayTenTable()
        {
            return dp.ExecuteQueryDataTable("spLayTenAllTable", CommandType.StoredProcedure);
        }
        public DataTable LayThongTinCN()
        {
            return dp.ExecuteQueryDataTable("spLayThongTinCN", CommandType.StoredProcedure);
        }

    }
}
