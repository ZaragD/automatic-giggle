using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour {


	public float speed;
	public float gravity;
	public LayerMask ground;
	public Transform feet;

	private Vector3 fallingVelocity;
	private Vector3 direction;
	private Vector3 walkingVelocity;
	private CharacterController controller;


	// Use this for initialization
	void Start () {
		direction = Vector3.zero;
		controller = GetComponent<CharacterController> ();
		fallingVelocity = Vector3.zero;

	}
		
	// Update is called once per frame
	void Update () {
		direction.x = Input.GetAxis ("Horizontal");
		direction.z = Input.GetAxis ("Vertical");
		direction = direction.normalized;
	
		//Makes forward look at mouse
		Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
		//Angle between mouse and this object
		float angle = AngleBetweenPoints(transform.position, mouseWorldPosition);
		transform.rotation =  Quaternion.Euler (new Vector3(0f,-angle+90,0f));

		walkingVelocity = direction * speed;
		controller.Move (walkingVelocity * Time.deltaTime);

		bool isGrounded = Physics.CheckSphere(feet.position, 0.1f, ground, QueryTriggerInteraction.Ignore);
		if(isGrounded)
			fallingVelocity.y = 0f;
		else
			fallingVelocity.y -= gravity * Time.deltaTime;
		//if(Input.GetButtonDown("Jump") && isGrounded) {
			//audio.Play();
			//fallingVelocity.y = Mathf.Sqrt(gravity * jumpHeight);
		//}
		controller.Move(fallingVelocity * Time.deltaTime);

	
	}

	float AngleBetweenPoints(Vector3 a, Vector3 b) 
		{
			return Mathf.Atan2(a.z - b.z, a.x - b.x) * Mathf.Rad2Deg;
		}
}
