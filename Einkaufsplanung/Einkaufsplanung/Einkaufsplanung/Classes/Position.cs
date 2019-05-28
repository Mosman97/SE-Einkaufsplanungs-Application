using System;
using System.Collections.Generic;
using System.Text;

namespace Einkaufsplanung.Classes
{
    class Position
    {
        /// <summary>
        /// Int that contains a number assigned to a shelf
        /// </summary>
        int shelf_;

        /// <summary>
        /// Int that contains a number assigned to a column in a shelf 
        /// </summary>
        int column_;

        /// <summary>
        /// Array that contains all Products in a column of a shelf
        /// </summary>
        List<Product> produkte_ = new List<Product>();

        public Position(int shelf, int column)
        {
            shelf_ = shelf;
            column_ = column;
        }
    }
}
