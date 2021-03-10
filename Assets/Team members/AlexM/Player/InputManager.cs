using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexM
{
	public class InputManager : PlayerBase
	{
		private Inputs         _controls;
		private PlayerMovement _pMovement;
		private CamMouseLook   _camScript;

		[HideInInspector]
		public Vector2 moveDirection;

		private void GetReferences()
		{
			_pMovement = GetComponent<PlayerMovement>();
			_camScript = GetComponentInChildren<CamMouseLook>();
		}

		private void ControlSetup()
		{
			_controls = new Inputs();
			_controls.Enable();
			_controls.Movement.Move.performed       += _pMovement.InputValue;
			_controls.Movement.Move.canceled        += _pMovement.InputValue;
			_controls.Movement.Jump.performed       += _pMovement.JumpInput;
			_controls.Movement.Jump.canceled        += _pMovement.JumpInput;
			_controls.Movement.Flashlight.performed += _camScript.ToggleLight;
			_controls.Movement.Flashlight.canceled  += _camScript.ToggleLight;
			_controls.Movement.Sprint.performed     += _pMovement.Sprint;
			_controls.Movement.Sprint.canceled      += _pMovement.Sprint;
			_controls.Movement.Crouch.performed     += _pMovement.Crouch;
			_controls.Movement.Crouch.canceled      += _pMovement.Crouch;
			// if (_gameManager)
			// {
			// 	_controls.Movement.Menu.performed += _gameManager.Pause;
			// 	_controls.Movement.Menu.canceled  += _gameManager.Pause;
			// }
		}

		private void Awake()
		{
			GetReferences();
			ControlSetup();
		}

		private void OnEnable()
		{
			if (_controls != null)
			{
				_controls.Enable();
			}
		}

		private void OnDisable()
		{
			if (_controls != null)
			{
				_controls.Disable();
			}
		}
	}
}