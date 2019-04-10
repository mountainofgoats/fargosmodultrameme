using Terraria;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Buffs
{
    public class ECHCooldown : ModBuff  
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("ECH Cooldown");
            Description.SetDefault("The ECH does not want to give you it's healing powers.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
        
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = "NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM/Buffs/PlaceholderDebuff";
            return true;
        }
    }
}
