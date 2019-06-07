﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Projectiles.Masomode
{
    public class PirateDeadeyeBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteor Shot");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.MeteorShot);
            aiType = ProjectileID.MeteorShot;
            projectile.friendly = false;
            projectile.ranged = false;
            projectile.hostile = true;
            projectile.penetrate = 6;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("Midas"), Main.rand.Next(300, 900));
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.penetrate > 1)
            {
                Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(SoundID.Item10, projectile.position);
                projectile.penetrate--;

                if (projectile.velocity.X != projectile.oldVelocity.X)
                    projectile.velocity.X = -projectile.oldVelocity.X;
                if (projectile.velocity.Y != projectile.oldVelocity.Y)
                    projectile.velocity.Y = -projectile.oldVelocity.Y;

                return false;
            }
            return true;
        }
    }
}