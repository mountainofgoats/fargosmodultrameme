using DBZMOD;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace FargowiltasDLC.Items.Special
{
	public class PowerStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Power Stone");
			Tooltip.SetDefault("One of the 6 Infinity Stones, wielding infinite power.\n+3500 max Ki\n+150% Ki Damage\n+150% firework damage\n+30 Ki regen\nEvery time you attack an enemy you get +1% attack boost. Caps at 150%. Restored if not attacking for 20 seconds");
		}

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(60, 36, 181));
                }
            }
        }

		public override void SetDefaults()
		{
			item.width = 44;
			item.height = 26;
			item.value = 1000000;
			item.accessory = true;
			item.expertOnly = true;
		}

		public int counter = 0;
		public bool fivexdmg;
		public double dmgIncreasePS = 0;

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			this.counter = 0;
			this.dmgIncreasePS += 0.01;

			Main.NewText("echprime");
		}

		public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			this.counter = 0;
			this.dmgIncreasePS += 0.01;

			Main.NewText("echprime");
		}

		public override void GetWeaponDamage(Player player, ref int damage)
		{
			double temp = dmgIncreasePS * damage;
			damage += (int)temp;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			counter++;

			Main.NewText(counter);

			if (counter == 1200)
			{
				dmgIncreasePS = 0f;
				counter = 0;
			}

			Mod dBZMOD = ModLoader.GetMod("DBZMOD");
			MyPlayer DBZModPlayer = player.GetModPlayer<DBZMOD.MyPlayer>(dBZMOD);

			player.meleeDamage += 1.5f;
			player.magicDamage += 1.5f;
			player.minionDamage += 1.5f;
			player.rangedDamage += 1.5f;
			player.thrownDamage += 1.5f;
			DBZModPlayer.kiDamage += 1.5f;
			DBZModPlayer.kiMax2 += 3500;
			DBZModPlayer.kiRegen += 2;
			player.GetModPlayer<FireworkClass.FireworkDamagePlayer>().fireworkDamage += 1.5f;
			player.GetModPlayer<DLCPlayer>().stoneAbilityPb = true;

			if (DBZModPlayer.isInstantTransmission1Unlocked)
			{
				DBZModPlayer.kiRegen += 1;
			}
		}
    }
}

