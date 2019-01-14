using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    class Turn
    {
        private int _PlayerOneRoll;

        public int PlayerOneRoll
        {
            get
            {
                return _PlayerOneRoll;
            }
            set
            {
                _PlayerOneRoll = value;
            }
        }

        public int PlayerTwoRoll { get; set; }

        public Turn()
        {

        }

        public Turn(int playerOne, int playerTwo)
        {
            PlayerOneRoll = playerOne;
            PlayerTwoRoll = playerTwo;
        }

        //methods
        //public string FindRollResults()
        //{
        // return null;
        //}
    }
}
