using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace geng
{
    public class Map
    {
        private int[,] _map = new[,]//test map
        {
            {1,0,1,0},
            {0,0,0,0},
            {1,0,1,0},
            {0,1,0,0}
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
                        spriteBatch.Draw(spriteSheet, new Rectangle(i * 128, j * 128, 128, 128),
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
        }

        

    }
}