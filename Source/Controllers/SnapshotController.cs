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
        private bool pause;
        private bool dialog;
        private bool miniDialog;
        public SnapshotController(EntityData data, Vector2 offset) : base(data.Position + offset)
        {
            pause = data.Bool("disablePauseSnapshot", false);
            dialog = data.Bool("disableDialogSnapshot", false);
            miniDialog = data.Bool("disableMiniDialogSnapshot", false);
        }
        public override void Awake(Scene scene)
        {
            base.Awake(scene);
            OzmasOdditiesModule.Session.DisablePauseSnapshot = pause;
            OzmasOdditiesModule.Session.DisableDialogSnapshot = dialog;
            OzmasOdditiesModule.Session.DisableMiniDialogSnapshot = miniDialog;
        }
        public override void SceneEnd(Scene scene)
        {
            base.SceneEnd(scene);
            OzmasOdditiesModule.Session.DisablePauseSnapshot = false;
            OzmasOdditiesModule.Session.DisableDialogSnapshot = false;
            OzmasOdditiesModule.Session.DisableMiniDialogSnapshot = false;
        }
        public static void ModPauseSnapshot(On.Celeste.Level.orig_StartPauseEffects orig, Level self)
        {
            orig(self);
            if (OzmasOdditiesModule.Session.DisablePauseSnapshot) Audio.ReleaseSnapshot(Level.PauseSnapshot);
        }
        public static void ModDialogSnapshot(On.Celeste.Textbox.orig_ctor_string_Language_Func1Array orig, Textbox self, string dialog, Language language, Func<IEnumerator>[] events)
        {
            orig(self, dialog, language, events);
            if (OzmasOdditiesModule.Session.DisableDialogSnapshot) Audio.ReleaseSnapshot(Level.DialogSnapshot);
        }
        public static void ModMiniDialogSnapshot(On.Celeste.MiniTextbox.orig_ctor orig, MiniTextbox self, string dialogId)
        {
            orig(self, dialogId);
            if (OzmasOdditiesModule.Session.DisableMiniDialogSnapshot) Audio.ReleaseSnapshot(Level.DialogSnapshot);
        }
    }
}
