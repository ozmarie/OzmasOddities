local SpotlightController = {}

SpotlightController.name = "OzmasOddities/SpotlightController"
SpotlightController.texture = "loenn/ozma/oddities/SpotlightController"
SpotlightController.placements = {
    name = "SpotlightController",
    data = {
        offsetX = 0,
        offsetY = 0,
        duration = 1.8,
        introSoundEffect = "event:/game/general/spotlight_intro",
        outroSoundEffect = "event:/game/general/spotlight_outro",
        disableSpotlight = false,
        color = "000000"
    }
}

SpotlightController.fieldOrder = {"x","y","offsetX","offsetY","introSoundEffect","outroSoundEffect","color","duration","disableSpotlight"}

return SpotlightController