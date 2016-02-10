using UnityEngine;
using System.Collections;

public class cutscene : MonoBehaviour {
    GameObject player;
    GameObject spotlight;
    public Camera cockpit;
    public Camera cockpitHUD;
    public Camera camera1;
    public Camera camera2;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        spotlight = GameObject.Find("Spotlight");
        StartCoroutine(cutsceneCamera());
	}

    IEnumerator cutsceneCamera()
    {
        player.GetComponent<UIController>().enabled = false;
        cockpitHUD.enabled = false;
        cockpit.enabled = false;
        camera1.enabled = true;
        camera2.enabled = false;
        yield return new WaitForSeconds(6);

        cockpit.enabled = false;
        camera1.enabled = false;
        camera2.enabled = true;
        yield return new WaitForSeconds(2);

        spotlight.SetActive(false);
        cockpitHUD.enabled = true;
        cockpit.enabled = true;
        camera1.enabled = false;
        camera2.enabled = false;
        yield return new WaitForSeconds(8);
        player.GetComponent<UIController>().enabled = true;
        player.GetComponent<Animator>().enabled = false;
    }

}
