using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject options;

    public void ChangeScene(int scene)
    {
        GameManager.instance.ChangeScene(scene);
    }

    public void CloseOptions()
    {
        options.SetActive(false);
    }
    public void OpenOptions()
    {
        options.SetActive(true);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
