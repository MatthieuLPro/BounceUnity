using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPointLight : MonoBehaviour
{
    private Transform currentTransform;
    private Transform followedTransform;
    private bool isFollowing;
    public bool IsFollowing { get; }
    private Vector3 origin;

    void Start()
    {
        isFollowing = false;
        currentTransform = transform;
        origin = currentTransform.position;
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
}
