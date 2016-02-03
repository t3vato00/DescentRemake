using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class cutscene : MonoBehaviour {
    GameObject player;
    GameObject spotlight;
    GameObject skipText;
    public Camera cockpit;
    public Camera cockpitHUD;
    public Camera camera1;
    public Camera camera2;
    bool cutsceneFinished = false;
    IEnumerator routine;

	// Use this for initialization
	void Start () {
        routine = cutsceneCamera();
        skipText = GameObject.Find("SkipCutscene");
        player = GameObject.Find("Player");
        spotlight = GameObject.Find("Spotlight");
        StartCoroutine(routine);
	}

    void Update()
    {
        if(Input.GetKeyDown("space") && !cutsceneFinished)
        {
            StopCoroutine(routine);
            skipText.SetActive(false);
            player.GetComponent<Animator>().enabled = false;
            player.transform.position = new Vector3(-4.6f , -2.65f, 23.67f);
            player.transform.localEulerAngles = new Vector3(0, 133.6401f, 0);
            spotlight.SetActive(false);
            cockpitHUD.enabled = true;
            cockpit.enabled = true;
            camera1.enabled = false;
            camera2.enabled = false;
            cutsceneFinished = true;
        }
    }

    IEnumerator cutsceneCamera()
    {
        //Cutscene - part 1
        player.GetComponent<UIController>().enabled = false;
        cockpitHUD.enabled = false;
        cockpit.enabled = false;
        camera1.enabled = true;
        camera2.enabled = false;
        yield return new WaitForSeconds(6);
        print("stage 1");

        //Cutscene - part 2
        cockpit.enabled = false;
        camera1.enabled = false;
        camera2.enabled = true;
        yield return new WaitForSeconds(2);
        print("stage 2");

        //Cutscene - part 3
        spotlight.SetActive(false);
        cockpitHUD.enabled = true;
        cockpit.enabled = true;
        camera1.enabled = false;
        camera2.enabled = false;
        yield return new WaitForSeconds(8);
        player.GetComponent<UIController>().enabled = true;
        player.GetComponent<Animator>().enabled = false;
        print("stage 3");
    }


}
