using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Slupergin.Content.Players;
using Slupergin.Content.Tiles;

namespace Slupergin.Content.Biomes
{
    public class DevouriaBiome : ModBiome
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Sounds/Music/DevouriaTheme");

        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.Find<ModSurfaceBackgroundStyle>("Slupergin/DevouriaBackground");
        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

        public override bool IsBiomeActive(Player player)
        {
            int requiredTiles = 50; // Cantidad mínima de bloques para activar el bioma
            int tileCount = 0;
            int radius = 50;
            Point playerTile = player.Center.ToTileCoordinates();

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    Tile tile = Framing.GetTileSafely(playerTile.X + x, playerTile.Y + y);
                    if (tile.HasTile &&
                        (tile.TileType == ModContent.TileType<DevouriaGrass>() || tile.TileType == ModContent.TileType<DevouriaStone>()))
                    {
                        tileCount++;
                    }
                }
            }

            bool isActive = tileCount >= requiredTiles;
            player.GetModPlayer<DevouriaPlayer>().ZoneDevouria = isActive;
            return isActive;
        }
    }
}
