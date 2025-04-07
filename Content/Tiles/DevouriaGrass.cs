using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Slupergin.Content.Tiles
{
    public class DevouriaGrass : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;               // Es un bloque sólido
            Main.tileMergeDirt[Type] = true;           // Se mezcla con tierra
            Main.tileBlockLight[Type] = true;          // Bloquea luz
            Main.tileBlendAll[Type] = true;            // Se mezcla visualmente con otros bloques

            AddMapEntry(new Color(200, 180, 50));       // Color del mapa

            RegisterItemDrop(ModContent.ItemType<Items.Placeable.DevouriaGrassBlock>());
        }

        // ✅ Permite que se plante una bellota vanilla en este bloque
        public override bool IsTileValidForAcorn(int i, int j)
        {
            return true;
        }

        // ✅ Devuelve el tipo de sapling a colocar cuando se planta una bellota
        public override int GetSapling(int i, int j)
        {
            return ModContent.TileType<DevouriaSapling>();
        }
    }
}
