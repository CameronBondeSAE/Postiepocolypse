using System;
using System.Collections;
using System.Collections.Generic;
using Tanks;
using AlexM;
using JonathonMiles;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AlexM
{
	public class InteractRay : MonoBehaviour
	{
		private bool         Ray;
		private CamMouseLook _camMouseLook;
		[HideInInspector]
		public RaycastHit hit;

		public event Action<GameObject> hitObjEvent;
		private void Awake()
		{
			_camMouseLook = GetComponentInChildren<CamMouseLook>();
		}

		private void FixedUpdate()
		{
			
		}

		void Update()
		{
			Debug.DrawRay(_camMouseLook.camera.transform.position, _camMouseLook.camera.transform.forward, Color.green);
		}

		public void SendRay(InputAction.CallbackContext obj)
		{
			if (obj.performed)
			{
				var t = _camMouseLook.camera.transform;
				Ray = Physics.Raycast(t.position, t.forward, out hit );
				Debug.Log(hit.transform.name);
				hitObjEvent?.Invoke(hit.transform.gameObject);

				Debug.DrawLine(t.position, hit.point, Color.green, 3f);
				
				// TODO Cam hack
				Interactable interactable = hit.transform.GetComponent<Interactable>();
				if (interactable)
				{
					interactable.Interact();
				}
			}
		}
		
	}
}
