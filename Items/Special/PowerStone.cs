using DBZMOD;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace FargowiltasDLC.Items.Special
{
	public class PowerStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Power Stone");
			Tooltip.SetDefault("One of the 6 Infinity Stones, wielding infinite power.\n+3500 max Ki\n+150% Ki Damage\n+150% firework damage\n+30 Ki regen\nEvery time you attack an enemy you get +1% attack boost. Caps at 150%. Restored if not attacking for 20 seconds");
		}

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(60, 36, 181));
                }
            }
        }

		public override void SetDefaults()
		{
			item.width = 44;
			item.height = 26;
			item.value = 1000000;
			item.accessory = true;
			item.expertOnly = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			Mod dBZMOD = ModLoader.GetMod("DBZMOD");
			MyPlayer DBZModPlayer = player.GetModPlayer<DBZMOD.MyPlayer>(dBZMOD);

			player.meleeDamage += 1.5f;
			player.magicDamage += 1.5f;
			player.minionDamage += 1.5f;
			player.rangedDamage += 1.5f;
			player.thrownDamage += 1.5f;
			DBZModPlayer.kiDamage += 1.5f;
			DBZModPlayer.kiMax2 += 3500;
			DBZModPlayer.kiRegen += 2;
			player.GetModPlayer<FireworkClass.FireworkDamagePlayer>().fireworkDamage += 1.5f;
			player.GetModPlayer<DLCPlayer>().stoneAbilityPb = true;

			if (DBZModPlayer.isInstantTransmission1Unlocked)
			{
				DBZModPlayer.kiRegen += 1;
			}
		}
    }

	public class PowerStoneDraw : ModPlayer
	{
		public static readonly PlayerLayer EffectOnuse = new PlayerLayer("FargowiltasDLC", "EffectOnuse", PlayerLayer.Skin, delegate (PlayerDrawInfo drawInfo)
		{
			Player drawPlayer = drawInfo.drawPlayer;
			Mod mod = ModLoader.GetMod("FargowiltasDLC");

			Texture2D texture = mod.GetTexture("Items/Special/PowerStoneEffect");
			Vector2 Position = drawInfo.position;
			Position.Y += 14;
			Vector2 pos = new Vector2((float)((int)(Position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(Position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2));
			DrawData value = new DrawData(texture, pos, new Rectangle?(drawPlayer.bodyFrame), drawInfo.bodyColor, drawPlayer.bodyRotation, drawInfo.bodyOrigin, 1f, drawInfo.spriteEffects, 0);

			Main.playerDrawData.Add(value);
		});
	}
}

