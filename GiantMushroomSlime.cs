using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Repoio.NPCs.GiantMushroomSlime
{
	[AutoloadBossHead]
	public class GiantMushroomSlime : ModNPC
	{
		bool BigSlime1;
		bool BigSlime2;
		bool Slime1;
		bool Slime2;
		bool Slime3;
		bool Slime4;
		int timer;
		int MushroomDamage;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Giant Mushroom Slime");
			DisplayName.AddTranslation(GameCulture.Spanish, "Slime de champiñón gigante");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.width = 60;
			npc.height = 42;
			npc.damage = 20;
			npc.defense = 4;
			npc.lifeMax = 1000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 10000f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 1;
			aiType = 183;
			animationType = 244;
			npc.boss = true;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = 1250;
			npc.damage = 35;
		}

		public override void AI()
		{
			npc.width = (int)(60f * npc.scale);
			npc.height = (int)(42f * npc.scale);
			timer++;
			if (!Main.expertMode)
			{
				MushroomDamage = 17;
				MushroomDamage /= 2;
				npc.scale = (((float)npc.life / (float)npc.lifeMax) * 0.5f) + 0.75f;
				float mushSpeed45 = 6f * (float)(Math.Sin((float)Math.PI / 180f * 45f));
				if (timer >= 300)
				{
					if (Main.rand.Next(5) < 2)
					{
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -6f, 0f, mod.ProjectileType("SlimeMushroom"), MushroomDamage, 5f, 255, 0f, 0f);
					}
					if (Main.rand.Next(5) < 2)
					{
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -mushSpeed45, -mushSpeed45, mod.ProjectileType("SlimeMushroom"), MushroomDamage, 5f, 255, 0f, 0f);
					}
					if (Main.rand.Next(5) < 2)
					{
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, -6f, mod.ProjectileType("SlimeMushroom"), MushroomDamage, 5f, 255, 0f, 0f);
					}
					if (Main.rand.Next(5) < 2)
					{
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, mushSpeed45, -mushSpeed45, mod.ProjectileType("SlimeMushroom"), MushroomDamage, 5f, 255, 0f, 0f);
					}
					if (Main.rand.Next(5) < 2)
					{
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 6f, 0f, mod.ProjectileType("SlimeMushroom"), MushroomDamage, 5f, 255, 0f, 0f);
					}
					timer = 0;
				}
			}
			else
			{
				MushroomDamage = 26;
				MushroomDamage /= 4;
				npc.scale = (((float)npc.life / (float)npc.lifeMax) * 0.6f) + 0.9f;
				int timerLimit = 300 - (int)((float)(npc.lifeMax - npc.life) * 0.08f);
				float sin36 = 6.5f * (float)(Math.Sin((float)Math.PI / 180f * 36f));
				float cos36 = 6.5f * (float)(Math.Cos((float)Math.PI / 180f * 36f));
				float sin72 = 6.5f * (float)(Math.Sin((float)Math.PI / 180f * 72f));
				float cos72 = 6.5f * (float)(Math.Cos((float)Math.PI / 180f * 72f));
				if (timer >= timerLimit)
				{
					if (Main.rand.Next(2) == 0)
					{
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -6.5f, 0f, mod.ProjectileType("SlimeMushroom"), MushroomDamage, 5f, 255, 0f, 0f);
					}
					if (Main.rand.Next(2) == 0)
					{
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -sin36, -cos36, mod.ProjectileType("SlimeMushroom"), MushroomDamage, 5f, 255, 0f, 0f);
					}
					if (Main.rand.Next(2) == 0)
					{
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -sin72, -cos72, mod.ProjectileType("SlimeMushroom"), MushroomDamage, 5f, 255, 0f, 0f);
					}
					if (Main.rand.Next(2) == 0)
					{
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, sin72, -cos72, mod.ProjectileType("SlimeMushroom"), MushroomDamage, 5f, 255, 0f, 0f);
					}
					if (Main.rand.Next(2) == 0)
					{
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, sin36, -cos36, mod.ProjectileType("SlimeMushroom"), MushroomDamage, 5f, 255, 0f, 0f);
					}
					if (Main.rand.Next(2) == 0)
					{
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 6.5f, 0f, mod.ProjectileType("SlimeMushroom"), MushroomDamage, 5f, 255, 0f, 0f);
					}
					timer = 0;
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.OverworldDay.Chance * 0.02f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			int num;
			int num259 = 0;
			if (npc.life > 0)
			{
				while ((double)num259 < damage / (double)npc.lifeMax * 150.0)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("MushroomDust"), (float)hitDirection, -1f, 50, npc.color, (float)Main.rand.Next(100, 110) * 0.01f);
					num = num259;
					num259 = num + 1;
				}
			}
			if (npc.life <= 0)
			{
				for (int i = 0; i < 100; i++)
				{
					int a = Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("MushroomDust"), (float)(2 * hitDirection), -2f, 50, npc.color, (float)Main.rand.Next(100, 110) * 0.01f);
				}
			}
		}

		public override void NPCLoot()
		{
			if (!RepoioWorld.downedMushroom)
			{
				RepoioWorld.downedMushroom = true;
			}
			if (Main.expertMode)
			{
				if (Main.rand.Next(15) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MushroomSword"), 1, false, 0, false, false);
				}
				if (Main.rand.Next(15) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MushroomSpear"), 1, false, 0, false, false);
				}
				if (Main.rand.Next(15) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MushroomStaff"), 1, false, 0, false, false);
				}
				if (Main.rand.Next(15) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MushroomWand"), 1, false, 0, false, false);
				}
				if (Main.rand.Next(15) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MushroomBow"), 1, false, 0, false, false);
				}
				if (Main.rand.Next(15) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MushroomPistol"), 1, false, 0, false, false);
				}
				if (Main.rand.Next(15) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MushroomYoyo"), 1, false, 0, false, false);
				}
				if (Main.rand.Next(15) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MushroomBoomerang"), 1, false, 0, false, false);
				}
				if (Main.rand.Next(15) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThrowableMushroom"), Main.rand.Next(225, 275), false, 0, false, false);
				}
			}
			else
			{
				if (Main.rand.Next(20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MushroomSword"), 1, false, 0, false, false);
				}
				if (Main.rand.Next(20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MushroomSpear"), 1, false, 0, false, false);
				}
				if (Main.rand.Next(20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MushroomStaff"), 1, false, 0, false, false);
				}
				if (Main.rand.Next(20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MushroomWand"), 1, false, 0, false, false);
				}
				if (Main.rand.Next(20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MushroomBow"), 1, false, 0, false, false);
				}
				if (Main.rand.Next(20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MushroomPistol"), 1, false, 0, false, false);
				}
				if (Main.rand.Next(20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MushroomYoyo"), 1, false, 0, false, false);
				}
				if (Main.rand.Next(20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MushroomBoomerang"), 1, false, 0, false, false);
				}
				if (Main.rand.Next(20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThrowableMushroom"), Main.rand.Next(225, 275), false, 0, false, false);
				}
			}
		}
	}
}
