using Terraria;
using Terraria.ModLoader;
using Slupergin.Content.Players;


namespace Slupergin.Content.Systems
{
    public class DevouriaScene : ModSceneEffect
    {
        public override bool IsSceneEffectActive(Player player)
        {
            // Activa el efecto de bioma cuando el jugador está en Devouria
            return player.GetModPlayer<DevouriaPlayer>().ZoneDevouria;
        }

        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

        // Ya no usamos SpecialVisuals porque quitamos el shader
        public override void SpecialVisuals(Player player, bool isActive) { }

        public override void Load()
        {
            // No cargamos shaders, así que dejamos vacío
        }
    }
}
