using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Threading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Thread thread = new Thread(DoStuff);
        thread.Start();
    }

    // This is running in a thread
    private void DoStuff()
    {
        Debug.Log("I'm waking up!");
        Thread.Sleep(4000);
        Debug.Log("I'm alive!");
        Thread.Sleep(4000);
        Debug.Log("I'm dead!");
    }
}
