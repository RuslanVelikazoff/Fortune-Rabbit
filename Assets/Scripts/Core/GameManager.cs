using Dan.Main;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] 
    private GameObject winPanel;
    [SerializeField] 
    private GameObject losePanel;
    [SerializeField]
    private GameObject pausePanel;

    [SerializeField] private int currentLevel;
    private int maxLevel = 9;

    private string publicLeaderboardKey = "3815d256db4be05bdbf4bbb9bfc9b0cc42e924066a40dfc90bb0d001eae23af7";

    private void Awake()
    {
        Instance = this;
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
    }

    public void WinGame()
    {
        AudioManager.Instance.Play("Win");
        winPanel.SetActive(true);
        LevelData.Instance.CompleteLevel(currentLevel - 1);
        CurencyData.Instance.PlusClover(StatsPanel.Instance.GetCloverAmount());
        CurencyData.Instance.PlusCarrot(StatsPanel.Instance.GetCarrotAmount());
        UpdateLeaderboard();
    }

    public void LoseGame()
    {
        AudioManager.Instance.Play("Lose");
        losePanel.SetActive(true);
        CurencyData.Instance.PlusClover(StatsPanel.Instance.GetCloverAmount());
    }

    public void NextLevel()
    {
        if (currentLevel != maxLevel)
        {
            Loader.Load("Level" + (currentLevel + 1));
        }
        else
        {
            Loader.Load("Menu");
        }
    }

    private void UpdateLeaderboard()
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, 
            PlayerPrefs.GetString("Username"), CurencyData.Instance.GetCarrotAmount());
    }
}
