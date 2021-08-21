using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Update into ScriptObject

[CreateAssetMenu(fileName="ClimberData", menuName="ScriptableObjects/Climber/ClimberData", order=1)]
public class ClimberData : ScriptableObject
{
    public float wallDistanceOffset = 4f;
}
