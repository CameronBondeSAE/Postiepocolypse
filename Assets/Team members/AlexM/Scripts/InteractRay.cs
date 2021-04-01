using JonathonMiles;
using System;
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

		public void Use(InputAction.CallbackContext obj)
		{
			if (obj.performed)
			{
				ShootRay();

				// TODO Cam hack
				Interactable interactable = hit.transform.GetComponent<Interactable>();
				if (interactable)
				{
					interactable.Interact(gameObject);
				}
			}
		}

		public void PickUp(InputAction.CallbackContext obj)
		{
			if (obj.performed)
			{
				ShootRay();

				// TODO Cam hack
				PickUpItem pickUpItem = hit.transform.GetComponent<PickUpItem>();
				if (pickUpItem)
				{
					pickUpItem.PickUp(gameObject);
					GetComponent<Inventory>().Add(pickUpItem.item);
				}
			}
		}

		void ShootRay()
		{
			Transform t = _camMouseLook.camera.transform;
			Ray = Physics.Raycast(t.position, t.forward, out hit);
			Debug.Log(hit.transform.name);
			Debug.DrawLine(t.position, hit.point, Color.green, 3f);
			hitObjEvent?.Invoke(hit.transform.gameObject);
		}
	}
}
