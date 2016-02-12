using UnityEngine;
using System.Collections.Generic;
//[RequireComponent(typeof(AudioSource))]

public class PlayerMovement : MonoBehaviour {
	Quaternion initialRot;
	
	public int forwardForce = 2;
	public int backwardForce = 2;
	public int leftForce = 2;
	public int rightForce = 2;
	public int upForce = 2;
	public int downForce = 2;
	
	public int forwardSpeed = 1;
	public int turnSpeed = 80;
	public static Vector3 velocity;
	public int rotateSpeed = 80;
	public int maxSpeed = 6;
	public int maxSpeedThrust = 10;
<<<<<<< HEAD
//	public AudioClip Afterburner;
=======
	
	//	Vector3 oldRotation;
	//	public Transform from;
	//	public Transform to;
	//	public float rotationSpeed = 0.1F;
	
>>>>>>> develop
	
	void Start() {
		initialRot = transform.rotation;
<<<<<<< HEAD
		GetComponent<Rigidbody>().freezeRotation = true;
	}
	
=======
		GetComponent<Rigidbody> ().freezeRotation = true;
		
		//StartCoroutine(turboBoostTimer());
		
	}
	
	IEnumerator turboBoostTimer(){ 
		
		StartCoroutine ("speedTurbo", 2.0F);
		yield return new WaitForSeconds(2);
		StopCoroutine ("speedTurbo");
		
	}
	
	IEnumerator speedTurbo()
	{
		
		while (true) {
			if (GetComponent<Rigidbody> ().velocity.magnitude > maxSpeedThrust) {
				GetComponent<Rigidbody> ().velocity = GetComponent<Rigidbody> ().velocity.normalized * maxSpeedThrust;
			}
			GetComponent<Rigidbody> ().AddRelativeForce (Vector3.forward * forwardForce);
			yield return null;
		}
	}
	
	void Update() {
		
	}
>>>>>>> develop
	void FixedUpdate() {
	/*	velocity = GetComponent<Rigidbody>().velocity;
		//Debug.Log(Input.GetAxis("Mouse X") * -5);
		if (Input.GetAxis("Mouse X") != 0) {
			transform.Rotate(0, 0, Input.GetAxis("Mouse X") * -5, Space.Self);
		}
		
		//Debug.Log(Input.GetAxis("Mouse Y") * -5);
		if (Input.GetAxis("Mouse Y") != 0) {
			transform.Rotate(Input.GetAxis("Mouse Y") * -5, 0, 0);
		}
*/		
		if (Input.GetKey (KeyCode.W)) {
<<<<<<< HEAD
			if(GetComponent<Rigidbody>().velocity.magnitude > maxSpeed)
=======
			
			if(GetComponent<Rigidbody> ().velocity.magnitude > maxSpeed)
>>>>>>> develop
			{
				GetComponent<Rigidbody> ().velocity = GetComponent<Rigidbody> ().velocity.normalized * maxSpeed;
			}
			GetComponent<Rigidbody> ().AddRelativeForce (Vector3.forward * forwardForce);
		}
		
		if (Input.GetKey(KeyCode.S)) {
<<<<<<< HEAD
			this.GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * 2);	
=======
			if(GetComponent<Rigidbody> ().velocity.magnitude > maxSpeed)
			{
				GetComponent<Rigidbody> ().velocity = GetComponent<Rigidbody> ().velocity.normalized * maxSpeed;
			}
			this.GetComponent<Rigidbody> ().AddRelativeForce(Vector3.back * backwardForce);	
>>>>>>> develop
		}
		
		if (Input.GetKey(KeyCode.A)) {
			transform.Rotate(Vector3.down, turnSpeed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.D)) {
			transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
		}
		
<<<<<<< HEAD
		if (Input.GetKey(KeyCode.Q)) {
			GetComponent<Rigidbody> ().AddRelativeForce(Vector3.left * 3);
		}
		
		if (Input.GetKey(KeyCode.E)) {
			GetComponent<Rigidbody> ().AddRelativeForce(Vector3.right * 3);
=======
		if (Input.GetKey(KeyCode.A)) {
			if(GetComponent<Rigidbody> ().velocity.magnitude > maxSpeed)
			{
				GetComponent<Rigidbody> ().velocity = GetComponent<Rigidbody> ().velocity.normalized * maxSpeed;
			}
			GetComponent<Rigidbody> ().AddRelativeForce(Vector3.left * leftForce);
		}
		
		if (Input.GetKey(KeyCode.D)) {
			if(GetComponent<Rigidbody> ().velocity.magnitude > maxSpeed)
			{
				GetComponent<Rigidbody> ().velocity = GetComponent<Rigidbody> ().velocity.normalized * maxSpeed;
			}
			GetComponent<Rigidbody> ().AddRelativeForce(Vector3.right * rightForce);
>>>>>>> develop
		}
		if (Input.GetKey (KeyCode.Z)) {
			transform.Rotate(0, 0, turnSpeed*Time.deltaTime, Space.Self);
		}
		
<<<<<<< HEAD
=======
		if (Input.GetKey (KeyCode.X)) {
			transform.Rotate(0, 0, turnSpeed * Time.deltaTime, Space.Self);
		}
		
>>>>>>> develop
		if (Input.GetKey (KeyCode.C)) {
			transform.Rotate(0, 0, -turnSpeed*Time.deltaTime, Space.Self);
		}
		
<<<<<<< HEAD
		if (Input.GetKey (KeyCode.Space)) {
			GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 0.98f;
			
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero * 0.95f;
		}

		if (Input.GetKey (KeyCode.X)) {

		//	AudioSource audio = GetComponent<AudioSource>();
		//	audio.Play();

			if(GetComponent<Rigidbody>().velocity.magnitude > maxSpeedThrust)
			{
				GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxSpeedThrust;
			}
			GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 1.15f;
		}
//		if (Input.GetKeyUp(KeyCode.X)) {
//			AudioSource audio = GetComponent<AudioSource>();
//			audio.Stop();
//		}
	
	}	
}

=======
		if (Input.GetKey (KeyCode.V)) {		
			transform.Rotate(Vector3.left, turnSpeed * Time.deltaTime);
			//transform.Rotate(0, 0, -turnSpeed * Time.deltaTime, Space.Self);
		}
		
		if (Input.GetKey(KeyCode.R)) {
			if(GetComponent<Rigidbody> ().velocity.magnitude > maxSpeed)
			{
				GetComponent<Rigidbody> ().velocity = GetComponent<Rigidbody> ().velocity.normalized * maxSpeed;
			}
			GetComponent<Rigidbody> ().AddRelativeForce(Vector3.up * upForce);
		}
		
		if (Input.GetKey(KeyCode.F)) {
			if(GetComponent<Rigidbody> ().velocity.magnitude > maxSpeed)
			{
				GetComponent<Rigidbody> ().velocity = GetComponent<Rigidbody> ().velocity.normalized * maxSpeed;
			}
			GetComponent<Rigidbody> ().AddRelativeForce(Vector3.down * downForce);
		}
		if (Input.GetKey (KeyCode.Space)) {
			
			StartCoroutine(turboBoostTimer());	
			
		}
		
		if (Input.anyKey == false) {
			GetComponent<Rigidbody> ().velocity = GetComponent<Rigidbody> ().velocity * 0.95f;
			
			GetComponent<Rigidbody> ().angularVelocity = Vector3.zero * 0.95f;
			
			//			GetComponent<Rigidbody> ().transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.time * rotationSpeed);
			//	rb.transform.rotation = Vector3.RotateTowards(0, 0, 0);
			
		}
		
	}	
	//	}
}
>>>>>>> develop
