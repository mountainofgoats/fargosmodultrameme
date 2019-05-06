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
			Tooltip.SetDefault("One of the 6 Infinity Stones, wielding infinite power.\n+150% damage\n+150% firework damage\nEvery time you attack an enemy you get +1% attack boost. Caps at 150%. Restored if not attacking for 20 seconds\n A chance to hit for 5X damage");
		}

        public override void ModifyTooltips(List<TooltipLine> list)
		{
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(60, 36, 181));

					Mod DBZmod = ModLoader.GetMod("DBZMOD");

					if (DBZmod != null)
						tooltipLine.text += "\n+3500 max Ki\n+150% Ki Damage\n+30 Ki regen";
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
			MyPlayer DBZModPlayer = player.GetModPlayer<MyPlayer>(dBZMOD);

			player.meleeDamage += 1.5f;
			player.magicDamage += 1.5f;
			player.minionDamage += 1.5f;
			player.rangedDamage += 1.5f;
			player.thrownDamage += 1.5f;
			player.GetModPlayer<FireworkClass.FireworkDamagePlayer>().fireworkDamage += 1.5f;
			player.GetModPlayer<DLCPlayer>().stoneAbilityPb = true;

			if (dBZMOD != null)
			{
				DBZModPlayer.kiDamage += 1.5f;
				DBZModPlayer.kiMax2 += 3500;
				DBZModPlayer.kiRegen += 2;

				if (DBZModPlayer.isInstantTransmission1Unlocked)
				{
					DBZModPlayer.kiRegen += 1;
				}
			}
		}

		public override void DrawHands(ref bool drawHands, ref bool drawArms)
		{
			drawArms = true;
			drawHands = true;
		}
	}

	public class PowerStoneDraw : ModPlayer
	{
		public static readonly PlayerLayer EffectOnUse = new PlayerLayer("FargowiltasDLC", "EffectOnuse", PlayerLayer.Skin, delegate (PlayerDrawInfo drawInfo)
		{
			Player drawPlayer = drawInfo.drawPlayer;
			Mod mod = ModLoader.GetMod("FargowiltasDLC");

			Texture2D texture = mod.GetTexture("Items/Special/PowerStoneEffect");
			Vector2 Position = drawInfo.position;
			Position.Y += 14;
			DrawData value = new DrawData(texture, new Vector2((float)((int)(drawInfo.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawInfo.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), Color.White, drawPlayer.bodyRotation, drawInfo.bodyOrigin, 1f, drawInfo.spriteEffects, 0);

			value.shader = (int)drawPlayer.dye[2].dye;
			Main.playerDrawData.Add(value);
		});

		public override void ModifyDrawLayers(List<PlayerLayer> layers)
		{
			int armsLayer = layers.FindIndex(PlayerLayer => PlayerLayer.Name.Equals("HandOffAcc"));

			if (armsLayer != -1)
			{
				EffectOnUse.visible = true;
				layers.Insert(armsLayer + 1, EffectOnUse);
			}
		}
	}
}

