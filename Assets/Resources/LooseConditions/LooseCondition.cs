using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LooseCondition : MonoBehaviour
{
    private bool isLoosing = false;

    public abstract void CheckDefeat();

    public bool IsLoosing { get; set; }
}
