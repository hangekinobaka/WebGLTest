using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugText : MonoBehaviour
{
    public bool showDebug = false;

    string ratioText = "";

    public void onResize(string screenSize)
    {
        ratioText = screenSize;
    }

    private void OnGUI()
    {
        if (!showDebug) return;

        GUIStyle labelStyle = new GUIStyle();
        labelStyle.fontSize = 34;
        labelStyle.normal.textColor = Color.white;
        GUILayout.Label(ratioText, labelStyle);
    }
}
