using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items.SpecialWeapons
{
	public class MindStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mind Stone");
			Tooltip.SetDefault("One of the 6 Infinity Stones, wielding power to control one's mind.");
		}

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(242, 206, 48));
                }
            }
        }

        public override void SetDefaults()
		{
            item.width = 30;
            item.height = 22;
            item.accessory = true;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			MyPlayer.ModPlayer(player).stoneAbilityb = true;
		}
    }
}

