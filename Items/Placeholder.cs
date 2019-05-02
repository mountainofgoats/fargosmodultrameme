using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasDLC.Items
{
    public class Placeholder : ModItem
    {
        public override string Texture => "FargowiltasDLC/Items/PlaceholderItem";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Placeholder");
            Tooltip.SetDefault("Summons a placeholder pet");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.shoot = mod.ProjectileType("Placeholder");
            item.buffType = mod.BuffType("PlaceholderPet");
            item.rare = 10;
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
                player.AddBuff(item.buffType, 3600, true);
        }
    }
}
