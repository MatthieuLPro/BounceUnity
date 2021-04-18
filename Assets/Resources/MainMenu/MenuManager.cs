using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

public class MenuManager : MonoBehaviour
{
    [Header("Steps of the menu")]
    [SerializeField]
    public GameObject[] menuOptionsSteps;

    private List<MenuOptionsList> menuOptionsList;

    [Header("Movement sound")]
    [SerializeField]
    private AudioClip moveSound;

    [Header("Select sound")]
    [SerializeField]
    private AudioClip selectSound;

    private int currentMenuStep;
    public int CurrentMenuStep { get; set; }

    private int currentOptionIndex;

    public Color32 selectedColor;
    public Color32 notSelectedColor;

#region Unity Functions
    void Start() {
        menuOptionsList = new List<MenuOptionsList>();
        foreach (GameObject menuOptionStep in menuOptionsSteps)
        {
            menuOptionsList.Add(menuOptionStep.GetComponent<MenuOptionsList>());            
        }
        currentMenuStep = 0;
        currentOptionIndex = 0;
        UpdateColor();
        UpdateStep(currentMenuStep);
    }
#endregion

#region Public Functions
    public void LaunchOption() {
        EazySoundManager.PlaySound(selectSound, 2.0f);
        menuOptionsList[currentMenuStep].menuOptions[currentOptionIndex].Call(); 
    }

    public void UpdateStep(int step) {
        currentMenuStep = step;
        foreach (GameObject menuOptionsStep in menuOptionsSteps) {
            menuOptionsStep.SetActive(false);
        }
        menuOptionsSteps[currentMenuStep].SetActive(true);
        currentOptionIndex = 0;
        UpdateColor();
    }

    public void UpdateCurrentOptionIndex(float y) {
        EazySoundManager.PlaySound(moveSound, 2.0f);
        if (y > 0) {
            currentOptionIndex -= 1;
            if (currentOptionIndex < 0) currentOptionIndex = menuOptionsList[currentMenuStep].menuOptions.Count - 1;
        } else if (y < 0) {
            currentOptionIndex += 1;
            if (currentOptionIndex >= menuOptionsList[currentMenuStep].menuOptions.Count) currentOptionIndex = 0;
        }
        UpdateColor();
    }
#endregion

#region Private Functions
    private void UpdateColor() {
        foreach (MenuOptions option in menuOptionsList[currentMenuStep].menuOptions)
        {
            option.UpdateImageColor(notSelectedColor);
        }
        menuOptionsList[currentMenuStep].menuOptions[currentOptionIndex].UpdateImageColor(selectedColor);
    }
#endregion
}
