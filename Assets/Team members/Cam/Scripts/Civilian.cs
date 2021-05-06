using System;
using System.Collections;
using System.Collections.Generic;
using JonathonMiles;
using Mirror;
using RileyMcGowan;
using TimPearson;
using UnityEngine;
using Random = UnityEngine.Random;

public class Civilian : NetworkBehaviour
{
	public Gradient    healthColour;
	public AudioSource audioSource;
	public Renderer    renderer;
	public AudioClip   deathClip;
	public AudioClip   nearDeathClip;
	public Health      health;
	public float       fallOverPushForce = 100f;
	public Energy      energy;


	// Start is called before the first frame update
	void Start()
	{
		health.damagedEvent += OndamagedEvent;
		health.deathEvent   += OndeathEvent;
		health.healedEvent  += h => UpdateVisuals();
		energy.lowEnergy    += OnlowEnergy;

		health.currentHealth = Random.Range(health.maxHealth - health.maxHealth / 10f, health.maxHealth);
		energy.CurrentAmount = Random.Range(energy.MaxAmount - energy.MaxAmount / 10f, energy.MaxAmount);
	}

	void OndamagedEvent(Health arg1, float arg2, Health.DamageType arg3)
	{
		if (health.currentHealth < health.maxHealth / 3f)
		{
			RpcOndamagedEvent();
		}
	}

	void OndeathEvent(Health obj)
	{
		RpcOndeathEvent();
	}

	private void OnlowEnergy(Energy energy)
	{
		if (isServer)
		{
			health.DoDamage(10f, Health.DamageType.Normal);
			energy.CurrentAmount = 5f;
		}
	}


	[ClientRpc]
	private void RpcOndeathEvent()
	{
		// play sound
		audioSource.clip = deathClip;
		audioSource.Play();
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

		if (isServer)
		{
			GetComponent<Rigidbody>().AddTorque(Random.Range(-fallOverPushForce, fallOverPushForce), Random.Range(-fallOverPushForce, fallOverPushForce), Random.Range(-fallOverPushForce, fallOverPushForce));
			Destroy(gameObject, 4f);
		}
	}


	[ClientRpc]
	private void RpcOndamagedEvent()
	{
		audioSource.clip = nearDeathClip;
		audioSource.Play();
		
		UpdateVisuals();
	}

	public Color value;

	private void UpdateVisuals()
	{
		value = healthColour.Evaluate(1f - (health.currentHealth / health.maxHealth));
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