using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Slupergin.Content.Tiles
{
    public class DevouriaGrass : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;

            AddMapEntry(new Color(120, 180, 50)); // Color verde en el minimapa

            DustType = DustID.Grass;

            // 🔥 Registrar el drop correctamente
            RegisterItemDrop(ModContent.ItemType<Items.Placeable.DevouriaGrassItem>());
        }
    }
}
