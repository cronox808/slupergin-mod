using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Slupergin.Content.Projectiles
{
    public class MySwordProjectileSprite1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // Define cuántos frames totales tendrá el proyectil
            Main.projFrames[Projectile.type] = 7; 
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
            Projectile.light = 0.5f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.netImportant = true;

            // Opcional: si quieres que empiece en un frame aleatorio
            // Projectile.frame = Main.rand.Next(Main.projFrames[Projectile.type]);
        }

        public override void AI()
        {
            // Lógica de "Homing" como las balas de clorofita
            NPC target = FindClosestEnemy(400f);
            if (target != null)
            {
                Vector2 desiredVelocity = Vector2.Normalize(target.Center - Projectile.Center) * 10f;
                Projectile.velocity = Vector2.Lerp(Projectile.velocity, desiredVelocity, 0.1f);
            }

            // Rotación del proyectil
            Projectile.rotation = Projectile.velocity.ToRotation();

            // Lógica de animación por frames
            AnimateProjectile();
        }

        // Método que incrementa el frame del proyectil y lo regresa a 0 al final
        private void AnimateProjectile()
        {
            // Cada 5 ticks (ajusta a tu gusto) se avanza un frame
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= 1)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                }
            }
        }

        // tModLoader 1.4.4: firma actual de OnHitNPC
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            // Destruir el proyectil al impactar
            Projectile.Kill();
        }

        private NPC FindClosestEnemy(float maxDetectDistance)
        {
            NPC closest = null;
            float minDistance = maxDetectDistance;
            foreach (NPC npc in Main.npc)
            {
                if (npc.active && !npc.friendly && npc.lifeMax > 5)
                {
                    float distance = Vector2.Distance(Projectile.Center, npc.Center);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closest = npc;
                    }
                }
            }
            return closest;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            // Dibuja el sprite basado en el frame actual
            // Asume que tienes MySwordProjectileSprite1.png, MySwordProjectileSprite2.png, MySwordProjectileSprite3.png, etc.
            string spritePath = $"slupergin/Content/Projectiles/MySwordProjectileSprite{Projectile.frame + 1}";
            try
            {
                Texture2D texture = ModContent.Request<Texture2D>(spritePath).Value;
                Main.EntitySpriteDraw(
                    texture,
                    Projectile.Center - Main.screenPosition,
                    null,
                    lightColor,
                    Projectile.rotation,
                    new Vector2(texture.Width / 2, texture.Height / 2),
                    Projectile.scale,
                    SpriteEffects.None,
                    0
                );
            }
            catch (Exception e)
            {
                Main.NewText($"Error cargando el sprite: {e.Message}");
            }

            // Devuelve false para omitir el dibujo por defecto
            return false;
        }
    }
}
