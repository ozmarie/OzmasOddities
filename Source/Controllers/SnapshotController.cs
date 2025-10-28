using Monocle;
using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections;

namespace Celeste.Mod.OzmasOddities.Controllers
{
    [CustomEntity("OzmasOddities/SnapshotController")]
    public class SnapshotController : Entity
    {
        public SnapshotController(EntityData data, Vector2 offset) : base(data.Position + offset)
        {
            OzmasOdditiesModule.Session.DisablePauseSnapshot = data.Bool("disablePauseSnapshot", false);
            OzmasOdditiesModule.Session.DisableDialogSnapshot = data.Bool("disableDialogSnapshot", false);
        }

        public static void ModDialogSnapshot(On.Celeste.Textbox.orig_ctor_string_Language_Func1Array orig, Textbox self, string dialog, Language language, Func<IEnumerator>[] events)
        {
            orig(self, dialog, language, events);
            if (OzmasOdditiesModule.Session.DisableDialogSnapshot) Audio.ReleaseSnapshot(Level.DialogSnapshot);
        }
        public static void ModPauseSnapshot(On.Celeste.Level.orig_StartPauseEffects orig, Level self)
        {
            orig(self);
            if (OzmasOdditiesModule.Session.DisablePauseSnapshot) Audio.ReleaseSnapshot(Level.PauseSnapshot);
        }
    }
}
