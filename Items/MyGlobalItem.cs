using Terraria;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items
{
    public class MyGlobalItem : GlobalItem
    {
        public override bool CanUseItem(Item item, Player player)
        {
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
            if (modPlayer.CthulhusAura && item.healLife > 0)
                return false;
            return true;
        }
    }
}
