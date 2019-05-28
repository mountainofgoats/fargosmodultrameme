using Terraria;
using Terraria.ModLoader;

namespace FargowiltasDLC.NPCs
{
	public class DLCGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;

		public override void AI(NPC npc)
		{
            //redoing maso ex soon tm
		}

		public override void NPCLoot(NPC npc)
		{
			Player player = Main.player[Main.myPlayer];
			if (player.ZoneBeach && npc.lifeMax > 5 && !npc.friendly && Main.hardMode && NPC.downedGolemBoss)
			{
				if (Main.rand.Next(100) == 0)
					Item.NewItem(npc.getRect(), mod.ItemType("WaterEssence"));
			}
		}
	}
}
