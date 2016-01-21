using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	public Transform monitorMain; //MonitorMain is a gameobject within the cockpit-model

	TextMesh shieldText;
	TextMesh hullText;

	TextMesh missileCountText;

	GameObject shieldBar;
	GameObject hullBar;

	public int debugSetShields = 100;
	public int debugSetHull = 100;
	public int debugSetMissiles = 5;

	enum MissileTypes { CONCUSSION, HOMING, SPLIT };

	enum Meters { SHIELD, HEALTH };

	void Awake() {
		Transform UIMain = monitorMain.transform.Find("UIMain");

		shieldText = UIMain.Find("ShieldText").GetComponent<TextMesh>();
		hullText = UIMain.Find("HullText").GetComponent<TextMesh>();

		shieldBar = UIMain.Find("ShieldBar").gameObject;
		hullBar = UIMain.Find("HullBar").gameObject;

		Transform UIR1 = monitorMain.transform.Find("MonitorR1").transform.Find("UIR1");
		missileCountText = UIR1.transform.Find("MissileCountText").GetComponent<TextMesh>();
	}

	// Use this for initialization
	void Start() {
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
		if (shieldBar != null) {
			float scale = percent / 100;
			shieldBar.transform.localScale = new Vector3(1, scale, 1);
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

	public void SetMissileCount(int _count) {
		if (missileCountText != null) {
			missileCountText.text = "x"+_count;
		}
	}
		

		// Update is called once per frame
	void Update () {
		SetShields(debugSetShields);
		SetHull(debugSetHull);
		SetMissileCount(debugSetMissiles);
	}
}
