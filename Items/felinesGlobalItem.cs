using Terraria;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items
{
    public class felinesGlobalItem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;

        Mod Fargowiltas = ModLoader.GetMod("Fargowiltas");

        public override void RightClick(Item item, Player player)
        {
            if (item.type == Fargowiltas.ItemType("IceCrate") && felinesWorld.masoEX && Main.rand.Next(2) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("FrigidBarrier"));
            }
        }
    }
}
