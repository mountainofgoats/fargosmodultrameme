using Terraria.ModLoader;

namespace FargowiltasDLC.Items
{
    public class WaterEssence : ModItem
    {
        Mod FargowiltasSouls = ModLoader.GetMod("FargowiltasSouls");
        public override string Texture => "FargowiltasDLC/Items/PlaceholderItem";

        public override bool Autoload(ref string name)
        {
            return FargowiltasSouls != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Water Essence");
        }

        public override void SetDefaults()
        {
            item.width = 50;
            item.height = 50;
            item.rare = 8;
            item.maxStack = 999;
        }
    }
}