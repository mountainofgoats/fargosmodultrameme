using Terraria.ModLoader;

namespace FargowiltasDLC.Items
{
    public class WaterEssence : ModItem
    {
        public override string Texture => "FargowiltasDLC/Items/PlaceholderItem";

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