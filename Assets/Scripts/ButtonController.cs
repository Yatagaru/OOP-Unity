using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ExitGuide()
    {
        #if UNITY_EDITOR
             EditorApplication.ExitPlaymode();
        #else
            Application.Exit();
        #endif
    }
}
