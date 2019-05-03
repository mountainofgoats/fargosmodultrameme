using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace FargowiltasDLC.Items.SpecialWeapons
{
	public class RealityStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reality Stone");
			Tooltip.SetDefault("One of the 6 Infinity Stones, capable of manipulating the reality.");
		}
        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(186, 33, 69));
                }
            }
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 28;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
		}
    }
}

