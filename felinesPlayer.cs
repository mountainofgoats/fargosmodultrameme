using Terraria;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM
{
    public class felinesPlayer : ModPlayer
    {
        public bool HighTemperature;
        Mod FargowiltasSouls = ModLoader.GetMod("FargowiltasSouls");
        
        public override void ResetEffects()
        {
            HighTemperature = false;
        }

        public override void UpdateDead()
        {
            HighTemperature = false;
        }

        public override void PreUpdate()
        {
            if (felinesWorld.masoEX)
            {
                if (!Main.hardMode && Main.raining && !(player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight || player.ZoneUnderworldHeight))
                    player.AddBuff(FargowiltasSouls.BuffType("Lethargic"), 2);

                if (player.ZoneUnderworldHeight)
                    player.AddBuff(mod.BuffType("HighTemperature"), 2);
            }
        }
        
                public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
        {
            Item item = new Item();
            item.SetDefaults(mod.ItemType("MasochistEX"));
            items.Add(item);
        }

        public override void UpdateBadLifeRegen()
        {
            if (HighTemperature)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 30;
            }
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (HighTemperature && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8)
                damageSource = PlayerDeathReason.ByCustomReason(player.name + " could not breathe the warm air");
            return true;
        }
    }
}
