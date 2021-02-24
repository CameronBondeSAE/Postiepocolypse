using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

namespace Cam
{
	public class NetworkingTest : NetworkBehaviour
	{
		public AnimationCurve curve;
		public Gradient       gradient;

		// [SyncVar]
		public Vector3 scale;

		#region Server

		/// <summary>
		/// Demo code. Random scale
		/// </summary>
		void Start()
		{
			if (isServer)
			{
				InvokeRepeating("RandomScaleTest", 1f, 1f);
			}
		}

		public void RandomScaleTest()
		{
			if (isServer)
			{
				scale = new Vector3(Random.RandomRange(-1f, 1f), Random.RandomRange(-1f, 1f), Random.RandomRange(-1f, 1f));
				RpcSetScale(scale);
			}
		}

		#endregion


		#region Client

		/// <summary>
		/// Client only
		/// </summary>
		/// <param name="_scale"></param>
		[ClientRpc]
		public void RpcSetScale(Vector3 _scale)
		{
			transform.localScale = _scale;
		}

		public void ChangeToRed()
		{
			GetComponent<MeshRenderer>().material.color = Color.red;
		}

		public void ChangeToBlue()
		{
			GetComponent<MeshRenderer>().material.color = Color.blue;

			// Rigidbody r;
			// r.addrel
		}

		#endregion
	}
}