﻿using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using DragonsBossSwarm;

namespace DragonsBossSwarm.Items
{
	public class SwarmHive1 : ModItem
	{

		public override string Texture => "Terraria/Item_" + ItemID.Abeemination;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Swarm Abeemination x5"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Summons 5 Queen Bees");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13; // This helps sort inventory know this is a boss summoning item.
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}

		public override void SetDefaults()
		{


			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.rare = ItemRarityID.Cyan;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.Item44;
			item.consumable = false;

			item.scale = 1;

		}

		public override bool CanUseItem(Player player)
		{
			// "player.ZoneUnderworldHeight" could also be written as "player.position.Y / 16f > Main.maxTilesY - 200"
			return !NPC.AnyNPCs(NPCID.QueenBee);
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.QueenBee);
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.QueenBee);
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.QueenBee);
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.QueenBee);
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.QueenBee);
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Abeemination, 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();

		}
	}
}