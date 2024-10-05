using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class StatsPanel : MonoBehaviour
{
    public static StatsPanel Instance { get; private set; }

    [SerializeField]
    private TextMeshProUGUI carrotText;
    [SerializeField]
    private TextMeshProUGUI cloverText;

    private int carrot;
    private int clover;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetStatsText();
    }

    private void SetStatsText()
    {
        carrotText.text = carrot.ToString();
        cloverText.text = clover.ToString();
    }

    public void CollectCarrot()
    {
        AudioManager.Instance.Play("Collect");
        int amount = Random.Range(1, 10);
        carrot += amount;
        SetStatsText();
        Debug.Log(carrot);
    }

    public void CollectClover()
    {
        AudioManager.Instance.Play("Collect");
        clover++;
        SetStatsText();
    }

    public int GetCloverAmount()
    {
        return clover;
    }

    public int GetCarrotAmount()
    {
        return carrot;
    }
}
