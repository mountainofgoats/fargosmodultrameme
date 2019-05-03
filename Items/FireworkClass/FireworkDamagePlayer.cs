using Terraria;
using Terraria.ModLoader;

namespace FargowiltasDLC.Items.FireworkClass
{
    // This class stores necessary player info for our custom damage class, such as damage multipliers and additions to knockback and crit.
    public class FireworkDamagePlayer : ModPlayer
    {
        public static FireworkDamagePlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<FireworkDamagePlayer>();
        }

        // Vanilla only really has damage multipliers in code
        // And crit and knockback is usually just added to
        // As a modder, you could make separate variables for multipliers and simple addition bonuses
        public float fireworkDamage = 1f;
        public int fireworkCrit;

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
            fireworkDamage = 1f;
            fireworkCrit = 0;
        }
    }
}