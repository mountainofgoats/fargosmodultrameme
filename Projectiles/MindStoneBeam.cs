using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Projectiles
{
	public class MindStoneBeam : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mind Stone Beam");
		}

		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 10;
			projectile.damage = 112;
			projectile.knockBack = 6f;
			projectile.type = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.magic = true;
			projectile.hide = true;
		}

		private const float MoveDistance = 60f;


		public float Distance
		{
			get { return projectile.ai[0]; }
			set { projectile.ai[0] = value;  }
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			DrawTheBeamtexture(spriteBatch, Main.projectileTexture[projectile.type], Main.player[projectile.owner].Center, projectile.velocity, 10, projectile.damage, -1.57f, 1f, 1000f, Color.White, (int)MoveDistance);
			return false;
		}

		public void DrawTheBeamtexture(SpriteBatch spriteBatch, Texture2D texture, Vector2 start, Vector2 unit, float step, int damage, float rotation = 0f, float scale = 1f, float maximumDist = 256f, Color color = default(Color), int transitDist = 50)
		{
			Vector2 origin = start;
			float r = unit.ToRotation() + rotation;

			#region Draw the body of the beam
			for (float i = transitDist; i <= Distance; i += step)
			{
				Color c = Color.White;
				origin = start + i * unit;
				spriteBatch.Draw(texture, origin - Main.screenPosition, new Rectangle(0, 26, 28, 26), i < transitDist ? Color.Transparent : c, r, new Vector2(28 * .5f, 26 * .5f), scale, 0, 0);
			}
			#endregion

			#region Draw the tail of the beam
			spriteBatch.Draw(texture, start + unit * (transitDist - step) - Main.screenPosition, new Rectangle(0, 0, 28, 26), Color.White, r, new Vector2(28 * .5f, 26 * .5f), scale, 0, 0);
			#endregion

			#region Draw the head of the beam
			spriteBatch.Draw(texture, start + unit * (transitDist - step) - Main.screenPosition, new Rectangle(0, 52, 28, 26), Color.White, r, new Vector2(28 * .5f, 26 * .5f), scale, 0, 0);
			#endregion
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			Player player = Main.player[projectile.owner];
			Vector2 unit = projectile.velocity;
			float point = 0f;
			// Run an AABB versus Line check to look for collisions, look up AABB collision first to see how it works
			// It will look for collisions on the given line using AABB
			return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), player.Center,
				player.Center + unit * Distance, 22, ref point);
		}

		public override void AI()
		{
			Vector2 mousePos = Main.MouseWorld;
			Player player = Main.player[projectile.owner];
		}
	}
}