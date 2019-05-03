using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace FargowiltasDLC.Items.Special
{
	public class SpaceStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Space Stone");
			Tooltip.SetDefault("One of the 6 Infinity Stones, that allows you to manipulate the space.");
		}
        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(43, 66, 181));
                }
            }
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

		}
    }
}