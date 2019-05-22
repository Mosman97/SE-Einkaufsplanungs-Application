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
        int shelf;

        /// <summary>
        /// Int that contains a number assigned to a column in a shelf 
        /// </summary>
        int column;

        /// <summary>
        /// Array that contains all Products in a column of a shelf
        /// </summary>
        Product[] listofProducts;

        public Position(int shelf, int column, Product[] listofProducts)
        {
            this.shelf = shelf;
            this.column = column;

        }
    }
}
