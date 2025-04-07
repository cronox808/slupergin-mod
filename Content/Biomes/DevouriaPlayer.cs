using Terraria;
using Terraria.ModLoader;
using Slupergin.Content.Biomes; // Asegura que importamos DevouriaBiome

namespace Slupergin.Content.Players
{
    public class DevouriaPlayer : ModPlayer
    {
        public bool ZoneDevouria; // Detecta si el jugador está en Devouria

        public override void ResetEffects()
        {
            ZoneDevouria = false; // Se resetea en cada frame
        }
    }
}
