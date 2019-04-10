using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items.MasomodeEX
{
    public class MasochistEX : ModItem
    {
        public override string Texture => "NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM/Items/PlacheholderItem";
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Abominationn's Gift");
            Tooltip.SetDefault("Activates/Deactivates Masochist Mode EX");
        }

        public override void SetDefaults()
        {
            item.width = 50;
            item.height = 50;
            item.maxStack = 1;
            item.useTime = 45;
            item.useAnimation = 45;
            item.useStyle = 4;
            item.rare = 1;
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
                Main.NewText("Masochist Mode EX enabled.", 175, 55);
            }
            else
            {
                felinesWorld.masoEX = false;
                Main.NewText("Masochist Mode EX disabled.", 175, 55);
            }
            return true;
        }
    }
}
