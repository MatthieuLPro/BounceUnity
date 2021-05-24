using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CharacterPointLight : MonoBehaviour
{
    private Transform currentTransform;
    private Transform followedTransform;
    private bool isFollowing;
    public bool IsFollowing { get; }
    private Vector3 origin;

    private Light2D light;

    void Start()
    {
        isFollowing = false;
        currentTransform = transform;
        origin = currentTransform.position;
        light = GetComponent<Light2D>();
    }

    void Update()
    {
        if (isFollowing) {
            currentTransform.position = followedTransform.position;
        }
    }

    public void SetFollower(Transform transformToFollow) {
        followedTransform = transformToFollow;
        isFollowing = true;
    }

    public void RemoveFollower() {
        followedTransform = null;
        isFollowing = false;
        currentTransform.position = origin;
    }

    public void SetIntensity(float newIntensity) {
        light.intensity = 1f;
    }
}
