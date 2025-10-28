using System;
using Celeste.Mod.Entities;
using Monocle;
using Microsoft.Xna.Framework;
using FMOD.Studio;

namespace Celeste.Mod.OzmasOddities.Controllers
{
    [CustomEntity("OzmasOddities/SpotlightController")]
    public class SpotlightController : Entity
    {
        private bool disable;
        private Vector2 locOffset;
        private float duration;
        private string sfxIn;
        private string sfxOut;
        private Color color;
        public SpotlightController(EntityData data, Vector2 offset) : base(data.Position + offset)
        {
            disable = data.Bool("disableSpotlight", false);
            locOffset = new Vector2(data.Float("offsetX"), data.Float("offsetY"));
            duration = data.Float("duration", 1.8f);
            sfxIn = data.Attr("introSoundEffect", "event:/none");
            sfxOut = data.Attr("outroSoundEffect", "event:/none");
            color = Calc.HexToColor(data.Attr("color", "000000"));
        }
        public static void NewWipeCtor(On.Celeste.SpotlightWipe.orig_ctor orig, SpotlightWipe self, Scene scene, bool wipeIn, Action onComplete = null)
        {
            orig(self, scene, wipeIn, onComplete);
            SpotlightController ctrl = (scene as Level).Entities.FindFirst<SpotlightController>();
            if (ctrl != null)
            {
                if (self.sfx != null)
                {
                    self.sfx.stop(STOP_MODE.IMMEDIATE);
                    self.sfx.release();
                    self.sfx = null;
                }
                if (!ctrl.disable)
                {
                    self.Duration = ctrl.duration;
                    self.sfx = wipeIn ? Audio.Play(ctrl.sfxIn) : Audio.Play(ctrl.sfxOut);
                }
                else
                {
                    self.Duration = 0;
                }
            }
        }
        public static void NewWipeRender(On.Celeste.SpotlightWipe.orig_Render orig, SpotlightWipe self, Scene scene)
        {
            SpotlightController ctrl = (scene as Level).Entities.FindFirst<SpotlightController>();
            if (ctrl == null) { orig(self, scene); } else
            {
                float num = (self.WipeIn ? self.Percent : (1f - self.Percent));
                float num2 = 288f + SpotlightWipe.Modifier;
                Vector2 focus = SpotlightWipe.FocusPoint;
                if (SaveData.Instance != null && SaveData.Instance.Assists.MirrorMode)
                {
                    focus.X = 320f - focus.X;
                }
                focus = Vector2.Add(focus, ctrl.locOffset);
                focus.X *= 6f;
                focus.Y *= 6f;
                SpotlightWipe.DrawSpotlight(radius: self.Linear ? (Ease.CubeInOut(num) * 1920f) : ((num < 0.2f) ? (Ease.CubeInOut(num / 0.2f) * num2) : ((!(num < 0.8f)) ? (num2 + (num - 0.8f) / 0.2f * (1920f - num2)) : num2)), position: focus, color: ctrl.color);
            }
        }
    }
}
