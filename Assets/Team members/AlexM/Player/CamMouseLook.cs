using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamMouseLook : MonoBehaviour
{
	public Light flashlight;

	public Transform playerbody;

	//public float mouseSensitivity;
	public float xRotation;
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

	// Update is called once per frame
	void Update()
	{
		OldMouseMovement();
	}
	void OldMouseMovement()
	{
		//Using the new Input System..
		var   mousePos = Mouse.current.delta.ReadValue();
		float mouseX   = mousePos.x;
		float mouseY   = mousePos.y;
		mouseX = Mathf.Clamp(mouseX, -3, 3);
		mouseY = Mathf.Clamp(mouseY, -1, 1);
		
		xRotation -= mouseY;
		xRotation =  Mathf.Clamp(xRotation, -90f, 90f);
		//GameManagerDependance- Needs to be removed to be used universally
		//if (!_gameManager.isPaused)
		{
			//Rotate the main body of the player on the horizontal axis
			playerbody.Rotate(Vector3.up * mouseX);
			
			//Head's up/down movement
			transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

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