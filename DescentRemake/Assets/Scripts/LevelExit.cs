using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

    public string nextMap;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            SceneManager.LoadScene(nextMap);
        }
    }
}
