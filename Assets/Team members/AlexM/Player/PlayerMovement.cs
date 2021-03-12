using System;
using System.Collections;
using System.Collections.Generic;
using AlexM;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : PlayerBase
{
	public Inputs controls;
	public float    maxSpeed = 100f;
	public float    jumpForce = 70f;
	

	

	[SerializeField, Header("= Debug =")]
	private float _speed;

	private float originalSpeed;
	[SerializeField]
	private float groundAngle, groundAngleOffset;
	private void Awake()
	{
		GetReferences();
		originalSpeed = maxSpeed;
	}

	private void OnEnable()
	{
		controls = new Inputs();
		controls.Movement.Enable();
		controls.Movement.Move.performed += ctx => _movementInput = controls.Movement.Move.ReadValue<Vector2>();
	}

	private void OnDisable()
	{
		controls.Movement.Disable();
	}

	void GetReferences()
	{
		_rb           = GetComponent<Rigidbody>();
		_inputManager = GetComponent<InputManager>();
		_slip         = Resources.Load<PhysicMaterial>("Materials/Slip");
		_grip         = Resources.Load<PhysicMaterial>("Materials/Grip");
		_gripStub     = GetComponentInChildren<SphereCollider>();
	}
	private Vector3 GetForward()
	{
		// RaycastHit hit;
		// bool ray = Physics.Raycast(_gripStub.transform.position, -transform.up, out hit, 0.25f);
		// return _fwdDirection += (transform.forward + hit.normal);
		var T = transform;
		_fwdDirection = T.forward;
		if (_isGrounded)
		{
			_fwdDirection = Vector3.Cross(_groundHitInfo.normal, -T.right);
		}
		
		return _fwdDirection;
	}


	private Vector3 GetRight()
	{
		return _rightDirection = transform.right;
	}

	private void GetGroundAngle()
	{
		if (_isGrounded)
		{
			_groundAngle = Vector3.Angle(transform.forward, _groundHitInfo.normal);
		}
		else
		{
			return;
		}

		groundAngle = _groundAngle;
		_groundAngleOffset = groundAngle - 90f;
		groundAngleOffset = _groundAngleOffset;
	}

	private void CheckGround()
	{
		var rayDown = Physics.Raycast(_gripStub.transform.position, Vector3.down, out _groundHitInfo, 0.35f);

		_isGrounded = rayDown;
	}

	private float GetSpeed()
	{
		_speed = _rb.velocity.magnitude;

		return _speed;
	}

	public void MovementInput(InputAction.CallbackContext obj)
	{
		if (obj.performed)
		{
			_gripStub.material = _slip;			
		}

		_inputManager.moveDirection = obj.ReadValue<Vector2>();
		if (_groundAngleOffset > 0)
		{
			maxSpeed = (maxSpeed + _groundAngleOffset / 10f);
		}
		
		if (obj.canceled)
		{
			_gripStub.material = _grip;
			
			maxSpeed = originalSpeed;
		}
	}

	public void Sprint(InputAction.CallbackContext obj)
	{
		if (isLocalPlayer)
		{
			if (obj.performed)
			{
				CmdSprint(true);
			}

			if (obj.canceled)
			{
				CmdSprint(false);
			}
		}
	}

	[Command]
	public void CmdSprint(bool status)
	{
		RpcSprint(status);
	}

	[ClientRpc]
	public void RpcSprint(bool status)
	{
		_isSprinting = status;
	}

	public void Crouch(InputAction.CallbackContext obj)
	{
		//This needs to be improved. gabrage rn. Need sleep.
		var T = transform;

		if (obj.performed)
		{
			T.Translate(Vector3.down, Space.Self);
			T.localScale -= new Vector3(0, 0.5f, 0);
		}

		if (obj.canceled)
		{
			T.localScale += new Vector3(0, 0.5f, 0);
		}
	}

	public void JumpInput(InputAction.CallbackContext obj)
	{
		if (isLocalPlayer)
		{
			if (obj.performed)
			{
				//Debug.LogWarning("JumpInput Performed.");
				if (_isGrounded)
				{
					CmdJump();
				}
			}

			if (obj.canceled)
			{
				//Debug.LogWarning("JumpInput Cancelled.");
			}
		}
	}

	[Command]
	public void CmdJump()
	{
		RpcJump();
	}

	[ClientRpc]
	public void RpcJump()
	{
		//Debug.Log("Jumping");
		_rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
	}

	private void Update()
	{
		if (isLocalPlayer)
		{
			_movement = (_inputManager.moveDirection.y * _fwdDirection) + (_inputManager.moveDirection.x * _rightDirection);
			CmdMovementInput(_movement);
		}
	}

	[Command]
	public void CmdMovementInput(Vector3 movement)
	{
		_movement = movement;
	}
	
	private void ApplyMovement()
	{
		if (isLocalPlayer)
		{
			if (_isSprinting)
			{
				if (GetSpeed() < 25)
				{
					_rb.AddForce(_movement.normalized * ((maxSpeed * 2) * Time.fixedDeltaTime),
						ForceMode.VelocityChange);
				}
			}
			else
			{
				if (GetSpeed() < 10)
				{
					_rb.AddForce(_movement.normalized * ((maxSpeed / 2) * Time.fixedDeltaTime),
						ForceMode.VelocityChange);
				}
			}
		}
	}

	private void FixedUpdate()
	{
		ApplyMovement();
		GetForward();
		GetRight();
		CheckGround();
		GetGroundAngle();
	}

#region Examples

	/// <summary>
	/// INPUT happens LOCALLY
	/// >>sends COMMAND to SERVER
	/// >>>SERVER RPC to all CLIENTS
	/// </summary>

	private bool examples;
#endregion
}