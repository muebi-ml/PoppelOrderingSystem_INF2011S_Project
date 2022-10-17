using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem_INF2011S_Project.Business_Layer
{
    public class MarkettingClerk
    {
        #region Attributes
        private int clerkID;
        #endregion

        public MarkettingClerk( int clerkID )
        {
            this.clerkID = clerkID;
        }
        #region Property Methods
        public int ClerkID
        {
            get { return clerkID; }
        }
        #endregion
    }
}
