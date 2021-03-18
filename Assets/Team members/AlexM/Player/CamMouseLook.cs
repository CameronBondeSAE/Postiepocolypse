using System;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AlexM
{
	public class CamMouseLook : NetworkBehaviour
	{
		public float mouseSensitivity = 1f;
		public Camera camera;
		public Transform playerbody;
	
		//public float mouseSensitivity;
		public float pitch;
		public bool  cursorVisible;

		[HideInInspector]
		public float mouseX, mouseY;

		private Vector2 mouseDelta;

		private Quaternion lookAngle;
		// Start is called before the first frame update

		public override void OnStartLocalPlayer()
		{
			base.OnStartLocalPlayer();
			//camera.enabled = isLocalPlayer;
		}

		void Start()
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible   = false;
		}

		void FixedUpdate()
		{
			camera.enabled = isLocalPlayer;
			
			if (isLocalPlayer)
			{
				OldMouseMovement();
			}
		}

		void MouseInput()
		{
			mouseDelta = Mouse.current.delta.ReadValue();
		}

		[Command]
		void CmdLookAngle(Quaternion angle)
		{
			RpcLookAngle(angle);
		}
		
		[ClientRpc]
		void RpcLookAngle(Quaternion angle)
		{
			//Head's up/down movement
			camera.transform.localRotation = angle;
		}
		
		void OldMouseMovement()
		{
			MouseInput();
		
			float mouseXSpeed = mouseDelta.x;
			float mouseYSpeed = mouseDelta.y;

			pitch -= mouseYSpeed * mouseSensitivity;
			pitch =  Mathf.Clamp(pitch, -89f, 89f);
			
			//Rotate the main body of the player on the horizontal axis
			playerbody.Rotate(Vector3.up * (mouseXSpeed * mouseSensitivity));


			//client side prediction..
			//camera.transform.localRotation = Quaternion.Euler(pitch, 0, 0);
			lookAngle = Quaternion.Euler(pitch, 0, 0);
			CmdLookAngle(lookAngle);
			Cursor.visible = false;
		}
	}
}