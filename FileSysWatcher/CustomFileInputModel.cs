using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSysWatcher
{
    public class CustomFileInputModel
    {
        public string Name
        {
            get;
            set;
        }

        public long Size
        {
            get;
            set;
        }

        public long DocTypeId
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public string FileData
        {
            get;
            set;
        }

        public DateTime? LastModifiedDate
        {
            get;
            set;
        }

        public IList<string> Tags
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string Note
        {
            get;
            set;
        }

        public long? Version
        {
            get;
            set;
        }

        public DateTime? CreatedDate
        {
            get;
            set;
        }

        public bool IsFolder
        {
            get;
            set;
        }

        public string FileTypeName
        {
            get;
            set;
        }

        public IList<string> Parents
        {
            get;
            set;
        }

        public CustomFileInputModel()
        {
            Tags = new List<string>();
            Parents = new List<string>();
        }
    }
}
