using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;


namespace Slupergin.Content.Backgrounds
{
    public class DevouriaSky : CustomSky
    {
        private bool isActive = false;

        public override void Update(GameTime gameTime)
        {
            // Aquí puedes agregar animaciones si lo deseas
        }

        public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
        {
            if (maxDepth >= 0 && minDepth < 0)
            {
                Texture2D backgroundTexture = ModContent.Request<Texture2D>("Slupergin/Content/Backgrounds/DevouriaBackground1").Value;
                spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.White);
            }
        }

        public override void Activate(Vector2 position, params object[] args)
        {
            isActive = true;
        }

        public override void Deactivate(params object[] args)
        {
            isActive = false;
        }

        public override bool IsActive()
        {
            return isActive;
        }

        public override void Reset()
        {
            isActive = false;
        }
    }
}
