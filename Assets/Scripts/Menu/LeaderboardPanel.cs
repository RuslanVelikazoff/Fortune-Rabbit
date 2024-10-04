using System.Collections.Generic;
using Dan.Main;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardPanel : MonoBehaviour
{
    [SerializeField] 
    private Button backButton;
    [SerializeField]
    private GameObject mainPanel;

    [Space(13)]
    
    [SerializeField]
    private List<TextMeshProUGUI> nameText;
    [SerializeField] 
    private List<TextMeshProUGUI> resultText;

    private string publicLeaderboardKey = "3815d256db4be05bdbf4bbb9bfc9b0cc42e924066a40dfc90bb0d001eae23af7";

    private void Awake()
    {
        LeaderboardButtonClickAction();
    }

    private void OnEnable()
    {
        GetLeaderboard();
    }

    private void LeaderboardButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
            });
        }
    }

    private void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) =>
        {
            int loopLenght = (msg.Length < nameText.Count) ? msg.Length : nameText.Count;

            for (int i = 0; i < loopLenght; i++)
            {
                nameText[i].text = msg[i].Username;
                resultText[i].text = msg[i].Score.ToString();
            }
        }));
    }
}
