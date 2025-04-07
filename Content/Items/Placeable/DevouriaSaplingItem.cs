using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Slupergin.Content.Tiles;

namespace Slupergin.Content.Items.Placeable
{
    public class DevouriaSaplingItem : ModItem
    {
        public override string Texture => "Slupergin/Content/Items/Placeable/DevouriaSaplingItem";

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 999;
            Item.value = 100;
            Item.rare = ItemRarityID.Green;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 15;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<DevouriaSapling>();
            Item.useTurn = true;
        }
    }
}
