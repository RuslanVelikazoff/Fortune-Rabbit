using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button leaderboardsButton;
    [SerializeField]
    private Button shopButton;
    [SerializeField]
    private Button upgradeButton;
    [SerializeField]
    private Button settingsButton;
    [SerializeField] 
    private Button quitButton;

    [Space(13)]
    
    [SerializeField] 
    private GameObject playPanel;
    [SerializeField] 
    private GameObject leaderboardsPanel;
    [SerializeField] 
    private GameObject shopPanel;
    [SerializeField] 
    private GameObject upgradesPanel;
    [SerializeField] 
    private GameObject settingsPanel;

    private void Awake()
    {
        MainButtonClickAction();
    }

    private void MainButtonClickAction()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                playPanel.SetActive(true);
            });
        }

        if (leaderboardsButton != null)
        {
            leaderboardsButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                leaderboardsPanel.SetActive(true);
            });
        }

        if (shopButton != null)
        {
            shopButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                shopPanel.SetActive(true);
            });
        }

        if (upgradeButton != null)
        {
            upgradeButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                upgradesPanel.SetActive(true);
            });
        }

        if (settingsButton != null)
        {
            settingsButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                settingsPanel.SetActive(true);
            });
        }

        if (quitButton != null)
        {
            quitButton.onClick.AddListener(() =>
            {
                Application.Quit();
            });
        }
    }
}
