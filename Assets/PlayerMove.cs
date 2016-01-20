using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log(Input.GetAxis ("Mouse X")*-5);
		if(Input.GetAxis("Mouse X") != 0) {
			transform.Rotate(0, 0 , Input.GetAxis ("Mouse X")*-5, Space.Self);
		}
		
		Debug.Log(Input.GetAxis ("Mouse Y")*-5);
		if(Input.GetAxis("Mouse Y") != 0) {
			transform.Rotate (Input.GetAxis ("Mouse Y")*-5, 0 , 0);
		}

	}
}
