using UnityEngine;

public class SpawnRabbit : MonoBehaviour
{
    [SerializeField]
    private GameObject[] rabbit;
    [SerializeField] 
    private Animator[] animator;

    private GameObject currentRabbit;
    private Animator currentAnimator;

    private void Awake()
    {
        for (int i = 0; i < rabbit.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("SelectedRabbit"))
            {
                rabbit[i].SetActive(true);
                currentRabbit = rabbit[i];
                currentAnimator = animator[i];
            }
            else
            {
                rabbit[i].SetActive(false);
            }
        }
    }

    public Animator GetRabbitAnimator()
    {
        return currentAnimator;
    }

    public GameObject GetRabbit()
    {
        return currentRabbit;
    }
}
