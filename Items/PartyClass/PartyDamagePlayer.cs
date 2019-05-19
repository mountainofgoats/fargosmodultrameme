using Terraria;
using Terraria.ModLoader;

namespace FargowiltasDLC.Items.PartyClass
{
    // This class stores necessary player info for our custom damage class, such as damage multipliers and additions to knockback and crit.
    public class PartyDamagePlayer : ModPlayer
    {
        public static PartyDamagePlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<PartyDamagePlayer>();
        }

        // Vanilla only really has damage multipliers in code
        // And crit and knockback is usually just added to
        // As a modder, you could make separate variables for multipliers and simple addition bonuses
        public float partyDamage = 1f;
        public int partyCrit;

        public override void ResetEffects()
        {
            ResetVariables();
        }

        public override void UpdateDead()
        {
            ResetVariables();
        }

        private void ResetVariables()
        {
            partyDamage = 1f;
            partyCrit = 0;
        }
    }
}