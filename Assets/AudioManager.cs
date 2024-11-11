using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource audioSource;
    private string[] gameScenes = { "1v1", "1vAi", "Platformer" }; //en estas escenas se apaga este source ji

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        if (IsGameScene(scene.name))
        {
            audioSource.Stop();
        }
        else if (!audioSource.isPlaying) 
        {
            audioSource.Play();
        }
    }

    private bool IsGameScene(string sceneName)
    {
        foreach (var gameScene in gameScenes)
        {
            if (sceneName == gameScene)
                return true;
        }
        return false;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
