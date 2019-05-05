using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System.Collections.Generic;
using DBZMOD;
using Microsoft.Xna.Framework;

namespace FargowiltasDLC
{
    public partial class DLCPlayer : ModPlayer
	{ 
		#region MasomodeEX Items
		public bool RottenFlesh;
        public bool BrainyBrain;
        public bool GiantStinger;
        public bool GougedFlesh;
		public bool stoneAbilityPb;
		#endregion

		#region other variables
		public bool PlaceholderPet;
		public double dmgIncreasePS = 0;
		public bool pwStone;
		public int counter = 0;
		public bool fivexdmg;
		#endregion

		public override void ResetEffects()
        {
            //Masomode EX items
            RottenFlesh = false;
            BrainyBrain = false;
            GiantStinger = false;
            GougedFlesh = false;
			stoneAbilityPb = false;
			//Other
			pwStone = false;
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
			if (Main.rand.NextBool(10) && stoneAbilityPb)
			{
				Mod dbzMOD = ModLoader.GetMod("DBZMOD");

				player.meleeDamage += 5f;
				player.GetModPlayer<MyPlayer>(dbzMOD).kiDamage += 5f;

				Main.NewText("true");
			}
			Item item = new Item();
			item.SetDefaults(mod.ItemType("Placeholder"));
			items.Add(item);
			Item item2 = new Item();
			item2.SetDefaults(mod.ItemType("MasochistEX"));
			items.Add(item2);
		}

		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
			if (stoneAbilityPb)
			{
				counter = 0;
				dmgIncreasePS += 0.01;
			}
		}

		public override void GetWeaponDamage(Item item, ref int damage)
		{
			if (stoneAbilityPb)
			{
				double temp = dmgIncreasePS * damage;
				damage += (int)temp;
			}
		}

		public override void PreUpdate()
		{
			if (stoneAbilityPb)
			{
				counter++;

				if (counter == 1200)
				{
					dmgIncreasePS = 0f;
					counter = 0;
				}
			}
		}
	}
}
