using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCTester : MonoBehaviour
{
    public int amount;

    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        DoIt();
    }

    // Update is called once per frame
    void Update()
    {
        // DoIt();
    }

    void DoIt()
    {
        for (int GO = 0; GO < amount; GO++)
        {
            var myGO = Instantiate(cube, new Vector3(0 + GO,0,0), Quaternion.identity);
            Debug.Log(myGO.name);
            Destroy(myGO);
        }
    }
}
