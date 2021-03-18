using System;
using System.Collections;
using System.Collections.Generic;
using Tanks;
using AlexM;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AlexM
{
	public class InteractRay : MonoBehaviour
	{
		private bool Ray;
		private CamMouseLook _camera;
		[HideInInspector]
		public RaycastHit hit;

		public Action<GameObject> hitObjEvent;
		private void Awake()
		{
			_camera = GetComponentInChildren<CamMouseLook>();
		}

		private void FixedUpdate()
		{
			
		}

		public void SendRay(InputAction.CallbackContext obj)
		{
			if (obj.performed)
			{
				var t = _camera.transform;
				Ray = Physics.Raycast(t.position, t.forward, out hit );
				Debug.Log(hit.transform.name);
				hitObjEvent.Invoke(hit.transform.gameObject);
			}
		}
		
	}
}
