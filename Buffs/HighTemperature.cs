using Terraria;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Buffs
{
    public class HighTemperature : ModBuff  
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("High Temperature");
            Description.SetDefault("When your body reaches extreme temperatures, your protein starts decomposing in it's primary form rendering it useless, destroying your body from inside on a cellular level.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statLife /= 2;
            player.lifeRegen -= 3;
            player.statDefense -= 5;
        }
    }
}
