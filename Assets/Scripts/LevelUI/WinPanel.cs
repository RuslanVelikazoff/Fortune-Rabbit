using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] 
    private Button nextLevelButton;
    [SerializeField] 
    private Button replayButton;
    [SerializeField] 
    private Button menuButton;

    [Space(13)]
    
    [SerializeField]
    private TextMeshProUGUI carrotText;
    [SerializeField]
    private TextMeshProUGUI cloverText;

    private void OnEnable()
    {
        SetText();
    }

    private void Awake()
    {
        WinButtonClickAction();
    }

    private void WinButtonClickAction()
    {
        if (nextLevelButton != null)
        {
            nextLevelButton.onClick.AddListener(() =>
            {
                GameManager.Instance.NextLevel();
            });
        }

        if (replayButton != null)
        {
            replayButton.onClick.AddListener(() =>
            {
                Loader.Load(Loader.targetScene);
            });
        }

        if (menuButton != null)
        {
            menuButton.onClick.AddListener(() =>
            {
                Loader.Load("Menu");
            });
        }
    }

    private void SetText()
    {
        carrotText.text = StatsPanel.Instance.GetCarrotAmount().ToString();
        cloverText.text = StatsPanel.Instance.GetCloverAmount().ToString();
    }
}
