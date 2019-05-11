using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasDLC.Items.Special
{
    public class FaceMelter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Face Melter");
            Tooltip.SetDefault("'Squiddley-Squiddley-wheeyooo!'\nA normal electric guitar that fires musical notes\nRight click to summon an amplifier that will fire musical notes too");
        }

        public override void SetDefaults()
        {
            item.damage = 150;
            item.ranged = true;
            item.width = 50;
            item.height = 50;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.noMelee = true; 
            item.knockBack = 0f;
            item.rare = 10;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("MusicalNote"); 
            item.shootSpeed = 10f;
            item.scale = 1.5f;
        }

        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
    }
}
