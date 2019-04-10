using Terraria;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Buffs
{
    public class HighTemperature : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("High Temperature");
            Description.SetDefault("The air is warm around you");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<felinesPlayer>(mod).HighTemperature = true;
        }
    }
}
