using System;
using Celeste.Mod.OzmasOddities.Controllers;
using System.Reflection;
using MonoMod.RuntimeDetour;

namespace Celeste.Mod.OzmasOddities;

public class OzmasOdditiesModule : EverestModule {
    public static OzmasOdditiesModule Instance { get; private set; }

    public override Type SettingsType => typeof(OzmasOdditiesModuleSettings);
    public static OzmasOdditiesModuleSettings Settings => (OzmasOdditiesModuleSettings) Instance._Settings;

    public override Type SessionType => typeof(OzmasOdditiesModuleSession);
    public static OzmasOdditiesModuleSession Session => (OzmasOdditiesModuleSession) Instance._Session;

    public override Type SaveDataType => typeof(OzmasOdditiesModuleSaveData);
    public static OzmasOdditiesModuleSaveData SaveData => (OzmasOdditiesModuleSaveData) Instance._SaveData;

    public OzmasOdditiesModule() {
        Instance = this;
#if DEBUG
        // debug builds use verbose logging
        Logger.SetLogLevel(nameof(OzmasOdditiesModule), LogLevel.Verbose);
#else
        // release builds use info logging to reduce spam in log files
        Logger.SetLogLevel(nameof(OzmasOdditiesModule), LogLevel.Info);
#endif
    }
    public static bool hasAnonHelper;
    public static bool hasCherryHelper;
    public static bool hasCommunalHelper;

    public override void Load() {
        On.Celeste.Level.StartPauseEffects += SnapshotController.ModPauseSnapshot;
        On.Celeste.Textbox.ctor_string_Language_Func1Array += SnapshotController.ModDialogSnapshot;
        On.Celeste.MiniTextbox.ctor += SnapshotController.ModMiniDialogSnapshot;
        On.Celeste.SpotlightWipe.Render += SpotlightController.NewWipeRender;
        On.Celeste.SpotlightWipe.ctor += SpotlightController.NewWipeCtor;
        IdleSoundController.hook_KillScratch = new ILHook(
            typeof(Player).GetMethod("<.ctor>b__280_2", BindingFlags.NonPublic | BindingFlags.Instance),
            IdleSoundController.KillIdleScratch);
        IdleSoundController.hook_KillSneeze = new ILHook(
            typeof(Player).GetMethod("<.ctor>b__280_2", BindingFlags.NonPublic | BindingFlags.Instance),
            IdleSoundController.KillIdleSneeze);
        IdleSoundController.hook_KillKnuckles = new ILHook(
            typeof(Player).GetMethod("<.ctor>b__280_2", BindingFlags.NonPublic | BindingFlags.Instance),
            IdleSoundController.KillIdleCrackKnuckles);
        EverestModuleMetadata anonHelper = new()
        {
            Name = "AnonHelper",
            Version = new Version(1,1,1)
        };
        EverestModuleMetadata cherryHelper = new()
        {
            Name = "CherryHelper",
            Version = new Version(1, 8, 2)
        };
        EverestModuleMetadata communalHelper = new()
        {
            Name = "CommunalHelper",
            Version = new Version(1, 24, 4)
        };
        hasAnonHelper = Everest.Loader.DependencyLoaded(anonHelper);
        hasCherryHelper = Everest.Loader.DependencyLoaded(cherryHelper);
        hasCommunalHelper = Everest.Loader.DependencyLoaded(communalHelper);
    }

    public override void Unload() {
        On.Celeste.Level.StartPauseEffects -= SnapshotController.ModPauseSnapshot;
        On.Celeste.Textbox.ctor_string_Language_Func1Array -= SnapshotController.ModDialogSnapshot;
        On.Celeste.MiniTextbox.ctor -= SnapshotController.ModMiniDialogSnapshot;
        On.Celeste.SpotlightWipe.Render -= SpotlightController.NewWipeRender;
        On.Celeste.SpotlightWipe.ctor -= SpotlightController.NewWipeCtor;
        IdleSoundController.hook_KillScratch?.Dispose();
        IdleSoundController.hook_KillSneeze?.Dispose();
        IdleSoundController.hook_KillKnuckles?.Dispose();
    }
}