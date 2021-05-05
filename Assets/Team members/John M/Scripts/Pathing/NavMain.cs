using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using Damien;
using JonathonMiles;
using UnityEngine;

public class NavMain : MonoBehaviour
{
    private AntAIAgent _antAIAgent;
    public PatrolPoint currentTarget;
    public FOV itemFov;
    //public FOV playerFOV;
    public Transform itemTarget;
    public Transform playerTarget;
    public Transform depositLocation;
    public Inventory inventory;
    public bool fullInventroy;
    

    private void Awake()
    {
        _antAIAgent = GetComponent<AntAIAgent>();
    }

    void Start()
    {
        _antAIAgent.SetGoal("Arrived at Target");
        fullInventroy = false;
    }

    // Update is called once per frame
    private void Update()
    {
      SearchFOV();
      CheckInventory();
    }

    void SearchFOV()
    {
        if (itemFov.listOfTargets.Count != null)
        {
            if (itemFov.listOfTargets.Count > 0)
            {
                foreach (GameObject item in itemFov.listOfTargets)
                {
                    Debug.Log("Item has been found");
                    itemTarget = item.transform;
                    currentTarget = null;

                }
            }
        }
        
        /*if (playerFOV.listOfTargets.Count != null)
        {
            if (playerFOV.listOfTargets.Count > 0)
            {
                foreach (GameObject player in playerFOV.listOfTargets)
                {
                    Debug.Log("Player has been found");
                    playerTarget = player.transform;
                    //send the player position into the Retreat state script
                    currentTarget = null;

                }
            }
        }
        */
    }

    void CheckInventory()
    {
        //check if the inventory is full and if so, then run the full inventory function
        if (inventory.inventorySpace == inventory.items.Count)
        {
            FullInventory();
        }
    }
    void FullInventory()
    {
        //trigger the state to return to deposit the items here
    }
    
}
