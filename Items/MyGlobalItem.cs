using Terraria;
using Terraria.ID; //perfect, would not even compile without this :echprime:
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items
{
    public class MyGlobalItem : GlobalItem
    {
        //public override bool CanUseItem(Item item, Player player)
        //{
        //    MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
        //}
        
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (MyWorld.MasomodeEX)
            {
                switch (arg)
                {
                    case ItemID.KingSlimeBossBag:
                        player.QuickSpawnItem(mod.ItemType("SlimyShield"));
                        break;
                    case ItemID.EyeOfCthulhuBossBag:
                        player.QuickSpawnItem(mod.ItemType("CoreofEvil"));
                        break;
                    case ItemID.EaterOfWorldsBossBag:
                        player.QuickSpawnItem(mod.ItemType("RottenFlesh"));
                        break;
                }
            }
        }
    }
}
