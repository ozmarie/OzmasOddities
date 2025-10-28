local IdleSoundController = {}

IdleSoundController.name = "OzmasOddities/IdleSoundController"
IdleSoundController.texture = "loenn/ozma/oddities/IdleSoundController"
IdleSoundController.placements = {
    name = "IdleSoundController",
    data = {
        muteScratch = false,
        muteSneeze = false,
        muteKnuckleCrack = false
    }
}

IdleSoundController.fieldOrder = {"x", "y", "muteScratch", "muteSneeze", "muteKnuckleCrack"}

return IdleSoundController