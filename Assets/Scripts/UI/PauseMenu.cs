using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenusUI;
    [SerializeField] private GameObject OptionsMenuUI;
    private bool isPaused = false;
    private bool OptionsMenu = false;

    void Start()
    {
        PauseMenusUI.SetActive(false);
        OptionsMenuUI.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PauseGame();
        }

    }

    public void ResumeGame()
    {

        isPaused = false;
        PauseMenusUI.SetActive(false);
        OptionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        FindAnyObjectByType<CursorManager>().SetMenuOpen(false);
    }

    private void PauseGame()
    {

        isPaused = true;
        Time.timeScale = 0f;
        PauseMenusUI.SetActive(true);
        FindAnyObjectByType<CursorManager>().SetMenuOpen(true);
    }

    public void Options()
    {
        isPaused = false;
        OptionsMenu = true;
        PauseMenusUI.SetActive(false);
        Time.timeScale = 0f;
        OptionsMenuUI.SetActive(true);
        FindAnyObjectByType<CursorManager>().SetMenuOpen(true);

    }


    public void ChangeScene(int scene)
    {
        GameManager.instance.RestartValues();
        SceneManager.LoadScene(scene);
    }


    public void QuitGame()
    {
        // Si estás en el editor de Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


}