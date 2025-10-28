using Monocle;
using Microsoft.Xna.Framework;
using Celeste.Mod.Entities;

namespace Celeste.Mod.OzmasOddities.Entities
{
    [CustomEntity("OzmasOddities/ParallaxDecal")]
    public class ParallaxDecal : Decal
    {
        private Vector2 parallaxVector;
        public ParallaxDecal(EntityData data, Vector2 offset)
            : base(data.Attr("Path", ""), data.Position + offset, new Vector2(data.Float("ScaleX", 1f), data.Float("ScaleY", 1f)), data.Int("Depth", 9500))
        {
            Rotation = MathHelper.ToRadians(data.Float("Rotation", 0f));
            Color = Calc.HexToColorWithAlpha(data.Attr("Color", "FFFFFFFF"));
            parallaxVector = new Vector2(data.Float("ParallaxX", 0.1f), data.Float("ParallaxY", 0.1f));
            parallax = false;
            wave = null;
        }

        public override void Render()
        {
            Vector2 pos = Position;
            Camera camera = SceneAs<Level>().Camera;
            Vector2 camOffset = camera.Position + new Vector2(160f, 90f);
            Vector2 parallaxOffset = Vector2.Multiply(parallaxVector, Position - camOffset);
            Position += parallaxOffset;
            base.Render();
            Position = pos;
        }
    }
}
