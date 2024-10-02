using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
// using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Doodle_Jump_Game
{
    class MovingGameItem : MainItem
    {
        //creates variable for jumping, falling, currentUpper, maxUpper, gravity and yLimit
        bool isJumping;
        bool isFalling;
        int currentUpper, maxUpper, gravity;
        int yLimit;
        private Texture2D leftTexture, rightTexture;

        //Creates a constructor for movingGameItem that inherits everything from MainItem
        public MovingGameItem(Texture2D newTexture, Rectangle rectangle, Color color, int newUpper, int currentUpper) : base(newTexture, rectangle, color)
        {
            this.setmaxUpper(newUpper);
            currentUpper = 0;
            gravity = 2;
            this.setDirectionalTextures(newTexture, newTexture);
        }

        //gets the maxUpper from the user
        public int getmaxUpper()
        {
            return maxUpper;
        }
        //sets the maxUpper equal to the maxUpper the user inputted
        public void setmaxUpper(int MaxUpper)
        {
            maxUpper = MaxUpper;
        }

        //gets the yLimit from the user
        public int getyLimit()
        {
            return yLimit;
        }
        //sets the yLimit equal to the yLimit the user inputted
        public void setyLimit(int Limit)
        {
            this.yLimit = Limit;
        }

        //creates the setDirection for player
        public void setDirectionalTextures(Texture2D rightplayer, Texture2D leftplayer)
        {
            this.rightTexture = rightplayer;
            this.leftTexture = leftplayer;
        }

        //We move the specific rectangle in the x axis with an interger
        public void MoveX(int speedX)
        {
            this.rectangle.X += speedX;
            //chechks if speed is greater than 0
            if (speedX > 0)
            {
                //sets texture to right
                this.setSprite(rightTexture);
            }
            //checks if speed is less than 0
            if (speedX < 0)
            {
                //sets texture to left
                this.setSprite(leftTexture);
            }
        }

        //creates a method for jump
        public void jump(int maxUpper)
        {
            //checks if not isJumping and not is Falling 
            if (!isJumping && !isFalling)
            {
                //sets currentUpper to maxUpper
                this.currentUpper = this.maxUpper;
                //changes isJumping to true
                this.isJumping = true;
                //changes isFalling to true
                this.isFalling = true;
            }
        }

        //creates an update method
        public virtual void Update(GameTime gameTime)
        {
            //checks if isJumping is true
            if (isJumping)
            {
                //changes moveY to go down by currentUpper
                this.MoveY(-currentUpper);
                //cuurentUpper goes down by one
                --currentUpper;
                //checks if currentUpper is less than or equal to 0
                if (currentUpper <= 0)
                {
                    //changes isJumping to false
                    isJumping = false;
                }
            }
            //checks if isFalling is true
            if (isFalling)
            {
                //changes the moveY to gravity
                this.MoveY(gravity);
                //checks if bottom of the rectangle is greater or equal to the yLimit
                if (this.rectangle.Bottom >= yLimit)
                {
                    //sets rectangle equal to yLimit minus the rectangle height
                    this.rectangle.Y = yLimit - this.rectangle.Height;
                    //changes isJumping to false
                    this.isJumping = false;
                    //changes isFalling to false
                    this.isFalling = false;
                }
            }
            //checks if bottom of teh rectangle is less than yLimit
            if (this.rectangle.Bottom < yLimit)
            {
                //sets isFalling to true
                this.isFalling = true;
            }
        }
    }
}
