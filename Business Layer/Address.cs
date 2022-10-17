using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem_INF2011S_Project.Business_Layer
{
    public class Address
    {

        #region Data Members 
        string town, city, streetName;
        int postalCode, addressID;
        #endregion

        #region Constructor
        public Address( string streetName, string town, string city, int postalCode )
        {
            this.addressID = 0;
            this.streetName = streetName;
            this.town = town;
            this.city = city;
            this.postalCode = postalCode;   
        }
        #endregion

        #region Property Methods
        public string Town 
        { 
            get { return town; }
            set { town = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public int PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; } 
        }
        public int AddressID
        {
            get { return addressID; }
            set
            {
                addressID = value;
            }   
        }
        
        public string StreetName
        {
            get { return streetName; }
            set
            {
                streetName = value;
            }   
        }
        #endregion

        public override string ToString()
        {
            return streetName + "\n" + town + "\n" + city + "\n" + postalCode.ToString();
        }
    }
}
