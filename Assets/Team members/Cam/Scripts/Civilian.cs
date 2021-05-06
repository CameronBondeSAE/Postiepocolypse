using System;
using System.Collections;
using System.Collections.Generic;
using JonathonMiles;
using RileyMcGowan;
using TimPearson;
using UnityEngine;
using Random = UnityEngine.Random;

public class Civilian : MonoBehaviour
{
    public Gradient healthColour;
    public AudioSource audioSource;
    public Renderer renderer;
    public AudioClip deathClip;
    public AudioClip nearDeathClip;
    public Health health;
    public float fallOverPushForce = 100f;
    public Energy energy;


    // Start is called before the first frame update
    void Start()
    {
        health.damagedEvent += OndamagedEvent;
        health.deathEvent += OndeathEvent;
        health.healedEvent += h => UpdateVisuals();
        energy.lowEnergy += OnlowEnergy;

        health.currentHealth = Random.Range(health.maxHealth-health.maxHealth/10f, health.maxHealth);
        energy.CurrentAmount = Random.Range(energy.MaxAmount-energy.MaxAmount/10f, energy.MaxAmount);
    }

    private void OnlowEnergy(Energy energy)
    {
        health.DoDamage(10f, Health.DamageType.Normal);
        energy.CurrentAmount = 5f;
    }

    private void OndeathEvent(Health health)
    {
        // play sound
        audioSource.clip = deathClip;
        audioSource.Play();
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<Rigidbody>().AddTorque(Random.Range(-fallOverPushForce, fallOverPushForce),
            Random.Range(-fallOverPushForce, fallOverPushForce), Random.Range(-fallOverPushForce, fallOverPushForce));
        Destroy(gameObject, 4f);
    }

    private void OndamagedEvent(Health health, float damageDealt, Health.DamageType damageType)
    {
        if (health.currentHealth < health.maxHealth / 3f)
        {
            audioSource.clip = nearDeathClip;
            audioSource.Play();
        }

        UpdateVisuals();
    }

    public Color value;

    private void UpdateVisuals()
    {
        value = healthColour.Evaluate(1f-(health.currentHealth / health.maxHealth));
        renderer.material.SetColor("Colour", value);
    }

    // Catch health thrown by players
    private void OnCollisionEnter(Collision other)
    {
        // CamItem isn't a normal component, so I'm checking if them ItemBase IS a CamItem inherited from ItemBase
        PickUpItem pickUpItem = other.transform.GetComponent<PickUpItem>();
        if (pickUpItem != null && pickUpItem.item is CamItem)
        {
            health.currentHealth = health.maxHealth;
        }
    }
}