using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {

	Vector3 realPosition = Vector3.zero;
	Quaternion realRotation = Quaternion.identity;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*if (photonView.isMine) {
		} 
		else {
			transform.position = Vector3.Lerp(transform.position, realPosition, 0.2f);
			transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, 0.2f);
		}*/

	}



	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {

		if(stream.isWriting){
			//our player

			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);

		}
		else{
			//someones player
			transform.position = (Vector3)stream.ReceiveNext();
			transform.rotation = (Quaternion)stream.ReceiveNext();

		}
	}
	
}
