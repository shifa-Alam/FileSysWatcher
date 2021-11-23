using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSysWatcher
{
    public class ExcelInputModel
    {
        public long TenantId
        {
            get;
            set;
        }

        public long HrConfigId
        {
            get;
            set;
        }

        public long StockConfigId
        {
            get;
            set;
        }

        public long BranchId
        {
            get;
            set;
        }

        public long StoreId
        {
            get;
            set;
        }

        public DateTime DateTime
        {
            get;
            set;
        }

        public CustomFileInputModel CustomFile
        {
            get;
            set;
        }
    }
}
