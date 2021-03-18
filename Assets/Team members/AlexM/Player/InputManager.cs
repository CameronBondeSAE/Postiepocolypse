using System;
using System.Collections;
using System.Collections.Generic;
using AlexM;
using UnityEngine;

namespace AlexM
{
	public class InputManager : PlayerBase
	{
	#region Variables

		private Inputs          _controls;
		private PlayerMovement  _pMovement;
		private CamMouseLook    _camScript;
		private InteractRay     _interactRay;
		private TorchController _torchController;

		[HideInInspector]
		public Vector2 moveDirection;

	#endregion

		private void GetReferences()
		{
			_pMovement = GetComponent<PlayerMovement>();
			_camScript = GetComponentInChildren<CamMouseLook>();
			_interactRay = GetComponent<InteractRay>();
			_torchController = _camScript.GetComponentInChildren<TorchController>();
		}

		private void ControlSetup()
		{
			_controls = new Inputs();
			_controls.Enable();
			_controls.Movement.Move.performed       += _pMovement.MovementInput;
			_controls.Movement.Move.canceled        += _pMovement.MovementInput;
			_controls.Movement.Jump.performed       += _pMovement.JumpInput;
			_controls.Movement.Jump.canceled        += _pMovement.JumpInput;
			_controls.Movement.Flashlight.performed += _torchController.FlashLightInput;
			_controls.Movement.Flashlight.canceled  += _torchController.FlashLightInput;
			_controls.Movement.Sprint.performed     += _pMovement.Sprint;
			_controls.Movement.Sprint.canceled      += _pMovement.Sprint;
			_controls.Movement.Crouch.performed     += _pMovement.CrouchInput;
			_controls.Movement.Crouch.canceled      += _pMovement.CrouchInput;
			_controls.Movement.Use.performed += _interactRay.SendRay;
			_controls.Movement.Use.canceled += _interactRay.SendRay;
			
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