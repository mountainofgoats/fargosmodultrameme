using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items.SpecialWeapons
{
	public class StormBreaker : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 112;
			item.type = 1;
			item.knockBack = 6f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			DLCGlobalItem newlight = new DLCGlobalItem();
			Vector2 offSet = new Vector2(0, 10);

			newlight.CreateProjIfCloseToTarget("DirectStormBreakerLightning", type, damage, knockBack, 80f, offSet);

			return true;
		}
	}
}
