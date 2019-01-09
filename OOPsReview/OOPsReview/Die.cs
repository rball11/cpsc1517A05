using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Die
    {
        //this is the definition of an object 
            //it is a conceptual view of the data that will be held by a physical instance (object) of this class

        //Data Members
            // is an internal private data storage item
            // private data members CANNOT be reached directly by the user
            // public data members CAN be reached directly by the user
        private int _Size;

        //Properties
            //a property is an external interface between the user and a SINGLE piece of data within the instance
            //a property has two abilities:
                //a) the ability to assign a value to the internal data member
                //b) return an internal data member value to the user
            
        //Fully Implemented Property
        public int Size
        {
            get
            {
                //takes internal values and returns it to the user
                return _Size;
            }
            set
            {
                //takes the supplied user value and places it into the internal private data member
                //the incoming piece of data is placed into a special variable that is called: value
                _Size = value;
            }
        }

        //Constructors

        //Behaviours (methods)
    }
}
