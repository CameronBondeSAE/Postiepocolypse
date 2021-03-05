using System;
using System.Collections;
using System.Collections.Generic;
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

	public void InputValue(InputAction.CallbackContext obj)
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
		if (obj.performed)
		{
			_isSprinting = true;
		}

		if (obj.canceled)
		{
			_isSprinting = false;
		}
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

	public void Jump(InputAction.CallbackContext obj)
	{
		if (obj.performed)
		{
			//Debug.LogWarning("Jump Performed.");
			if (_isGrounded)
			{
				//Debug.Log("Jumping");
				_rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
			}
		}

		if (obj.canceled)
		{
			//Debug.LogWarning("Jump Cancelled.");
		}
	}

	private void ApplyMovement()
	{
		_movement = (_inputManager.moveDirection.y * _fwdDirection) + (_inputManager.moveDirection.x * _rightDirection);
		//if (_isGrounded)
		{
			// if (_groundAngleOffset > 0)
			// {
			// 	maxSpeed = (maxSpeed + _groundAngleOffset / 50f);
			// }
			// else if (_groundAngleOffset <= 0)
			// {
			// 	maxSpeed = originalSpeed;
			// }

			if (_isSprinting)
			{
				if (GetSpeed() < 25)
				{
					_rb.AddForce(_movement.normalized * ((maxSpeed * 2) * Time.fixedDeltaTime),
						ForceMode.VelocityChange);
					//_rb.velocity = _movement * maxSpeed;
				}
			}
			else
			{
				if (GetSpeed() < 10)
				{
					_rb.AddForce(_movement.normalized * ((maxSpeed / 2) * Time.fixedDeltaTime),
						ForceMode.VelocityChange);
					//_rb.velocity = (_movement * maxSpeed) / 2;
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
}