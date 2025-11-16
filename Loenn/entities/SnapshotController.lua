local SnapshotController = {}

SnapshotController.name = "OzmasOddities/SnapshotController"
SnapshotController.texture = "loenn/ozma/oddities/SnapshotController"
SnapshotController.placements = {
    name = "SnapshotController",
    data = {
        disablePauseSnapshot = false,
        disableDialogSnapshot = false,
        disableMiniDialogSnapshot = false
    }
}

SnapshotController.fieldOrder = {"x", "y", "disablePauseSnapshot", "disableDialogSnapshot", "disableMiniDialogSnapshot"}

return SnapshotController