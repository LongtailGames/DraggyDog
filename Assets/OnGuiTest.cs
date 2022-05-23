using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGuiTest : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUILayout.Button("PrintName"))
        {
            Debug.Log(name);
        }
    }
}
