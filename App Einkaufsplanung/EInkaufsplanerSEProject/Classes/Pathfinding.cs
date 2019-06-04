using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using RoyT.AStar;

namespace EInkaufsplanerSEProject.Classes
{
    class Pathfinding
    {
        private List<Product> products;
        private Product[] sortedProducts;
        private Grid map;
        private Position entrance;
        private Position exit;

        public Pathfinding(List<Product> products)
        {
            this.products = products;
            this.entrance = new Position(0, 0);
            this.exit = new Position(9, 9);
        }


        public void FindPath()
        {
            CreateMap();
            SortList();
        }

        private void CreateMap()
        {
            map = new Grid(10, 10, 1.0f);
            map.BlockCell(new Position(2, 1));
            map.BlockCell(new Position(3, 2));
            map.BlockCell(new Position(3, 3));
            map.BlockCell(new Position(3, 4));
            map.BlockCell(new Position(3, 5));
            map.BlockCell(new Position(3, 6));
            map.BlockCell(new Position(3, 7));
            map.BlockCell(new Position(5, 8));
            map.BlockCell(new Position(6, 8));
            map.BlockCell(new Position(7, 8));
            map.BlockCell(new Position(8, 8));
            map.BlockCell(new Position(9, 8));
        }

        private void SortList()
        {
            bool sorted = false;
            Position product1;
            Position product2;
            int pathlengthproduct1;
            int pathlengthproduct2;
            sortedProducts = products.ToArray();

            do
            {
                sorted = true;

                for (int i = 0; i < sortedProducts.Length - 1; i++)
                {
                    /*product1 = new Position(sortedProducts[i].x, sortedProducts[i].y);
                    product2 = new Position(sortedProducts[i + 1].x, sortedProducts[i + 1].y);
                    pathlengthproduct1 = map.GetPath(entrance, product1).Length;
                    pathlengthproduct2 = map.GetPath(entrance, product2).Length;
                    if (pathlengthproduct1 > pathlengthproduct2)
                    {
                        Product temp = sortedProducts[i];
                        sortedProducts[i] = sortedProducts[i + 1];
                        sortedProducts[i + 1] = temp;

                        sorted = false;
                    }*/
                }

            } while (!sorted);
        }
    }
}