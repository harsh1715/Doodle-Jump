//Doodle Jump 2.0
//Ashwin, Anthony and Harsh
//ICS 4U1

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DoodleJump_2._0
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Creates a random variable for random generator
        Random rnd = new Random();
        //creates a list for platform
        List<MainItem> platform = new List<MainItem>();
        //creates a list for bullet
        List<MovingGameItem> bullet = new List<MovingGameItem>();
        //creates a list for coin 
        List<MainItem> coin = new List<MainItem>();
        //creates a list for ghost
        List<MainItem> ghost = new List<MainItem>();
        //creates a list for star
        List<MainItem> star = new List<MainItem>();
        //creates an int variable for y
        int y = 300;
        //creates the mmovingGameItme for Character
        MovingGameItem currentCharacter;
        //creates an int for pointCounter
        int pointsCounter;
        //creates a spriteFont for font
        SpriteFont font;
        //creates a texture for bullet, ghost, star, and platform
        Texture2D bulletTexture, coinTexture, ghostTexture, starTexture, platformTexture;
        //creates a bool named startGame and sets it to false
        bool startGame = false;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //loads the texture from Content folder
            platformTexture = Content.Load<Texture2D>("Platform");
            //loads the texture from Content folder
            coinTexture = Content.Load<Texture2D>("Coin");
            //loads the texture from Content folder
            starTexture = Content.Load<Texture2D>("Star");
            //loads the texture from Content folder
            ghostTexture = Content.Load<Texture2D>("Ghost");
            //loads the texture from Content folder
            bulletTexture = Content.Load<Texture2D>("Bullet Right");
            //loads the texture from Content folder
            font = Content.Load<SpriteFont>("SpriteFont1");


            //adds a platform from the mainItem and changes the texture to floor so that the floor is known as a platform
            platform.Add(new MainItem(Content.Load<Texture2D>("Floor"), new Rectangle(0, GraphicsDevice.Viewport.Height - 50, 800, 50), Color.White));
            //creates a for loop when i is less than 5
            for (int i = 1; i < 5; i++)
            {
                //adds the platform and sets the x to random and y to 70 pixels up
                platform.Add(new MainItem(platformTexture, new Rectangle(rnd.Next(10, 600), platform[i - 1].getRectangle().Y - 70, 109, 26), Color.White));
            }

            //creates a for loop when i is less than 5
            for (int i = 0; i < 5; i++)
            {
                //checks if i equals 0
                if (i == 0)
                {
                    //adds the coin as a new mainItem and set the x to random if there is nothing in the list
                    coin.Add(new MainItem(coinTexture, new Rectangle(rnd.Next(10, 600), 300, 30, 35), Color.White));
                }
                else
                {
                    //adds the coin as a new mainItem and makes the Y go up by 300
                    coin.Add(new MainItem(coinTexture, new Rectangle(rnd.Next(10, 600), coin[i - 1].getRectangle().Y - 300, 30, 35), Color.White));
                }
            }

            //creates a for loop when i is less than 5
            for (int i = 0; i < 5; i++)
            {
                //checks if i equals 0
                if (i == 0)
                {
                    //adds the bullet as a new movingGameItem and set the x to random if there is nothing in the list
                    bullet.Add(new MovingGameItem(bulletTexture, new Rectangle(0, y-400, 50, 34), Color.White, 20, 0));
                }
                else
                {
                    //adds the bullet as a new movingGameItem and makes the Y go up by 400
                    bullet.Add(new MovingGameItem(bulletTexture, new Rectangle(0, bullet[i - 1].getRectangle().Y-400, 50, 34), Color.White, 20, 0));
                }
            }

            //creates a for loop when i is less than 5
            for (int i = 0; i < 5; i++)
            {
                //checks if i equals 0
                if (i == 0)
                {
                    //adds the ghost as a new mainItem and set the x to random if there is nothing in the list
                    ghost.Add(new MainItem(ghostTexture, new Rectangle(rnd.Next(0, 500), 800, 35, 36), Color.White));
                }
                else
                {
                    //adds the ghost as a new mainItem and makes the Y go up by 1500
                    ghost.Add(new MainItem(ghostTexture, new Rectangle(rnd.Next(0, 500), ghost[i - 1].getRectangle().Y - 1500, 35, 36), Color.White));
                }
            }

            //creates a for loop when i is less than 5
            for (int i = 0; i < 5; i++)
            {
                //checks if i equals 0
                if (i == 0)
                {
                    //adds the star as a new mainItem and set the x to random if there is nothing in the list
                    star.Add(new MainItem(starTexture, new Rectangle(rnd.Next(0, 500), y - 1000, 50, 34), Color.White));
                }
                else
                {
                    //adds the star as a new mainItem and makes the Y go up by 1000
                    star.Add(new MainItem(starTexture, new Rectangle(rnd.Next(0, 500), star[i-1].getRectangle().Y - 1000, 50, 34), Color.White));
                }
            }
            
            //creates the new movingGameItem for character
            currentCharacter = new MovingGameItem(Content.Load<Texture2D>("Character Right"), new Rectangle(0, 300, 65, 85), Color.White, 20, 0);
            //sets the yLimit to the first platform
            currentCharacter.setyLimit(platform[0].getRectangle().Top);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //declares the variable for the keyboard in order to takes its input
            KeyboardState key = Keyboard.GetState();
            //declares the variable for the XBOX 360 controller in order to takes its input
            GamePadState pad1 = GamePad.GetState(PlayerIndex.One);

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || key.IsKeyDown(Keys.Escape))
                this.Exit();

            //sets direction according to the player input
            currentCharacter.setDirectionalTextures(Content.Load<Texture2D>("Character Right"), Content.Load<Texture2D>("Character Left"));

            //If the Start Button or the Space Key is pressed then it will run to following
            if (pad1.Buttons.Start == ButtonState.Pressed || key.IsKeyDown(Keys.Space))
            {
                //It will set startGame to true
                startGame = true;
            }

            //If startGame is true then it will run the following
            if (startGame)
            {
                //If the TumbStick is moved to the Right or the Right key is pressed 
                if (pad1.ThumbSticks.Left.X > 0 || key.IsKeyDown(Keys.Right))
                {
                    //Sets the Border for the Character so it does not move out of the Right Border
                    if (currentCharacter.getRectangle().Right < 800)
                    {
                        //then it will move the Character 4 Pixels to the Right
                        currentCharacter.MoveX(4);
                    }
                }

                //If the TumbStick is moved to the Left or the Left key is pressed 
                else if (pad1.ThumbSticks.Left.X < 0 || key.IsKeyDown(Keys.Left))
                {
                    //Sets the Border for the Character so it does not move out of the Left Border
                    if (currentCharacter.getRectangle().Left > 0)
                    {
                        //then it will move the Character 4 Pixels to the Left
                        currentCharacter.MoveX(-4);
                    }
                }

                //Makes the Character jump 4 Pixels Down
                currentCharacter.jump(4);

                //If the Character Passes one half of the screen it moves the screen (Platforms) Up (Gives the illusion of it)
                if (currentCharacter.getRectangle().Bottom < GraphicsDevice.Viewport.Height / 2)
                {
                    //Makes the Character Move 5 Pixels Down
                    currentCharacter.MoveY(5);

                    //For every platform it will move it 5 Pixels Down
                    for (int i = 0; i < platform.Count; i++)
                    {
                        platform[i].MoveY(5);
                    }

                    //For every coin it will move it 5 Pixels Down
                    for (int i = 0; i < coin.Count; i++)
                    {
                        coin[i].MoveY(5);
                    }

                    //For every ghost it will move it 5 Pixels Down
                    for (int i = 0; i < ghost.Count; i++)
                    {
                        ghost[i].MoveY(5);
                    }

                    //For every star it will move it 5 Pixels Down
                    for (int i = 0; i < star.Count; i++)
                    {
                        star[i].MoveY(5);
                    }

                    //For every bullet it will move it 5 Pixels Down
                    for (int i = 0; i < bullet.Count; i++)
                    {
                        bullet[i].MoveY(5);
                    }
                }

                //For every bullet it will run the following
                for (int i = 0; i < bullet.Count; i++)
                {
                    //Sets the speed for the bullet to move 2 Pixels to the Right
                    bullet[i].MoveX(2);

                    //If the Bullet hits the Right Border or the right side of the screen it will run the following
                    if (bullet[i].getRectangle().Right == GraphicsDevice.Viewport.Width)
                    {
                        //It will First remove the bullet
                        bullet.RemoveAt(i);
                        //Subtract one bullet from the bullet count
                        i--;
                        //Loads the content of the bullet
                        bullet.Add(new MovingGameItem(bulletTexture, new Rectangle(0, 150, 50, 34), Color.White, 20, 0));
                    }
                }

                //For every platform in the list it will run the following
                for (int i = platform.Count - 1; i >= 0; i--)
                {
                    //Checks to see if the Character interected with the platform
                    if (currentCharacter.getRectangle().Right > platform[i].getRectangle().Left && currentCharacter.getRectangle().Left < platform[i].getRectangle().Right && currentCharacter.getRectangle().Bottom < platform[i].getRectangle().Top)
                    {
                        //Sets the yLimit to the platforms and allows the Character to stand on top of the platform
                        currentCharacter.setyLimit(platform[i].getRectangle().Top);
                        //Breaks the If Loop
                        break;
                    }

                    //Else it will run the following
                    else
                    {
                        //Sets the yLimit to the height of the screen + 50
                        currentCharacter.setyLimit(GraphicsDevice.Viewport.Height + 50);
                    }

                }

                //For every platform in the list it will run the following
                for (int i = 0; i < platform.Count; i++)
                {
                    //If the platform touches the bottom of the screen it will run the following
                    if (platform[i].getRectangle().Top > 480)
                    {
                        //It will First remove the platform
                        platform.RemoveAt(i);
                        //Subtract one bullet from the platform count
                        i--;
                        //Loads the content of the platform
                        platform.Add(new MainItem(platformTexture, new Rectangle(rnd.Next(10, 600), 150, 109, 26), Color.White));

                    }
                }

                //creates a for loop that is less than coinCount
                for (int i = 0; i < coin.Count; i++)
                {
                    //checks if top of the coin is greater than the height of the screen
                    if (coin[i].getRectangle().Top > GraphicsDevice.Viewport.Height)
                    {
                        //removes coin from the screen
                        coin.RemoveAt(i);
                        //adds the coin as a new mainItem and set the x to random and makes y go up by 300
                        coin.Add(new MainItem(coinTexture, new Rectangle(rnd.Next(10, 600), y - 300, 30, 35), Color.White));
                    }
                    //checks if character intesects with coin
                    if (currentCharacter.getRectangle().Intersects(coin[i].getRectangle()))
                    {
                        //increases points by 20
                        pointsCounter += 20;
                        //removes coin once character hits coin
                        coin.RemoveAt(i);
                        //adds the coin as a new mainItem and set the x to random and makes y go up by 800
                        coin.Add(new MainItem(coinTexture, new Rectangle(rnd.Next(10, 600), y - 800, 30, 35), Color.White));

                    }
                }

                //creates a for loop that is less than ghostCount
                for (int i = 0; i < ghost.Count; i++)
                {
                    //checks if top of the ghost is greater than the height of the screen
                    if (ghost[i].getRectangle().Top > GraphicsDevice.Viewport.Height)
                    {
                        //removes ghost from the screen
                        ghost.RemoveAt(i);
                        //adds the ghost as a new mainItem and set the x to random and makes y go up by 800
                        ghost.Add(new MainItem(ghostTexture, new Rectangle(rnd.Next(0, 500), y - 800, 35, 36), Color.White));
                    }
                    //checks if character intesects with ghost
                    if (currentCharacter.getRectangle().Intersects(ghost[i].getRectangle()))
                    {
                        //decreases points by 40
                        pointsCounter -= 40;
                        //removes ghost once character hits ghost
                        ghost.RemoveAt(i);
                        //adds the ghost as a new mainItem and set the x to random and makes y go up by 800
                        ghost.Add(new MainItem(ghostTexture, new Rectangle(rnd.Next(0, 500), y - 800, 35, 36), Color.White));

                    }
                }

                //creates a for loop that is less than starCount
                for (int i = 0; i < star.Count; i++)
                {
                    //checks if top of the star is greater than the height of the screen
                    if (star[i].getRectangle().Top > GraphicsDevice.Viewport.Height)
                    {
                        //removes star from the screen
                        star.RemoveAt(i);
                        //adds the star as a new mainItem and set the x to random and makes y go up by 1000
                        star.Add(new MainItem(starTexture, new Rectangle(rnd.Next(0, 500), y - 1000, 50, 34), Color.White));
                    }
                    //checks if character intesects with star
                    if (currentCharacter.getRectangle().Intersects(star[i].getRectangle()))
                    {
                        //increases points by 40
                        pointsCounter += 40;
                        //removes star once character hits star
                        star.RemoveAt(i);
                        //adds the star as a new mainItem and set the x to random and makes y go up by 1000
                        star.Add(new MainItem(starTexture, new Rectangle(rnd.Next(0, 500), y - 1000, 50, 34), Color.White));
                    }
                }

                //If the Character hits the bottom of the screen the program will end
                if (currentCharacter.getRectangle().Bottom > GraphicsDevice.Viewport.Height)
                {
                    //exits the screen 
                    this.Exit();
                }

                //creates a for loop that is less than bulletCount
                for (int i = 0; i < bullet.Count; i++)
                {
                    //checks if character intersects with bullet
                    if (currentCharacter.getRectangle().Intersects(bullet[i].getRectangle()))
                    {
                        //exits the screen if character intersects with bullet
                        this.Exit();
                    }
                }

                //checks if pointCounter is less than 0
                if (pointsCounter < 0)
                {
                    //exits the screen if pointCounter is less than 0
                    this.Exit();
                }
            }

            //Updates the Character
            currentCharacter.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //creates a vector2 for scoreLocation
            Vector2 scoreLocation = new Vector2(0, 0);
            //creates a vector2 for instructionLocation
            Vector2 instructionLocation = new Vector2(320, 0);

            //begins the spriteBatch
            spriteBatch.Begin();
            //draws the character
            currentCharacter.DrawContent(spriteBatch);
            //creates a for loop to draw the platform
            for (int i = 0; i < platform.Count; i++)
            {
                //draws the platform
                platform[i].DrawContent(spriteBatch);
            }
            //creates a for loop to draw the ghost
            for (int i = 0; i < ghost.Count; i++)
            {
                //draws the ghost
                ghost[i].DrawContent(spriteBatch);
            }
            //creates a for loop to draw the star
            for (int i = 0; i < star.Count; i++)
            {
                //draws the star
                star[i].DrawContent(spriteBatch);
            }
            //creates a for loop to draw the coin
            for (int i = 0; i < coin.Count; i++)
            {
                //draws the coin
                coin[i].DrawContent(spriteBatch);
            }
            //creates a for loop to draw the bullet
            for (int i = 0; i < bullet.Count; i++)
            {
                //draws the bullet
                bullet[i].DrawContent(spriteBatch);
            }
            //draws the text to display score
            spriteBatch.DrawString(font, " Player Score: " + pointsCounter, scoreLocation, Color.Black);
            //draws the text to display instructions to play the game
            spriteBatch.DrawString(font, "*Try getting as much points as you can" + "\n*If you fall, get hit or have less than 0 you die", instructionLocation, Color.Black);
            //ends the spriteBatch
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
