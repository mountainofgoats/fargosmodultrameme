using Microsoft.Xna.Framework;
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
			Tooltip.SetDefault("One of the 6 Infinity Stones, wielding infinite power.\n+3500 max Ki\n+150% Ki Damage\n+150% firework damage\n10% chance to deliver 5x the damage\nEvery time you attack an enemy you get +1% attack boost. Caps at 150%. Restored if not attacking for 20 seconds");
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

		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			Mod DBZMOD = ModLoader.GetMod("DBZMOD");

			player.meleeDamage += 1.5f;
			player.magicDamage += 1.5f;
			player.minionDamage += 1.5f;
			player.rangedDamage += 1.5f;
			player.thrownDamage += 1.5f;
			player.GetModPlayer<DBZMOD.MyPlayer>(DBZMOD).kiDamage += 1.5f;
			player.GetModPlayer<DBZMOD.MyPlayer>(DBZMOD).kiMax2 += 3500;
			player.GetModPlayer<FireworkClass.FireworkDamagePlayer>().fireworkDamage += 1.5f;

			player.GetModPlayer<DLCPlayer>().stoneAbilityPb = true;
		}
    }
}

