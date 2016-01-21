using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	public Transform monitorMain; //MonitorMain is a gameobject within the cockpit-model
	TextMesh shieldText;
	TextMesh hullText;

	GameObject shieldBar;
	GameObject hullBar;

	public int debugSetShields = 100;
	public int debugSetHull = 100;

	enum Meters { SHIELD, HEALTH};

	void Awake() {
		Transform HUDtexts1 = monitorMain.transform.Find("HUDtexts1");

		shieldText = HUDtexts1.Find("ShieldText").GetComponent<TextMesh>();
		hullText = HUDtexts1.Find("HullText").GetComponent<TextMesh>();

		shieldBar = monitorMain.Find("ShieldBar").gameObject;
		hullBar = monitorMain.Find("HullBar").gameObject;
	}

	// Use this for initialization
	void Start () {
		SetShields(100);
		SetHull(100);
	}

	public void SetShields(float _percentage) {

		float percent = _percentage;
		if (_percentage < 0) {
			percent = 0;
		}

		if (shieldText != null) {
			shieldText.text = "SHIELD:" + percent + "%";
		}
		if (shieldBar!=null) {
			float scale = percent / 100;
			shieldBar.transform.localScale = new Vector3(1, scale,1);
		}
	}

	public void SetHull(float _percentage) {

		float percent = _percentage;
		if (_percentage < 0) {
			percent = 0;
		}

		if (hullText != null) {
			hullText.text = "HULL:" + percent + "%";
		}
		if (hullBar != null) {
			float scale = percent / 100;
			hullBar.transform.localScale = new Vector3(1, scale, 1);
		}
	}


	// Update is called once per frame
	void Update () {
		SetShields(debugSetShields);
		SetHull(debugSetHull);
	}
}
