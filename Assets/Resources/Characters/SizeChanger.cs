using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    public Transform transform;
    public enum Sizes {
        Small,
        Standard,
        Big
    }
    private Dictionary<Sizes, float> sizeScale = new Dictionary<Sizes, float>();
    private Sizes currentSize;
    public Sizes CurrentSize { get; set; }

#region Functions Unity
    void Start() {
        CurrentSize = Sizes.Standard;
        InitializeSizeScaleHash();
    }
#endregion
#region Functions public
    public void Call(Sizes newSize) {
        UpdateCurrentSize(newSize);
        UpdateTransformScale(newSize);
    }
#endregion
#region Functions private
    private void InitializeSizeScaleHash() {
        sizeScale.Add(Sizes.Small, 5f);
        sizeScale.Add(Sizes.Standard, 10f);
        sizeScale.Add(Sizes.Big, 15f);
    }
    private void UpdateCurrentSize(Sizes newSize) {
        CurrentSize = newSize;
    }
    private void UpdateTransformScale(Sizes newSize) {
        float newSizeScale = sizeScale[newSize];
        transform.localScale = new Vector3 (newSizeScale, newSizeScale, 1f);
    }
#endregion
}
