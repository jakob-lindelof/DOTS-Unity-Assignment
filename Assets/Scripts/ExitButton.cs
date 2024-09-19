using UnityEngine;

public class ExitButton : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUILayout.Button("Close"))
        {
            Application.Quit();
        }
    }
}
