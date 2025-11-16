local IntermittentSoundSource = {}

IntermittentSoundSource.name = "OzmasOddities/IntermittentSoundSource"
IntermittentSoundSource.texture = "loenn/ozma/oddities/IntermittentSoundSource"
IntermittentSoundSource.placements = {
    name = "IntermittentSoundSource",
    data = {
        sound = "",
        flag = "",
        minDelay = 3.0,
        maxDelay = 5.0,
        minVolume = 0.7,
        maxVolume = 1.0,
        parameter = "",
        paramValue = ""
    }
}

IntermittentSoundSource.fieldOrder = {"x", "y", "sound", "flag", "minDelay", "maxDelay", "minVolume", "maxVolume", "parameter", "paramValue"}

return IntermittentSoundSource