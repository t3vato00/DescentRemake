using UnityEngine;
using System.Collections;

public class TutorialMessage : MonoBehaviour {

    private Rect windowRect = new Rect(20, 200, 200, 200);

    void OnGUI()
    {
        windowRect = GUI.Window(0, windowRect, WindowFunction, "Tutorial Message");
    }

    void WindowFunction(int windowID)
    {
        GUI.Label(new Rect(20, 20, 100, 50), "Tutorial Message");

    }
}
