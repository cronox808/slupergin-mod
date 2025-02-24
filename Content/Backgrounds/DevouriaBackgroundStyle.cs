using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;

namespace Slupergin.Content.Backgrounds
{
    public class DevouriaBackground : ModSystem
    {
        public override void Load()
        {
            if (!Main.dedServ)
            {
                Filters.Scene["Slupergin:DevouriaBackground"] = new Filter(new ScreenShaderData("FilterMiniTower").UseColor(1.0f, 0.9f, 0.5f).UseOpacity(0.5f), EffectPriority.Medium);
                SkyManager.Instance["Slupergin:DevouriaBackground"] = new DevouriaSky(); // Aquí usamos la nueva clase
            }
        }

        public override void Unload()
        {
            Filters.Scene["Slupergin:DevouriaBackground"]?.Deactivate();
        }
    }
}
