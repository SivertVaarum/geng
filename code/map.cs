using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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
            {0,0,0,0,0,1},
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
            //Check for collision, resolve using IEntity.ResolveCollision()
            Rectangle entityRectangle = entity.GetRectangle();

            int entityTileX = entityRectangle.X / _tileDimension;
            int entityTileY = entityRectangle.Y / _tileDimension;
            int entityTileXW = (entityRectangle.X + entityRectangle.Width-1) / _tileDimension;
            int entityTileYH = (entityRectangle.Y + entityRectangle.Height-1) / _tileDimension;

            try //Temp fix
            {
                if (_map[entityTileY, entityTileX] == 1
                || _map[entityTileY, entityTileXW] == 1
                || _map[entityTileYH, entityTileX] == 1
                || _map[entityTileYH, entityTileXW] == 1)
                {
                    int xOverlap = 0;
                    int yOverlap = 0;
                    if (entity.getXVelocity == 1)
                    {
                        xOverlap = -(entityRectangle.Right - (entityTileX * _tileDimension) - _tileDimension);
                    }
                    else if (entity.getXVelocity == -1)
                    {
                        xOverlap = (entityTileX * _tileDimension) - entityRectangle.Left + _tileDimension;
                    }
                    if (entity.getYVelocity == 1)
                    {
                        yOverlap = -(entityRectangle.Bottom - (entityTileY * _tileDimension) - _tileDimension);
                    }
                    else if (entity.getYVelocity == -1)
                    {
                        yOverlap = (entityTileY * _tileDimension) - entityRectangle.Top + _tileDimension;
                    }
                    
                    entity.ResolveCollision(xOverlap, yOverlap);
                }   
            }
            catch (System.IndexOutOfRangeException e) { }
        } 
    }
}