using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AlexM
{
	public class HellPortal : NetworkBehaviour
	{
		public Gradient gradient;
		private Color   color;
		private float   intensity;
		[SyncVar,HideInInspector]
		public Vector3 scale;

		private void Start()
		{
			// InvokeRepeating("PulseScale", 1f, 3f);
		}


	#region ServerStuff
		public void PulseScale()
		{
			if (isServer)
			{
				scale = new Vector3(0, Random.Range(1.65f, 2.2f), Random.Range(0.85f, 1.2f));
				RpcSetScale(scale);
			}
		}

		public void ColorPulse()
		{
			gradient.mode = GradientMode.Blend;
			
		}

	#endregion

	#region ClientStuff
		[ClientRpc]
		public void RpcSetScale(Vector3 _scale)
		{
			transform.localScale = _scale;
		}
	#endregion
	}

}