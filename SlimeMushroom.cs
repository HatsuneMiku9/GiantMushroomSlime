using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Repoio.NPCs.GiantMushroomSlime
{
	public class SlimeMushroom : ModProjectile
	{
		int timer;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mushroom");
			DisplayName.AddTranslation(GameCulture.Spanish, "Champiñón");
		}

		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 22;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.tileCollide = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 400;
		}

		public override void AI()
		{
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
			if (timer <= 20)
			{
				timer++;
			}
			else
			{
				projectile.velocity.X = projectile.velocity.X * 0.98f;
				projectile.velocity.Y = projectile.velocity.Y + 0.3f;
				if (projectile.velocity.Y > 16f)
				{
					projectile.velocity.Y = 16f;
				}
			}
		}

		public override void Kill(int timeLeft)
		{
			//Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.NPCDeath1, projectile.position);
			for (int i = 0; i < 22; i++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("MushroomDust"), projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.25f, 50, default(Color), 1f);
			}
		}
	}
}
