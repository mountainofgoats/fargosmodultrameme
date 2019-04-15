using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM
{
    public class MyPlayer : ModPlayer
    {
        public bool CthulhusAura;

        public override void ResetEffects()
        {
            CthulhusAura = false;
        }
    }
}
