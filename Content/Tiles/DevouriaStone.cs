using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Slupergin.Content.Tiles
{
    public class DevouriaStone : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true; // Bloque sólido
            Main.tileBlockLight[Type] = true; // Bloquea la luz
            Main.tileMergeDirt[Type] = true; // Se puede fusionar con tierra
            Main.tileBlendAll[Type] = true; // Se mezcla con otros bloques
            AddMapEntry(new Microsoft.Xna.Framework.Color(200, 180, 50)); // Color en el minimapa

            RegisterItemDrop(ModContent.ItemType<Items.Placeable.DevouriaStoneBlock>()); // Suelta un bloque al romperse
        }
    }
}
