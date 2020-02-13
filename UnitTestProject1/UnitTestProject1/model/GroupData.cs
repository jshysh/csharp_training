using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData
    {
        private string groupName;
        private string groupHeader;
        private string groupFooter;

        public GroupData(string groupName)
        {
            this.groupName = groupName;
        }

        public string Name
        {
            get
            {
                return groupName;
            }
            set
            {
                groupName = value;
            }
        }

        public string Header
        {
            get
            {
                return groupHeader;
            }
            set
            {
                groupHeader = value;
            }
        }
        public string Footer
        {
            get
            {
                return groupFooter;
            }
            set
            {
                groupFooter = value;
            }
        }
    }
}
