using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Slupergin.Content.Tiles; // Asegura que los bloques personalizados están accesibles

namespace Slupergin.Content.Biomes
{
    public class DevouriaBiome : ModBiome
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

        public override void OnEnter(Player player)
        {
            Main.NewText("Has entrado en Devouria", 255, 255, 0);
        }

        public override void OnLeave(Player player)
        {
            Main.NewText("Has salido de Devouria", 255, 255, 0);
        }

        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/DevouriaTheme");

        public override string BestiaryIcon => "Slupergin/Content/Backgrounds/DevouriaBestiary";
        public override string BackgroundPath => "Slupergin/Content/Backgrounds/DevouriaBackground1"; // Fondo principal
        public override Color? BackgroundColor => Color.DarkGoldenrod;

        public override void SpecialVisuals(Player player, bool isActive)
        {
            player.ManageSpecialBiomeVisuals("Slupergin:DevouriaBackground", isActive);
        }

        // 🔥 DETECCIÓN DE BLOQUES PARA ACTIVAR EL BIOMA 🔥
        public override bool IsBiomeActive(Player player)
        {
            int tileCount = 0;
            int requiredTiles = 50; // Número de bloques necesarios para activar el bioma

            int startX = (int)(player.position.X / 16) - 50; // Revisar 50 tiles alrededor
            int endX = (int)(player.position.X / 16) + 50;
            int startY = (int)(player.position.Y / 16) - 50;
            int endY = (int)(player.position.Y / 16) + 50;

            for (int i = startX; i < endX; i++)
            {
                for (int j = startY; j < endY; j++)
                {
                    Tile tile = Framing.GetTileSafely(i, j);

                    if (tile.HasTile && (
                        tile.TileType == ModContent.TileType<DevouriaGrass>() ||
                        tile.TileType == ModContent.TileType<DevouriaStone>()
                    ))
                    {
                        tileCount++;
                        if (tileCount >= requiredTiles)
                        {
                            return true; // Se activa el bioma cuando hay suficientes bloques
                        }
                    }
                }
            }

            return false; // No hay suficientes bloques para activar el bioma
        }
    }
}
