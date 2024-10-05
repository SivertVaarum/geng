using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace geng
{
    public class Map
    {
        private int[,] _map = new [,]
        {
            {1,0,0,0},
            {0,0,0,0},
            {1,0,1,0},
            {0,0,0,1}
        };
        private void LoadMap()
        { 
            
        }
        public SpriteBatch Draw( SpriteBatch spriteBatch,  Texture2D spriteSheet)
        {   //              0 >  4
            for(int y = 0; y <= _map.GetLength(1) -1 ; y++ ) //y value of map
            {
                for(int x = 0; x <= _map.GetLength(0) - 1; x++)//x value of map
                {
                    if(_map[x, y] == 1)
                    {//Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color)

                        spriteBatch.Draw(spriteSheet, new Rectangle(x*128, y*128, 128, 128), 
                                            new Rectangle(0, 0, 1, 1), Color.White);
                    }
                }
            }

            return spriteBatch;
        }

        

    }
}