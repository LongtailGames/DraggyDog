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
