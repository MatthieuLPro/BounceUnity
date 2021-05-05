using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    [Header("Max stamina")]
    [SerializeField]
    private int maxStamina;

    private float CooldownSpeed;
    private bool consumingIsLoading;
    private int currentStamina;
    private bool isConsuming;
    private bool isLoading;

#region Unity Functions
    void Start() {
        CooldownSpeed = .8f;
        consumingIsLoading = false;
        currentStamina = maxStamina;
        isLoading = false;
    }

    void Update() {
        if (!isConsuming && !isLoading && currentStamina < maxStamina) {
            StartCoroutine(CooldownStamina());
        }
    }
#endregion
#region Public Functions
    public void ConsumeStamina(int value) {
        if (!consumingIsLoading && currentStamina > 0) {
            StartCoroutine(ConsumingStamina(value));
        }
    }

    public bool StaminaIsEmpty() {
        return currentStamina == 0;
    }
    public void UpdateConsumingStamina(bool value) {
        isConsuming = value;
    }
#endregion
#region Private Functions
    private IEnumerator ConsumingStamina(int value) {
        consumingIsLoading = true;
        yield return new WaitForSeconds(.5f);
        currentStamina -= value;
        consumingIsLoading = false;
    }
    private IEnumerator CooldownStamina() {
        isLoading = true;
        yield return new WaitForSeconds(CooldownSpeed);
        currentStamina += 1;
        isLoading = false;
    }
#endregion
}
