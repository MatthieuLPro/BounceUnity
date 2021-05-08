using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustEffect : MonoBehaviour
{
    private ParticleSystem dust;
    void Start()
    {
        dust = GetComponent<ParticleSystem>();
    }

    public void Call() {
        dust.Play();
    }
}
