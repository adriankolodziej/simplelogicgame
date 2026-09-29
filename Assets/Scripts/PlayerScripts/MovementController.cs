using Assets.Scripts.Mechanisms;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
	[SerializeField] private float movementSpeed;
	[SerializeField] private float jumpHeight;
	[SerializeField] private LayerMask groundLayer;
	[SerializeField] private Transform groundCheck;
	private CharacterController character;
	private float xMove;
	private float zMove;

	private Vector3 motion;
	private Vector3 jumpMotion;

	private float groundDistance = 0.4f;
	void Start()
	{
		character = FindObjectOfType(typeof(CharacterController)) as CharacterController;
	}

	void Update()
	{
		Move();
		Jump();
	}

	void Move()
	{
		xMove = Input.GetAxis("Horizontal");
		zMove = Input.GetAxis("Vertical");
		motion = transform.right * xMove + transform.forward * zMove;
		if (IsGrounded())
		{
			character.Move(motion * Time.deltaTime * movementSpeed);
		}
		else
			character.Move(motion * Time.deltaTime * movementSpeed * .3f);
	}

	void Jump()
	{
		if (Input.GetButtonDown("Jump") && IsGrounded())
		{
			jumpMotion.y = Mathf.Sqrt(jumpHeight * -2.0f * Physics.gravity.y);
		}
		jumpMotion.y += Physics.gravity.y * Time.deltaTime;
		character.Move(jumpMotion * Time.deltaTime);
	}

	bool IsGrounded()
	{
		return Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);
	}
}
