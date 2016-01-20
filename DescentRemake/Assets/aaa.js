#pragma strict

 
var initialRot : Quaternion;
 
var forwardSpeed = 1;
var turnSpeed = 80;

 	
function Start () {    
    initialRot = transform.rotation;
}
 
function Update() {
 
   Debug.Log(Input.GetAxis ("Mouse X")*-5);
   if(Input.GetAxis("Mouse X") != 0) {
        transform.Rotate(0, 0 , Input.GetAxis ("Mouse X")*-5, Space.Self);
   }
   
    Debug.Log(Input.GetAxis ("Mouse Y")*-5);
    if(Input.GetAxis("Mouse Y") != 0) {
        transform.Rotate (Input.GetAxis ("Mouse Y")*-5, 0 , 0);
    }
 
if (Input.GetKey (KeyCode.W)) {
	//transform.position += transform.forward * forwardSpeed * Time.deltaTime;
	 GetComponent.<Rigidbody>().AddRelativeForce (Vector3.forward * 5);
	
}
 
if (Input.GetKey (KeyCode.S)) {
	//transform.position -= transform.forward * riseSpeed * Time.deltaTime;
	GetComponent.<Rigidbody>().AddRelativeForce (Vector3.back * 5);
	
}

if (Input.GetKey (KeyCode.A)) {
	transform.Rotate(Vector3.down, turnSpeed * Time.deltaTime);
} 


if (Input.GetKey (KeyCode.D)) {
	transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
}

if (Input.GetKey (KeyCode.Q)) {
	GetComponent.<Rigidbody>().AddRelativeForce (Vector3.left * 3);
}

if (Input.GetKey (KeyCode.E)) {
	GetComponent.<Rigidbody>().AddRelativeForce (Vector3.right * 3);
}
   }
   
   
   
