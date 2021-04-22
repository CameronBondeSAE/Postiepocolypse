using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerHandler : MonoBehaviour
{
    public int timeToLive;
    private void Start()
    {
        StartCoroutine(MarkerDelete(timeToLive));
    }

    public IEnumerator MarkerDelete(int timeToLive)
    {
        yield return new WaitForSeconds(timeToLive);
        Destroy(this.gameObject);
    }
}
