using UnityEngine;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour
{
    [SerializeField] 
    private Button backButton;
    [SerializeField] 
    private GameObject mainPanel;

    [Space(13)]
    
    [SerializeField] 
    private Button[] levelButton;
    [SerializeField] 
    private GameObject[] lockLevel;

    private void OnEnable()
    {
        SetLockGameObjects();
        BackButtonAction();

        for (int i = 0; i < levelButton.Length; i++)
        {
            LevelButtonClickAction(i);
        }
    }

    private void LevelButtonClickAction(int index)
    {
        if (LevelData.Instance.IsLevelUnlock(index))
        {
            levelButton[index].onClick.AddListener(() =>
            {
                Loader.Load("Level" + (index + 1));
            });
        }
    }

    private void SetLockGameObjects()
    {
        for (int i = 0; i < lockLevel.Length; i++)
        {
            if (LevelData.Instance.IsLevelUnlock(i))
            {
                lockLevel[i].SetActive(false);
            }
            else
            {
                lockLevel[i].SetActive(true);
            }
        }
    }

    private void BackButtonAction()
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
}
