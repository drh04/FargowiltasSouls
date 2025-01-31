﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Projectiles.BossWeapons
{
    internal class BlenderProj : ModProjectile
    {
        public int Counter = 0;

        public override string Texture => "FargowiltasSouls/Projectiles/BossWeapons/DicerProj";

        public override void SetStaticDefaults()
        {
            // Vanilla values range from 3f(Wood) to 16f(Chik), and defaults to -1f. Leaving as -1 will make the time infinite.
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1f;
            // Vanilla values range from 130f(Wood) to 400f(Terrarian), and defaults to 200f
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 400f;
            // Vanilla values range from 9f(Wood) to 17.5f(Terrarian), and defaults to 10f
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 17.5f;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Kraken);
            projectile.extraUpdates = 0;
            projectile.width = 19;
            projectile.height = 19;
            //yoyo ai
            projectile.aiStyle = 99;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.scale = 1f;
        }

        public override void AI()
        {
            if (Counter < 5)
            {
                int type = mod.ProjectileType("BlenderProj2");

                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 5f, type, (int) (projectile.damage * 0.5f), 2 , projectile.owner);
            }

            Counter++;
        }

        public override void PostAI()
        {
            /*if (Main.rand.Next(2) == 0)
            {
                int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, 16, 0f, 0f, 0, default(Color), 1f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].scale = 1.6f;
            }*/
        }
    }
}