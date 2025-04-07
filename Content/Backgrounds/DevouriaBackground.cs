using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Microsoft.Xna.Framework;

namespace Slupergin.Content.Backgrounds
{
    public class DevouriaBackground : ModSurfaceBackgroundStyle
    {
        private static Asset<Texture2D>[] BackgroundTextures;

        public override void Load()
        {
            // Cargar los fondos personalizados
            BackgroundTextures = new Asset<Texture2D>[]
            {
                ModContent.Request<Texture2D>("Slupergin/Assets/Backgrounds/DevouriaBgFar"),
                ModContent.Request<Texture2D>("Slupergin/Assets/Backgrounds/DevouriaBgMid"),
                ModContent.Request<Texture2D>("Slupergin/Assets/Backgrounds/DevouriaBgClose")
            };
        }

        public override void Unload()
        {
            BackgroundTextures = null;
        }

        public override int ChooseFarTexture()
        {
            return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Backgrounds/DevouriaBgFar");
        }

        public override int ChooseMiddleTexture()
        {
            return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Backgrounds/DevouriaBgMid");
        }

        public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
        {
            // En lugar de invalidar un método, manejamos aquí el comportamiento de la textura cercana
            return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Backgrounds/DevouriaBgClose");
        }

        public override void ModifyFarFades(float[] fades, float transitionSpeed)
        {
            for (int i = 0; i < fades.Length; i++)
            {
                fades[i] = MathHelper.Lerp(fades[i], 1f, transitionSpeed);
            }
        }
    }
}
