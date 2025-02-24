using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using slupergin.Content.Projectiles;

namespace slupergin.Content.Items
{ 
    public class Filo_Del_Abismo : ModItem
    {
        
        public override void SetDefaults()
        {
            Item.damage = 800;
            Item.DamageType = DamageClass.Melee;
            Item.width = 321;
            Item.height = 320;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = Item.buyPrice(silver: 1);
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<MySwordProjectileSprite1>(); 
            Item.shootSpeed = 10f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 20);
            recipe.AddIngredient(ItemID.BloodMoonStarter, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}

