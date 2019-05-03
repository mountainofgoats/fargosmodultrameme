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
			Tooltip.SetDefault("One of the 6 Infinity Stones, wielding infinite power.");
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
            item.accessory = true;
        }

		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			Mod dBZMod = ModLoader.GetMod("DBZMOD");

			player.meleeDamage += 1.5f;
			player.magicDamage += 1.5f;
			player.minionDamage += 1.5f;
			player.rangedDamage += 1.5f;
			player.thrownDamage += 1.5f;
			player.GetModPlayer<DBZMOD.MyPlayer>(dBZMod).kiDamage += 1.5f;
			player.GetModPlayer<DBZMOD.MyPlayer>(dBZMod).kiMax2 += 5000;
			player.GetModPlayer<FireworkClass.FireworkDamagePlayer>().fireworkDamage += 1.5f;

			player.GetModPlayer<DLCPlayer>().stoneAbilityPb = true;
		}
    }
}

