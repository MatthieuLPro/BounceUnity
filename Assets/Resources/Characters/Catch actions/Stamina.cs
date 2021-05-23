using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    private float CooldownSpeed;
    private bool consumingIsLoading;
    private bool isConsuming;
    private bool isLoading;

    [SerializeField]
    private StaminaData datas;

#region Unity Functions
    void Start() {
        CooldownSpeed = .8f;
        consumingIsLoading = false;
        isLoading = false;
    }

    void Update() {
        if (!isConsuming && !isLoading && datas.CurrentStaminaIsOverMax()) {
            StartCoroutine(CooldownStamina());
        }
    }
#endregion
#region Public Functions
    public void ConsumeStamina(int value) {
        if (!consumingIsLoading && datas.StaminaIsNotEmpty()) {
            StartCoroutine(ConsumingStamina(value));
        }
    }

    public void UpdateConsumingStamina(bool value) {
        isConsuming = value;
    }
#endregion
#region Private Functions
    private IEnumerator ConsumingStamina(int value) {
        consumingIsLoading = true;
        yield return new WaitForSeconds(.5f);
        datas.UpdateCurrentStamina(value * -1);
        consumingIsLoading = false;
    }
    private IEnumerator CooldownStamina() {
        isLoading = true;
        yield return new WaitForSeconds(CooldownSpeed);
        datas.UpdateCurrentStamina(1);
        isLoading = false;
    }
#endregion
}
