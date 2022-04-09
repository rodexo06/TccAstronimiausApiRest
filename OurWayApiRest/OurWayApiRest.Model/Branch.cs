using System;
namespace OurWayApiRest.Model
{
    public class Branch
    {
        public Branch(int cIdBranch, int cIdAddress, string sBranch, bool enabled, DateTime dLastUpdate)
        {
            this.CIdBranch = cIdBranch;
            this.CIdAddress = cIdAddress;
            this.SBranch = sBranch;
            this.Enabled = enabled;
            this.DLastUpdate = dLastUpdate;
        }

        public int CIdBranch{ get; set; }
        public int CIdAddress{ get; set; }
        public String SBranch{ get; set; }
        public bool Enabled{ get; set; }
        public DateTime DLastUpdate{ get; set; }

    }

    public class UserBranch
    {
        public UserBranch(int cIdUser, int cIdBranch, bool enabled, DateTime dLastUpdate)
        {
            this.CIdUser = cIdUser;
            this.CIdBranch = cIdBranch;
            this.Enabled = enabled;
            this.DLastUpdate = dLastUpdate;
        }

        public int CIdUser{ get; set; }
        public int CIdBranch{ get; set; }
        public bool Enabled{ get; set; }
        public DateTime DLastUpdate{ get; set; }
    }
}
