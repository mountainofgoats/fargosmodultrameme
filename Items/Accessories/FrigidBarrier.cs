using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items.Accessories
{
	public class FrigidBarrier : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frigid Barrier");
			Tooltip.SetDefault("Immunity to High Temperature\n'Made from magical unmelting snow'");
		}
		
		public override void SetDefaults()
		{
                        item.width = 50;
            		item.height = 50;
			item.accessory = true;
            		item.defense = 5;
			item.rare = 1;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        	{
            		player.buffImmune[mod.BuffType("HighTemperature")] = true;
       		}
	}
}
