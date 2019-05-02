using Terraria;
using Terraria.ModLoader;

namespace FargowiltasDLC.Buffs
{
    public class PlaceholderPet : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Placeholder Pet");
            Description.SetDefault("Yea, its me");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            DLCPlayer modPlayer = player.GetModPlayer<DLCPlayer>(mod);
            modPlayer.PlaceholderPet = true;
            player.buffTime[buffIndex] = 18000;            
            if (player.ownedProjectileCounts[mod.ProjectileType("PlaceholderPet")] < 1 && player.whoAmI == Main.myPlayer)
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("PlaceholderPet"), 0, 0f, player.whoAmI, 0f, 0f);
        }

        public override bool Autoload(ref string name, ref string texture)
        {
            texture = "FargowiltasDLC/Buffs/PlaceholderBuff";
            return true;
        }
    }
}
