using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasDLC
{
	public class DLCGlobalItem : GlobalItem
	{
		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (DLCWorld.MasomodeEX)
			{
				switch (arg)
				{
					case ItemID.KingSlimeBossBag:
						player.QuickSpawnItem(mod.ItemType("SlimyShield"));
						break;
					case ItemID.EyeOfCthulhuBossBag:
						player.QuickSpawnItem(mod.ItemType("CoreofEvil"));
						break;
					case ItemID.EaterOfWorldsBossBag:
						player.QuickSpawnItem(mod.ItemType("RottenFlesh"));
						break;
					case ItemID.BrainOfCthulhuBossBag:
						player.QuickSpawnItem(mod.ItemType("BrainyBrain"));
						break;
					case ItemID.QueenBeeBossBag:
						player.QuickSpawnItem(mod.ItemType("GiantStinger"));
						break;
					case ItemID.SkeletronBossBag:
						player.QuickSpawnItem(mod.ItemType("BoneShield"));
						break;
					case ItemID.WallOfFleshBossBag:
						player.QuickSpawnItem(mod.ItemType("GougedFlesh"));
						break;
				}
			}
		}
		/// <summary>
		/// This is a function to determine the closest distance to a selected target in a particular radius (distanceToTarget(f)) and create a new !MODPROJECTILE!
		/// depending on the string projectileName. Please note that using this will force the projectile to be auto-homing. The generation of the 
		/// </summary>
		public void CreateProjIfCloseToTarget(string projectileName, int Type, int Damage, float KnockBack, float distanceToTarget, Vector2 OffSet)
		{
			Player player = new Player();
			Projectile projectile = new Projectile();

			for (int i = 0; i < Main.maxNPCs; i++)
			{

				NPC target = Main.npc[i];

				float XCoords = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
				float YCoords = target.position.Y - projectile.Center.Y;
				float distance = (float)Math.Sqrt(Math.Pow(XCoords, 2) + Math.Pow(YCoords, 2));

				if (distance < distanceToTarget)
				{
					distance = 3f / distance;

					XCoords *= distance * 3;
					YCoords *= distance * 3;

					projectile.velocity.X = XCoords;
					projectile.velocity.Y = YCoords;

					Projectile.NewProjectile(player.Center + OffSet, projectile.velocity, Type, Damage, KnockBack, mod.ProjectileType(projectileName), Main.myPlayer);
				}
			}
		}
	}
}