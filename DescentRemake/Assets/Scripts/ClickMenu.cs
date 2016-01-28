using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClickMenu : MonoBehaviour {

	// Use this for initialization
	public void ClickButton (string level) {
	    SceneManager.LoadScene(level);
	}

    public void QuitApplication()
    {
        Application.Quit();
    }
}
