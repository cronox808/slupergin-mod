using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Slupergin.Content.Items.Placeable
{
    public class DevouriaStoneBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Se usa DisplayName y Tooltip sin SetText ni SetDefault
            Item.ResearchUnlockCount = 100; // Para que se pueda investigar en el Bestiary
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.DevouriaStone>(); // Bloque que coloca
        }
    }
}
