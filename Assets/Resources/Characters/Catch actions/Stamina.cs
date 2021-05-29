using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    private float recoverSpeed;
    private bool consumingIsLaunched;

    private bool isConsuming;
    private bool recoveringIsLaunched;
    private float consumingSpeed;

    [SerializeField]
    private StaminaData datas;

#region Unity Functions
    void Start() {
        recoverSpeed = .8f;
        consumingSpeed = .5f;
        consumingIsLaunched = false;
        recoveringIsLaunched = false;
        isConsuming = false;
    }

    void Update() {
        if (!isConsuming && !recoveringIsLaunched && datas.CurrentStaminaIsOverMax()) {
            StartCoroutine(RecoverStamina());
        }
    }
#endregion
#region Public Functions
    public void ConsumeStamina(int value) {
        if (!consumingIsLaunched && datas.StaminaIsNotEmpty()) {
            StartCoroutine(ConsumingStamina(value));
        }
    }

    public void UpdateConsumingStamina(bool value) {
        isConsuming = value;
    }
#endregion
#region Private Functions
    private IEnumerator ConsumingStamina(int value) {
        consumingIsLaunched = true;
        yield return new WaitForSeconds(consumingSpeed);
        datas.UpdateCurrentStamina(value * -1);
        consumingIsLaunched = false;
    }
    private IEnumerator RecoverStamina() {
        recoveringIsLaunched = true;
        yield return new WaitForSeconds(recoverSpeed);
        datas.UpdateCurrentStamina(1);
        recoveringIsLaunched = false;
    }
#endregion
}
