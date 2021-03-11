using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flare : MonoBehaviour
{
    [Tooltip("Expects a value between 1-100.")]
    public int flareDuration = 40;
    
    private Rigidbody rb;
    
    private ParticleSystem ps;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ps = GetComponent<ParticleSystem>();
        ps.Play();
        StartCoroutine(FlareLifeTimer());
    }

    IEnumerator FlareLifeTimer()
    {
        yield return new WaitForSeconds(flareDuration);
        Destroy(gameObject);
    }
}