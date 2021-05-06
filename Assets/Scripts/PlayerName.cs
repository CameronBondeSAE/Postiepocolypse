using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class CityData
{
	public string city;
	public float  lat;
	public float  lng;
	public string country;
	public string iso2;
	public string admin_name;
	public string capital;
	public int    population;
	public int    population_proper;
}

public class PlayerName : NetworkBehaviour
{
	public string     JSON;
	public CityData[] cityData;

	[SyncVar]
	public string playerName;

	public override void OnStartServer()
	{
		if (isServer)
		{
			cityData = JsonHelper.FromJson<CityData>(JSON);

			playerName = cityData[Random.Range(0, cityData.Length)].city;
		}
	}

	public override void OnStartClient()
	{
		StartCoroutine(TextUpdateHack());
	}

	IEnumerator TextUpdateHack()
	{
		while (true)
		{
			// HACK TODO
			TextMeshPro textMeshProUGUI = GetComponentInChildren<TextMeshPro>();
			if (textMeshProUGUI != null)
			{
				textMeshProUGUI.text = playerName;
			}

			yield return new WaitForSeconds(0.1f);
		}

		yield return null;
	}
}


public static class JsonHelper
{
	public static T[] FromJson<T>(string json)
	{
		Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
		return wrapper.Items;
	}

	public static string ToJson<T>(T[] array)
	{
		Wrapper<T> wrapper = new Wrapper<T>();
		wrapper.Items = array;
		return JsonUtility.ToJson(wrapper);
	}

	public static string ToJson<T>(T[] array, bool prettyPrint)
	{
		Wrapper<T> wrapper = new Wrapper<T>();
		wrapper.Items = array;
		return JsonUtility.ToJson(wrapper, prettyPrint);
	}

	[Serializable]
	private class Wrapper<T>
	{
		public T[] Items;
	}
}