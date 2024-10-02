using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Doodle_Jump_Game
{
    class MainItem
    {
        //Variables for the rectangle, color and texture2d
        protected Texture2D sprite;
        protected Rectangle rectangle;
        protected Color color;

        public MainItem(Texture2D sprite, Rectangle rectangle, Color color)//We set the constructor with the variables needed such for inheriting
        {
            this.setSprite(sprite);
            this.setRectangle(rectangle);
            this.setColor(color);
        }
        public Texture2D getSprite()//We get the texture set by the user
        {
            return sprite;
        }
        public void setSprite(Texture2D aSprite)//Set the texture to equal the texture the user inputed
        {
            sprite = aSprite;
        }

        public Rectangle getRectangle()//We get the rectangle set by the user
        {
            return rectangle;
        }
        public void setRectangle(Rectangle aRectangle)//Set the rectangle to equal the rectangle the user inputed
        {
            rectangle = aRectangle;
        }

        public Color getColor()//We get the rectangle set by the user
        {
            return color;
        }
        public void setColor(Color aColor)//Set the color to equal the color the user inputed
        {
            color = aColor;
        }


        public void MoveY(int speedY)//We move the specific rectangle in the y axis with an interger
        {
            this.rectangle.Y += speedY;
        }


        public void DrawContent(SpriteBatch sprite)//Draws the variable we set it up to
        {
            sprite.Draw(this.sprite, this.rectangle, this.color);
        }
    }
}
