using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Slupergin.Content.Tiles;

namespace Slupergin.Content.Systems // <-- Ajustado al folder "Content/Systems"
{
    public class DevouriaExpansion : ModSystem
    {
        private bool devouriaSpawned = false;
        private Point spawnPoint;
        private int spreadTimer = 0;
        private const int SpreadInterval = 60; // Se expande cada 60 ticks (1 segundo)

        public override void PostUpdateWorld()
        {
            if (!devouriaSpawned && NPC.downedMoonlord)
            {
                InitializeDevouria();
            }

            if (devouriaSpawned)
            {
                spreadTimer++;
                if (spreadTimer >= SpreadInterval)
                {
                    spreadTimer = 0;
                    SpreadDevouria();
                }
            }
        }

        private void InitializeDevouria()
        {
            int x = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
            int y = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 200);
            spawnPoint = new Point(x, y);
            ConvertToDevouria(spawnPoint.X, spawnPoint.Y);
            devouriaSpawned = true;
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.WorldData);
            }
        }

        private void SpreadDevouria()
        {
            int spreadX = WorldGen.genRand.Next(spawnPoint.X - 20, spawnPoint.X + 20);
            int spreadY = WorldGen.genRand.Next(spawnPoint.Y - 20, spawnPoint.Y + 20);
            ConvertToDevouria(spreadX, spreadY);
        }

        private void ConvertToDevouria(int x, int y)
        {
            if (!WorldGen.InWorld(x, y)) return;
            Tile tile = Main.tile[x, y];

            if (tile != null && tile.HasTile)
            {
                if (tile.TileType == TileID.Dirt || tile.TileType == TileID.Grass || tile.TileType == TileID.Stone)
                {
                    tile.TileType = (ushort)ModContent.TileType<DevouriaGrass>();
                    WorldGen.SquareTileFrame(x, y);
                    NetMessage.SendTileSquare(-1, x, y, 1);
                }
            }
        }
    }
}

