using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioTesting : MonoBehaviour
{
	public AudioSource       AudioSource;
	public AudioChorusFilter AudioChorusFilter;
	public AudioLowPassFilter AudioLowPassFilter;
	public float             maxTimeBetweenBaseSounds = 10;
	public float             basePitch                = 0.2f;

	float randomPerlinStart;

	IEnumerator Start()
	{
		randomPerlinStart = Random.Range(0, 1000f);
		
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(0, maxTimeBetweenBaseSounds));
			if (!AudioSource.isPlaying)
			{
				AudioSource.Play();

				AudioSource.time = Random.Range(0, AudioSource.clip.length);
			}
		}

		yield return null;
	}

	// Update is called once per frame
    void Update()
	{
		AudioSource.volume = 0.5f + Mathf.PerlinNoise(randomPerlinStart + Time.time * 4f,      0) / 2f;
		AudioSource.pitch  = basePitch + Mathf.PerlinNoise(randomPerlinStart + Time.time / 5f, 0) / 25f;
		
		AudioLowPassFilter.cutoffFrequency = 1000f+Mathf.PerlinNoise(randomPerlinStart + Time.time*2f, 0) * 22000f;

		AudioChorusFilter.rate    = Mathf.PerlinNoise(randomPerlinStart + Time.time/2f,    0) * 5f;
		AudioChorusFilter.depth   = Mathf.PerlinNoise(randomPerlinStart + Time.time/2.24f, 0)/3f;
		AudioChorusFilter.wetMix1 = Mathf.PerlinNoise(randomPerlinStart + Time.time/1.3245f, 0);
	}
}
