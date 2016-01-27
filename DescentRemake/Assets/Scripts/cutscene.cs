using UnityEngine;
using System.Collections;

public class cutscene : MonoBehaviour {
    GameObject player;
    public Camera cockpit;
    public Camera cockpitHUD;
    public Camera camera1;
    public Camera camera2;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        StartCoroutine(cutsceneCamera());
	}

    IEnumerator cutsceneCamera()
    {
        player.GetComponent<UIController>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        cockpitHUD.enabled = false;
        cockpit.enabled = false;
        camera1.enabled = true;
        camera2.enabled = false;
        yield return new WaitForSeconds(6);

        cockpit.enabled = false;
        camera1.enabled = false;
        camera2.enabled = true;
        yield return new WaitForSeconds(2);

        cockpitHUD.enabled = true;
        cockpit.enabled = true;
        camera1.enabled = false;
        camera2.enabled = false;
        yield return new WaitForSeconds(8);
        player.GetComponent<UIController>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
    }
}
