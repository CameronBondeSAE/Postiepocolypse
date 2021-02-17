using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScare : MonoBehaviour
{
    public Transform player;
    private Vector3 playerTransform;
    public float distanceToPlayer;
    public bool isScared;
    void Update()
    {
        if (isScared != true)
        {
            playerTransform = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
            transform.LookAt(playerTransform);
        }
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
    }
}
