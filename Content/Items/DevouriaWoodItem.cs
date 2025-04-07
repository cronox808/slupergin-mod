using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Slupergin.Content.Items
{
    public class DevouriaWoodItem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 999;
            Item.value = Item.buyPrice(copper: 10);
            Item.rare = ItemRarityID.White;
        }
    }
}
