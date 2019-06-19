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
using System.Drawing;
using Android.Graphics;
using Android.Content.Res;

namespace EInkaufsplanerSEProject.Classes
{
    class Pathfinding
    {
        private List<Product> products;
        private Shoppinglist shoppinglist;
        private List<Position> finalpath;
        private Product[] sortedProducts;
        private Grid map;
        private Position entrance;
        private Position exit;
        private Bitmap assetmap;
        private Bitmap finalmap;

        AssetManager assets = Android.App.Application.Context.Assets;

        public Pathfinding(Shoppinglist p)
        {
            this.products = p.Products;
            finalmap = BitmapFactory.DecodeStream(assets.Open("Supermarket.bmp"));
            assetmap = BitmapFactory.DecodeStream(assets.Open("Supermarket.bmp"));
        }


        public Bitmap FindPath()
        {
            CreateMap();
            SortList();
            CreateBitmap();
            return finalmap;
        }

        private void CreateMap()
        {
            int mapwidth = 0;
            int mapheight = 0;

            Android.Graphics.Color cblack = new Android.Graphics.Color(255, 255, 255);
            Android.Graphics.Color cred = new Android.Graphics.Color(255, 0, 0);
            Android.Graphics.Color cgreen = new Android.Graphics.Color(0, 255, 0);

            mapwidth = assetmap.Width;
            mapheight = assetmap.Height;

            map = new Grid(mapwidth, mapheight, 1.0f);

            for (int i = 0; i < mapwidth; i++)
            {
                for (int j = 0; j < mapheight; j++)
                {
                    if (assetmap.GetPixel(i, j) == cblack)
                    {
                        map.BlockCell(new Position(i, j));
                    }
                    else if (assetmap.GetPixel(i, j) == cred)
                    {
                        entrance = new Position(i, j);
                    }
                    else if (assetmap.GetPixel(i, j) == cgreen)
                    {
                        exit = new Position(i, j);
                    }
                }
            }
        }

        private void SortList()
        {
            bool sorted = false;
            Position product1;
            Position product2;
            Position current = entrance;
            Position[] tmppath;
            int pathlengthproduct1;
            int pathlengthproduct2;
            sortedProducts = products.ToArray();

            for (int j = 0; j < sortedProducts.Length - 1; j++)
            {
                do
                {
                    sorted = true;

                    for (int i = j; i < sortedProducts.Length - 1; i++)
                    {
                        product1 = new Position(sortedProducts[i].Pos_x, sortedProducts[i].Pos_y);
                        product2 = new Position(sortedProducts[i + 1].Pos_x, sortedProducts[i + 1].Pos_y);
                        pathlengthproduct1 = map.GetPath(current, product1).Length;
                        pathlengthproduct2 = map.GetPath(current, product2).Length;
                        if (pathlengthproduct1 > pathlengthproduct2)
                        {
                            Product temp = sortedProducts[i];
                            sortedProducts[i] = sortedProducts[i + 1];
                            sortedProducts[i + 1] = temp;

                            sorted = false;
                        }
                    }

                } while (!sorted);

                tmppath = map.GetPath(current, new Position(sortedProducts[j].Pos_x, sortedProducts[j].Pos_y));
                finalpath.AddRange(tmppath);

                current = new Position(sortedProducts[j].Pos_x, sortedProducts[j].Pos_y);
            }

            tmppath = map.GetPath(current, exit);
            finalpath.AddRange(tmppath);
        }

        private void CreateBitmap()
        {
            foreach (Position p in finalpath)
            {
                finalmap.SetPixel(p.X, p.Y, Android.Graphics.Color.Red);
            }
        }
    }
}