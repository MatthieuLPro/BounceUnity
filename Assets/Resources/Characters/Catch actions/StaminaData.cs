using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="StaminaData", menuName="ScriptableObjects/StaminaData", order=1)]
public class StaminaData : ScriptableObject
{
    public int currentStamina;
    public int maxStamina;

    void Awake() {
        currentStamina = maxStamina;
    }

    public bool CurrentStaminaIsOverMax() {
        return currentStamina < maxStamina;
    }

    public bool StaminaIsNotEmpty() {
        return currentStamina > 0;
    }

    public bool StaminaIsEmpty() {
        return currentStamina == 0;
    }

    public bool StaminaIsMax() {
        return currentStamina == maxStamina;
    }

    public void UpdateCurrentStamina(int variation) {
        currentStamina += variation;
    }
}
