using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AlexM
{
	public class NetworkingTest : NetworkBehaviour
	{
	#region Variables

		private float count;
		private bool  DoCount = true;

		public Light[] lights;

		public bool lightState;
		public bool StopLoop;

	#endregion

	#region LocalStuff

		private void Start()
		{
			if (isServer)
			{
				//InvokeRepeating("RpcLightState", 1f, 1f);
				StartCoroutine(Repeater());
			}
		}

		private void Update()
		{
			if (InputSystem.GetDevice<Keyboard>().tKey.wasPressedThisFrame)
			{
				CmdFirstCommand();
			}

			if (InputSystem.GetDevice<Keyboard>().lKey.wasPressedThisFrame)
			{
				StartCoroutine(Repeater());
			}
		}

		IEnumerator Repeater()
		{
			while (true)
			{
				lightState = true;
				RpcLightState(lightState);
				yield return new WaitForSeconds(1f);
				lightState = false;
				RpcLightState(lightState);
				yield return new WaitForSeconds(0.5f);
				if (StopLoop)
				{
					break;
				}
			}
		}

		IEnumerator Count(float time)
		{
			if (DoCount)
			{
				count++;
				Debug.Log("P: " + count);
				DoCount = false;
			}

			yield return new WaitForSeconds(time);
			DoCount = true;
			StartCoroutine(Count(1f));
		}

	#endregion


	#region ServerStuff

		void ToggleLightState()
		{
			if (isServer)
			{
				foreach (var _light in lights)
				{
					if (_light.gameObject.activeSelf)
					{
						_light.gameObject.SetActive(false);
					}
					else
					{
						_light.gameObject.SetActive(true);
					}
				}
			}
		}


		[Command(ignoreAuthority = true)]
		void CmdFirstCommand()
		{
			Debug.Log("Client command sent! "); //+ netId.ToString());
			RpcRespondToCommand();
		}

	#endregion

	#region ClientStuff

		[ClientRpc]
		void RpcLightState(bool _lightState)
		{
			foreach (var _light in lights)
			{
				_light.gameObject.SetActive(_lightState);
			}
		}

		[ClientRpc]
		void RpcRespondToCommand()
		{
			Debug.Log("Server responding to client command!!");
		}

	#endregion
	}
}