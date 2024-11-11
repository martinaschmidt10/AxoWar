using UnityEngine;
using UnityEngine.UI;

public class SelectionMenu : MonoBehaviour
{
    public Button modo1Button;
    public Button modo2Button;

    private void Start()
    {
       
        modo1Button.onClick.AddListener(() => ChangeToMode(2));
        modo2Button.onClick.AddListener(() => ChangeToMode(3));
    }

    private void ChangeToMode(int mode)
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ChangeScene(mode);
        }
        else
        {
            Debug.LogWarning("no anda");
        }
    }
}
