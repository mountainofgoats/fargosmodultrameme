using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;

namespace FargowiltasDLC.Projectiles
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

		#region Colliding
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
		#endregion

		public override void AI()
		{
			Vector2 mousePos = Main.MouseWorld;
			Player player = Main.player[projectile.owner];

			#region Set projectile position
			// Multiplayer support here, only run this code if the client running it is the owner of the projectile
			if (projectile.owner == Main.myPlayer)
			{
				Vector2 diff = mousePos - player.Center;
				diff.Normalize();
				projectile.velocity = diff;
				projectile.direction = Main.MouseWorld.X > player.position.X ? 1 : -1;
				projectile.netUpdate = true;
			}
			projectile.position = player.Center + projectile.velocity * MoveDistance;
			projectile.timeLeft = 2;
			int dir = projectile.direction;
			player.ChangeDir(dir);
			player.heldProj = projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = (float)Math.Atan2(projectile.velocity.Y * dir, projectile.velocity.X * dir);
			#endregion

			#region Set laser tail position and dusts

			Vector2 start = player.Center;
			Vector2 unit = projectile.velocity;
			unit *= -1;
			for (Distance = MoveDistance; Distance <= 2200f; Distance += 5f)
			{
				start = player.Center + projectile.velocity * Distance;
				if (!Collision.CanHit(player.Center, 1, 1, start, 1, 1))
				{
					Distance -= 5f;
					break;
				}
			}

			Vector2 dustPos = player.Center + projectile.velocity * Distance;
			//Imported dust code from source because I'm lazy
			for (int i = 0; i < 2; ++i)
			{
				float num1 = projectile.velocity.ToRotation() + (Main.rand.Next(2) == 1 ? -1.0f : 1.0f) * 1.57f;
				float num2 = (float)(Main.rand.NextDouble() * 0.8f + 1.0f);
				Vector2 dustVel = new Vector2((float)Math.Cos(num1) * num2, (float)Math.Sin(num1) * num2);
				Dust dust = Main.dust[Dust.NewDust(dustPos, 0, 0, 226, dustVel.X, dustVel.Y, 0, new Color(), 1f)];
				dust.noGravity = true;
				dust.scale = 1.2f;
				dust = Dust.NewDustDirect(Main.player[projectile.owner].Center, 0, 0, 31,
					-unit.X * Distance, -unit.Y * Distance);
				dust.fadeIn = 0f;
				dust.noGravity = true;
				dust.scale = 0.88f;
				dust.color = Color.Cyan;
			}
			if (Main.rand.NextBool(5))
			{
				Vector2 offset = projectile.velocity.RotatedBy(1.57f, new Vector2()) * ((float)Main.rand.NextDouble() - 0.5f) *
								 projectile.width;
				Dust dust = Main.dust[
					Dust.NewDust(dustPos + offset - Vector2.One * 4f, 8, 8, 31, 0.0f, 0.0f, 100, new Color(), 1.5f)];
				dust.velocity = dust.velocity * 0.5f;
				dust.velocity.Y = -Math.Abs(dust.velocity.Y);

				unit = dustPos - Main.player[projectile.owner].Center;
				unit.Normalize();
				dust = Main.dust[
					Dust.NewDust(Main.player[projectile.owner].Center + 55 * unit, 8, 8, 31, 0.0f, 0.0f, 100, new Color(), 1.5f)];
				dust.velocity = dust.velocity * 0.5f;
				dust.velocity.Y = -Math.Abs(dust.velocity.Y);
			}
			#endregion

			DelegateMethods.v3_1 = new Vector3(0.8f, 0.8f, 1f);
			Utils.PlotTileLine(projectile.Center, projectile.Center + projectile.velocity * (Distance - MoveDistance), 26,
				DelegateMethods.CastLight);
		}

		public override bool ShouldUpdatePosition()
		{
			return false;
		}

		public override void CutTiles()
		{
			DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
			Vector2 unit = projectile.velocity;
			Utils.PlotTileLine(projectile.Center, projectile.Center + unit * Distance, (projectile.width + 16) * projectile.scale, DelegateMethods.CutTiles);
		}
	}
}