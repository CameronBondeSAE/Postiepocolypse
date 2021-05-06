using RileyMcGowan;
using System;
using System.Collections;
using System.Collections.Generic;
using TimPearson;
using UnityEngine;

public class PlayerViewModel : MonoBehaviour
{
	public AudioClip deathClip;
	public AudioClip stepClip;
	
	public Health      health;
	public AudioSource audioSource;
	public SoundEmitter soundEmitter;

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
		audioSource.spatialBlend = 0.75f; // Keep death sound slightly audible
		audioSource.PlayOneShot(deathClip);
	}

	void StepSound()
	{
		audioSource.spatialBlend = 1f;
		audioSource.clip = stepClip;

		audioSource.Play();
		// soundEmitter.emit
	}
}
