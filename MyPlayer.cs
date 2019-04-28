using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM
{
    public class MyPlayer : ModPlayer
    {
        public bool RottenFlesh;
        public bool PlaceholderPet;

        public override void ResetEffects()
        {
            RottenFlesh = false;
            PlaceholderPet = false;
        }
        
        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (RottenFlesh)
                target.AddBuff(BuffID.CursedInferno, Main.rand.Next(180, 240));
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (RottenFlesh)
                target.AddBuff(BuffID.CursedInferno, Main.rand.Next(180, 240));
        }

        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
        {
            Item item = new Item();
            item.SetDefaults(mod.ItemType("Placeholder"));
            items.Add(item);
            Item item2 = new Item();
            item2.SetDefaults(mod.ItemType("MasochistEX"));
            items.Add(item2);
        }
    }
}
