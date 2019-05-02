using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM
{
    public partial class DLCPlayer : ModPlayer
    {
		#region MasomodeEX Items
		public bool RottenFlesh;
        public bool BrainyBrain;
        public bool GiantStinger;
        public bool GougedFlesh;
		public bool stoneAbilityb; //fires a beam
		public bool stoneSpecialAbilityb; //performs it's special ability; revert time; space manipulation; etc.
		#endregion

		#region other variables
		public bool PlaceholderPet;
		#endregion

		public override void ResetEffects()
        {
            //Masomode EX items
            RottenFlesh = false;
            BrainyBrain = false;
            GiantStinger = false;
            GougedFlesh = false;
			stoneAbilityb = false;
			stoneSpecialAbilityb = false;
            //Other
            PlaceholderPet = false;
        }

		public static DLCPlayer ModPlayer(Player player)
		{
			return player.GetModPlayer<DLCPlayer>();
		}

		public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (RottenFlesh)
                target.AddBuff(BuffID.CursedInferno, Main.rand.Next(180, 240));
            if (BrainyBrain)
                target.AddBuff(BuffID.Ichor, Main.rand.Next(180, 240));
            if (GiantStinger)
                target.AddBuff(BuffID.Poisoned, Main.rand.Next(180, 240));
            if (GougedFlesh)
                target.AddBuff(BuffID.CursedInferno, Main.rand.Next(180, 240));
                target.AddBuff(BuffID.Ichor, Main.rand.Next(180, 240));
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (RottenFlesh)
                target.AddBuff(BuffID.CursedInferno, Main.rand.Next(180, 240));
            if (BrainyBrain)
                target.AddBuff(BuffID.Ichor, Main.rand.Next(180, 240));
            if (GiantStinger)
                target.AddBuff(BuffID.Poisoned, Main.rand.Next(180, 240));
            if (GougedFlesh)
                target.AddBuff(BuffID.CursedInferno, Main.rand.Next(180, 240));
                target.AddBuff(BuffID.Ichor, Main.rand.Next(180, 240));
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

		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (FargowiltasDLC.stoneAbility.JustPressed)
			{
				if (stoneAbilityb)
				{
					Projectile.NewProjectile(player.Center, Vector2.Zero, 1, 112, 6f, mod.ProjectileType("MindStoneBeam"), Main.myPlayer);
				}
			}
		}
	}
}
