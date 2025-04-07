using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Slupergin.Content.Tiles;
using Terraria.Chat;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace Slupergin.Content.Systems
{
    public class DevouriaSpreadSystem : ModSystem
    {
        private static bool hasSpreadStarted = false; // Controla si ya inici� la propagaci�n

        public override void OnWorldLoad()
        {
            hasSpreadStarted = false; // Se reinicia al cargar el mundo
        }

        public override void PostUpdateWorld()
        {
            if (!hasSpreadStarted && NPC.downedMoonlord) // Se activa solo despu�s de Moon Lord
            {
                hasSpreadStarted = true;
                if (Main.netMode != NetmodeID.Server)
                {
                    Main.NewText("Un virus ancestral empieza a expandirse...", 255, 50, 50);
                }
                else
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Un virus ancestral empieza a expandirse..."), new Color(255, 50, 50));
                }
            }

            if (!hasSpreadStarted) return; // No propaga si no ha comenzado

            if (Main.rand.NextBool(3)) // 33% de probabilidad de propagaci�n por tick
            {
                int x = Main.rand.Next(10, Main.maxTilesX - 10);
                int y = Main.rand.Next(10, Main.maxTilesY - 10);
                Tile tile = Framing.GetTileSafely(x, y);

                if (tile.HasTile)
                {
                    // Consume tierra, piedra y arena normales
                    if (tile.TileType == TileID.Grass || tile.TileType == TileID.Stone || tile.TileType == TileID.Sand)
                    {
                        WorldGen.PlaceTile(x, y, ModContent.TileType<DevouriaGrass>(), true);
                    }
                    else if (tile.TileType == TileID.Trees)
                    {
                        WorldGen.PlaceTile(x, y, ModContent.TileType<DevouriaGrass>(), true);
                    }
                    // Consume la Corrupci�n, Carmes� y Bendici�n
                    else if (tile.TileType == TileID.Ebonstone || tile.TileType == TileID.Crimstone || tile.TileType == TileID.Pearlstone)
                    {
                        WorldGen.PlaceTile(x, y, ModContent.TileType<DevouriaStone>(), true);
                    }
                }
            }
        }
    }
}
