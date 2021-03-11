using System;
using System.Collections;
using System.Collections.Generic;
using Tanks;
using UnityEngine;

namespace AlexM
{
	public class InteractRay : MonoBehaviour
	{
		private bool Ray;
		private CamMouseLook _camera;
		[HideInInspector]
		public RaycastHit hit;
		private void Awake()
		{
			_camera = GetComponentInChildren<CamMouseLook>();
		}

		private void FixedUpdate()
		{
			SendRay();
		}

		private void SendRay()
		{
			var t = _camera.transform;
			Ray = Physics.Raycast(t.position, t.forward, out hit );
		}
	}
}
