using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace geng
{
    public class Map
    {
        private int _mapHeight, _mapWidth;
        public int MapHeight
        {
            get => _map.GetLength(0) * _tileDimension;
        }
        public int MapWidth
        {
            get => _map.GetLength(1) * _tileDimension;
        }
        private int _tileDimension = 128;
        private int[,] _map = new[,]//test map
        {
            {1,0,0,0,0,1},
            {0,0,0,0,0,0},
            {1,0,0,0,1,1},
            {1,1,0,1,1,1}
        };

        /// <summary>
        /// Loads map into 2d array
        /// </summary>
        private void LoadMap()
        {
            //TODO, load maps from seperate files that will be written into the _map array.
        }

        public SpriteBatch Draw(SpriteBatch spriteBatch, Texture2D spriteSheet)
        {   //              0 >  4
            for (int i = 0; i <= _map.GetLength(1) - 1; i++) //y value of map
            {
                for (int j = 0; j <= _map.GetLength(0) - 1; j++)//x value of map
                {
                    if (_map[j, i] == 1)
                    {
                        //Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color)
                        spriteBatch.Draw(spriteSheet, new Rectangle(i * _tileDimension, j * _tileDimension, _tileDimension, _tileDimension),
                                            new Rectangle(0, 0, 1, 1), Color.White);
                    }
                }
            }
            return spriteBatch;
        }

        /// <summary>
        /// Checks collision for given Entity
        /// and resolves using Entities ResolveCollision()
        /// </summary>
        /// <param name="entity"></param>
        public void CheckCollision(IEntity entity)
        {
            Rectangle rect = entity.Rectangle;

            // Convert entity position to tile coordinates
            int leftEdge   = Math.Max(0, rect.Left / _tileDimension);
            int rightEdge  = Math.Min(_map.GetLength(1) - 1, rect.Right / _tileDimension);
            int topEdge    = Math.Max(0, rect.Top / _tileDimension);
            int bottomEdge = Math.Min(_map.GetLength(0) - 1, rect.Bottom / _tileDimension);
            int offX = 0;
            int offY = 0;

            for (int y = topEdge; y <= bottomEdge; y++)
            {
                for (int x = leftEdge; x <= rightEdge; x++)
                {
                    if (_map[y, x] != 1)
                    {
                        continue;
                    }

                    // Compute tile boundaries
                    int tileLeft = x * _tileDimension;
                    int tileRight = tileLeft + _tileDimension;
                    int tileTop = y * _tileDimension;
                    int tileBottom = tileTop + _tileDimension;

                    // Check intersection
                    if (rect.Right > tileLeft && rect.Left < tileRight && rect.Bottom > tileTop && rect.Top < tileBottom)
                    {
                        // Compute overlap distances on each side
                        int overlapLeft = rect.Right - tileLeft;
                        int overlapRight = tileRight - rect.Left;
                        int overlapTop = rect.Bottom - tileTop;
                        int overlapBottom = tileBottom - rect.Top;

                        // Find the smallest overlap (shallowest penetration)
                        int minXOverlap = (overlapLeft < overlapRight) ? -overlapLeft : overlapRight;
                        int minYOverlap = (overlapTop < overlapBottom) ? -overlapTop : overlapBottom;

                        // Prioritize shallower axis for resolution
                        if (Math.Abs(minXOverlap) < Math.Abs(minYOverlap))
                        {
                            offX = minXOverlap;
                        }
                        else
                        {
                            offY = minYOverlap;
                        }
                    }
                }
            }

            if (offX != 0 || offY != 0)
            {
                entity.ResolveCollision(offX, offY);
            }
        }
    }
}