using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer
{
    public class AdminAccessBAL
    {
        AdminAccessDAL obAdminDAL = new AdminAccessDAL();
        protected DataTable GetTypeList()
        {
            return obAdminDAL.GetTypeList();
        }
    }
}
