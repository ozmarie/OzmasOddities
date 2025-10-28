using Celeste.Mod.Entities;
using Monocle;
using Microsoft.Xna.Framework;

namespace Celeste.Mod.OzmasOddities.Controllers
{
    [CustomEntity("OzmasOddities/UnpauseController")]
    public class UnpauseController : Entity
    {
        public string flag;
        public UnpauseController(EntityData data, Vector2 offset) : base(data.Position + offset)
        {
            base.Tag = Tags.PauseUpdate;
            flag = data.Attr("flag", "");
        }

        public override void Update()
        {
            base.Update();
            Level level = SceneAs<Level>();
            if (string.IsNullOrEmpty(flag) || level.Session.GetFlag(flag) && !string.IsNullOrEmpty(flag))
            {
                if (level.PauseMainMenuOpen)
                {
                    TextMenu textmenu = level.Entities.FindFirst<TextMenu>();
                    level.PauseMainMenuOpen = false;
                    level.Paused = false;
                    if (textmenu != null)
                    {
                        textmenu.RemoveSelf();
                    }
                    level.unpauseTimer = 0.15f;
                }
            }
        }
    }
}
