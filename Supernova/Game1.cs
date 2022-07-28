using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Supernova
{
    internal class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private ManagerNetwork managerNetwork;
        private ManagerInput managerInput;

        private Texture2D texture; //Testing
        private SpriteFont font; //Testing

        public Game1() : base()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content\\Assets";
            
            managerNetwork = new ManagerNetwork();
            managerInput = new ManagerInput(managerNetwork);

            this.IsFixedTimeStep = true;
            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            managerNetwork.Start();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = this.Content.Load<Texture2D>("blank"); //Testing
            font = this.Content.Load<SpriteFont>("font"); //Testing

            base.LoadContent();
        }

        protected override void UnloadContent()
        {

            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            managerNetwork.Update();
            managerInput.Update(gameTime.ElapsedGameTime.Milliseconds);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if(managerNetwork.Active)
                GraphicsDevice.Clear(Color.Green);
            else
                GraphicsDevice.Clear(Color.Red);

            spriteBatch.Begin();

            if (managerNetwork.Active)
            {
                foreach(var player in managerNetwork.Players)
                {
                    spriteBatch.Draw(texture, new Rectangle(player.PositionX, player.PositionY, 50, 50), Color.BlueViolet);
                    spriteBatch.DrawString(font, player.ID.ToString(), new Vector2(player.PositionX + 5, player.PositionY + 25), Color.Black);

                    if(player.ID != managerNetwork.UserID)
                    {
                        spriteBatch.DrawString(font, player.Name, new Vector2(player.PositionX + 5, player.PositionY + 5), Color.Black);
                    }
                }
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
