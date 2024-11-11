using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] public GameObject OptionsMenu;

    public int player1Points;
    public int player2Points;

    private PlayerMemento player1InitialMemento;
    private PlayerMemento player2InitialMemento;

    public PlayerDataHandler player1DataHandler;
    public PlayerDataHandler player2DataHandler;

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
        }
    }

    private void Start()
    {
        player1InitialMemento = player1DataHandler.CreateMemento();
        player2InitialMemento = player2DataHandler.CreateMemento();
    }

    private void Update()
    {
        PlayerWin();
    }

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void PlayerWin()
    {
        if (player1Points >= 10)
        {
            RestartValues();
            ChangeScene(8);
        }
        else if (player2Points >= 10)
        {
            RestartValues();
            ChangeScene(9);
        }
    }

    public void RestartValues()
    {

        player1DataHandler.RestoreMemento(player1InitialMemento);
        player2DataHandler.RestoreMemento(player2InitialMemento);

        FindAnyObjectByType<CursorManager>().SetMenuOpen(true);

    }

    public void OptionsActive()
    {
        OptionsMenu.SetActive(true);
    }
    public void OptionsDisable()
    {
        OptionsMenu.SetActive(false);
    }
}


