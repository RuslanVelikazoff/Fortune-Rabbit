using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private GameObject winPanel;
    [SerializeField] 
    private GameObject losePanel;
    [SerializeField]
    private GameObject pausePanel;

    public void PauseGame()
    {
        pausePanel.SetActive(true);
    }
}
