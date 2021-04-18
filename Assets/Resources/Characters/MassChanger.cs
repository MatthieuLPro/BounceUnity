using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassChanger : MonoBehaviour
{
    public Rigidbody2D rb;
    public enum Masses {
        Small,
        Standard,
        Big
    }
    private Dictionary<Masses, float> masses = new Dictionary<Masses, float>();
    private Masses currentMass;

#region Functions Unity
    void Start() {
        currentMass = Masses.Standard;
        InitializeMassScaleHash();
    }
#endregion
#region Functions public
    public void Call(Masses newMass) {
        UpdateCurrentMass(newMass);
        UpdateTransformScale(newMass);
    }
#endregion
#region Functions private
    private void InitializeMassScaleHash() {
        masses.Add(Masses.Small, 0.85f);
        masses.Add(Masses.Standard, 1f);
        masses.Add(Masses.Big, 2f);
    }
    private void UpdateCurrentMass(Masses newMass) {
        currentMass = newMass;
    }
    private void UpdateTransformScale(Masses newMass) {
        rb.mass = masses[newMass];
    }
#endregion
}
