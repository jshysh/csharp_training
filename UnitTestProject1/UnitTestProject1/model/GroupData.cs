using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
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

        public int CompareTo(GroupData other)
        {
            if(Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
         }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name = " +Name;
        }
    }
}
