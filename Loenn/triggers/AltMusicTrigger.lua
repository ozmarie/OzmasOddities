local AltSongs = {}

AltSongs.options = {
    PrologueIntroVignette = "event:/game/00_prologue/intro_vignette",
    CityTheo = "event:/music/lvl1/theo",
    OldSiteDreamblockPart1 = "event:/music/lvl2/dreamblock_sting_pt1",
    OldSiteDreamblockPart2 = "event:/music/lvl2/dreamblock_sting_pt2",
    TempleMirrorCutscene = "event:/music/lvl5/mirror_cutscene",
    ReflectionSecretRoom = "event:/music/lvl6/secret_room",
    FarewellIntermissionPowerpoint = "event:/new_content/music/lvl10/intermission_powerpoint",
    FarewellFirstBirdCrash = "event:/new_content/music/lvl10/cinematic/bird_crash_first",
    FarewellSecondBirdCrash = "event:/new_content/music/lvl10/cinematic/bird_crash_second",
    FarewellGoldenRoom = "event:/new_content/music/lvl10/golden_room",
    Credits = "event:/music/menu/credits",
    Pico8Title = "event:/classic/pico8_mus_00",
    Pico8Area1 = "event:/classic/pico8_mus_01",
    Pico8Area2 = "event:/classic/pico8_mus_02",
    Pico8Area3 = "event:/classic/pico8_mus_03",
    Pico8windAmbience = "event:/classic/sfx61",
    MenuLevelSelect = "event:/music/menu/level_select",
    MenuCompleteArea = "event:/music/menu/complete_area",
    MenuCompleteSummit = "event:/music/menu/complete_summit",
    MenuCompleteBSide = "event:/music/menu/complete_bside"
}

local AltMusicTrigger = {}

AltMusicTrigger.name = "altMusicTrigger"
AltMusicTrigger.category = "audio"
AltMusicTrigger.fieldInformation = {
    track = {
        options = AltSongs.options
    }
}
AltMusicTrigger.placements = {
    name = "Alt Music Trigger",
    data = {
        track = "",
        resetOnLeave = true
    }
}

return AltMusicTrigger