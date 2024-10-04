using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField]
    private Button resumeButton;
    [SerializeField] 
    private Button restartButton;
    [SerializeField] 
    private Button backToMenuButton;

    private void Awake()
    {
        PauseButtonClickAction();
    }

    private void PauseButtonClickAction()
    {
        if (resumeButton != null)
        {
            resumeButton.onClick.AddListener(() =>
            {
                Time.timeScale = 1;
                this.gameObject.SetActive(false);
            });
        }

        if (restartButton != null)
        {
            restartButton.onClick.AddListener(() =>
            {
                Loader.Load(Loader.targetScene);
            });
        }

        if (backToMenuButton != null)
        {
            backToMenuButton.onClick.AddListener(() =>
            {
                Loader.Load("Menu");
            });
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
}
