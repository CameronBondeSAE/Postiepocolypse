using RileyMcGowan;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewModel : MonoBehaviour
{
	public Health      health;
	public AudioSource audioSource;

	void OnEnable()
	{
		health.deathEvent += HealthOndeathEvent;
	}

	void OnDisable()
	{
		health.deathEvent -= HealthOndeathEvent;
	}

	void HealthOndeathEvent(Health health)
	{
		audioSource.Play();
	}
}
