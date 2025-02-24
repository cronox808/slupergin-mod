using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace slupergin.Content.Projectiles
{
    public class MySwordProjectileSprite1 : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 0; // No usar ningún estilo de IA predefinido
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 2; // Cuántos enemigos puede penetrar
            Projectile.timeLeft = 600; // Duración del proyectil en ticks
            Projectile.light = 0.5f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            // Establecer la rotación del proyectil basada en su velocidad//
            Projectile.rotation = Projectile.velocity.ToRotation();

            // Cambiar entre tres sprites cada 10 ticks
            int frameSpeed = 4;
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= frameSpeed)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame >= 3) // Suponiendo que tienes 3 sprites
                {
                    Projectile.frame = 0;
                }
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            // Cargar y dibujar el sprite correspondiente
            string spritePath = $"slupergin/Content/Projectiles/MySwordProjectileSprite{Projectile.frame + 1}";
            try
            {
                Texture2D texture = ModContent.Request<Texture2D>(spritePath).Value;
                Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition,
                    null, lightColor, Projectile.rotation, // Aplicar la rotación
                    new Vector2(texture.Width / 2, texture.Height / 2), Projectile.scale, SpriteEffects.None, 0);
            }
            catch (Exception e)
            {
                Main.NewText($"Error cargando el sprite: {e.Message}");
            }

            return false; // Devuelve false para evitar que Terraria dibuje el sprite por defecto.
        }
    }
}


