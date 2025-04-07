using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;

namespace Slupergin.Content.Tiles
{
    public class DevouriaTree : ModTree
    {
        public override void SetStaticDefaults()
        {
            GrowsOnTileId = new int[] { ModContent.TileType<DevouriaGrass>() };
        }

        public override int DropWood() => ItemID.RichMahogany;

        public override void SetTreeFoliageSettings(Tile tile, ref int style, ref int saplingGrowthStyle, ref int foliageStyleX, ref int foliageStyleY, ref int calcExtra)
        {
            style = 0;
            saplingGrowthStyle = 0;
            foliageStyleX = 0;
            foliageStyleY = 0;
            calcExtra = 0;
        }

        public override Asset<Texture2D> GetTexture()
        {
            return ModContent.Request<Texture2D>("Slupergin/Content/Tiles/DevouriaTree", AssetRequestMode.ImmediateLoad);
        }

        public override Asset<Texture2D> GetTopTextures()
        {
            return ModContent.Request<Texture2D>("Slupergin/Content/Tiles/DevouriaTree_Top", AssetRequestMode.ImmediateLoad);
        }

        public override Asset<Texture2D> GetBranchTextures()
        {
            return ModContent.Request<Texture2D>("Slupergin/Content/Tiles/DevouriaTree_Branches", AssetRequestMode.ImmediateLoad);
        }

        public override TreePaintingSettings TreeShaderSettings => new TreePaintingSettings();
    }
}
