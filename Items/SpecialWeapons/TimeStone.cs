using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items.SpecialWeapons
{
	public class TimeStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Time Stone");
			Tooltip.SetDefault("One of the 6 Infinity Stones, capable of manipulating time.");
		}
        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(20, 137, 96));
                }
            }
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			MyPlayer.DLCPlayer(player).stoneAbilityb = true;
		}
    }
}

