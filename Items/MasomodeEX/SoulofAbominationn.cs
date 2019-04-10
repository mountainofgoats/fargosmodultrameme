using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items.MasomodeEX
{
    public class SoulofAbominationn : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul of Abominationn");
            Tooltip.SetDefault("Brings complete annihilation over the world\nUse with care");
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(188, 253, 68));
                }
            }
        }

        public override void SetDefaults()
        {
            item.width = 50;
            item.height = 50;
            item.maxStack = 1;
            item.useTime = 45;
            item.useAnimation = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item44;
        }

        public override bool CanUseItem(Player player)
        {
            return Main.expertMode;
        }

        public override bool UseItem(Player player)
        {
            if (!felinesWorld.masoEX)
            {
                felinesWorld.masoEX = true;
                Main.NewText("An annihilation was bringed to the world...", 188, 253, 68);
            }
            else
            {
                felinesWorld.masoEX = false;
                Main.NewText("The world was saved from an annihilation...", 188, 253, 68);
            }
            return true;
        }
    }
}
