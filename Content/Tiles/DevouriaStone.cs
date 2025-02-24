using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Slupergin.Content.Tiles
{
    public class DevouriaStone : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;

            AddMapEntry(new Color(153, 101, 21)); // Color en el minimapa

            DustType = DustID.Stone;

            // 🔥 Corrección: Registrar el drop correctamente
            RegisterItemDrop(ModContent.ItemType<Items.Placeable.DevouriaStoneItem>());
        }
    }
}
