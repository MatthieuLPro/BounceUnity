using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName="InputsMapping", menuName="ScriptableObjects/Inputs/InputsMapping", order=1)]
public class InputsMapping : ScriptableObject
{
    public string currentMapping;
 
    public void UpdateMappingName(string newMapping) {
        currentMapping = newMapping;
    }
}
