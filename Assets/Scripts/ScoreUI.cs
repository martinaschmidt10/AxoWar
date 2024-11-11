using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text Player1ScoreText;
    [SerializeField] private TMP_Text Player2ScoreText;

    void Update()
    {
        Player1ScoreText.text = GameManager.instance.player1Points.ToString();
        Player2ScoreText.text = GameManager.instance.player2Points.ToString();
    }
}
