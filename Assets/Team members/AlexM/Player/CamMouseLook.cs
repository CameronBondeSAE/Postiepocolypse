using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamMouseLook : MonoBehaviour
{
	public float mouseSensitivity = 1f;
	public Light flashlight;

	public Transform playerbody;
	
	//public float mouseSensitivity;
	public float pitch;
	public bool  cursorVisible;

	[HideInInspector]
	public float mouseX, mouseY;


	private void Awake()
	{
		flashlight.enabled = false;
	}

	// Start is called before the first frame update
	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void FixedUpdate()
	{
		OldMouseMovement();
	}
	void OldMouseMovement()
	{
		//Using the new Input System..
		var   mouseDelta = Mouse.current.delta.ReadValue();
		float mouseXSpeed   = mouseDelta.x;
		float mouseYSpeed   = mouseDelta.y;
		//mouseX = Mathf.Clamp(mouseX, -3, 3);
		//mouseY = Mathf.Clamp(mouseY, -1, 1);
		
		pitch -= mouseYSpeed;
		pitch =  Mathf.Clamp(pitch, -90f, 90f);
		//GameManagerDependance- Needs to be removed to be used universally
		//if (!_gameManager.isPaused)
		{
			//Rotate the main body of the player on the horizontal axis
			playerbody.Rotate(Vector3.up * mouseXSpeed);
			
			//Head's up/down movement
			transform.localRotation = Quaternion.Euler(pitch, 0, 0);

			Cursor.visible = false;
		}
		// else
		// {
		// 	Cursor.visible = true;
		// }
	}

	public void ToggleLight(InputAction.CallbackContext obj)
	{
		if (obj.performed)
		{
			if (flashlight == null)
			{
				Debug.Log("Please add the players light source to Cam_MouseLook");
				return;
			}

			if (flashlight.enabled)
			{
				flashlight.enabled = false;
			}
			else if (!flashlight.enabled)
			{
				flashlight.enabled = true;
			}
		}
	}
}