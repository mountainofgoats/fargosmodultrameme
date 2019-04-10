using Terraria;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM
{
    public class felinesPlayer : ModPlayer
    {
        Mod FargowiltasSouls = ModLoader.GetMod("FargowiltasSouls");

        public override void PreUpdate()
        {
            if (felinesWorld.masoEX)
            { 
                if (!Main.hardMode && Main.raining && !(player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight || player.ZoneUnderworldHeight))
                {
                    player.AddBuff(FargowiltasSouls.BuffType("Lethargic"), 2);
                }

                if (player.ZoneUnderworldHeight)
                {
                    player.AddBuff(mod.BuffType("HighTemperature"), 10000);
                }
            }
        }
    }
}
