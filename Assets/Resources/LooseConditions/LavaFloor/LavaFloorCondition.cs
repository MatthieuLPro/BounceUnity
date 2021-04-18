using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFloorCondition : LooseCondition
{
    private bool inTheZone = false;
    public bool InTheZone { get; set; }

    public override void CheckDefeat() {
        if (InTheZone) {
            IsLoosing = true;
        }
    }
}
