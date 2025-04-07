using Terraria.ModLoader;

namespace Slupergin
{
    public class Slupergin : Mod
    {
        public override void Load()
        {
            ModContent.GetInstance<Content.Biomes.DevouriaBiome>(); // Registra el bioma
        }
    }
}
