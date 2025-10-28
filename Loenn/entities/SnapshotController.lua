local SnapshotController = {}

SnapshotController.name = "OzmasOddities/SnapshotController"
SnapshotController.texture = "loenn/ozma/oddities/SnapshotController"
SnapshotController.placements = {
    name = "SnapshotController",
    data = {
        disablePauseSnapshot = false,
        disableDialogSnapshot = false
    }
}

SnapshotController.fieldOrder = {"x", "y", "disablePauseSnapshot", "disableDialogSnapshot"}

return SnapshotController