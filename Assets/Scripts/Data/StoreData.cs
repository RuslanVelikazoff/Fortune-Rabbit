using UnityEngine;

public class StoreData : MonoBehaviour
{
    private const string SaveKey = "DataStore";
    
    private bool _purchasedMegaJump;
    private bool _purchasedProtective;

    private bool[] _purchasedRabbit;
    private bool[] _selectedRabbit;

    public static StoreData Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    
    private void Start()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
    }

    private void OnDisable()
    {
        Save();
    }

    private void Load()
    {
        var data = SaveManager.Load<GameData>(SaveKey);

        _purchasedMegaJump = data.purchasedMegaJump;
        _purchasedProtective = data.purchasedProtective;
        _purchasedRabbit = data.purchasedRabbit;
    }

    private void Save()
    {
        SaveManager.Save(SaveKey,GetSaveSnapshot());
        PlayerPrefs.Save();
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            purchasedMegaJump = _purchasedMegaJump,
            purchasedProtective = _purchasedProtective,
            purchasedRabbit = _purchasedRabbit
        };

        return data;
    }

    public bool GetPurchasedMegaJump()
    {
        return _purchasedMegaJump;
    }

    public bool GetPurchasedProtective()
    {
        return _purchasedProtective;
    }

    public bool GetPurchasedRabbit(int index)
    {
        return _purchasedRabbit[index];
    }

    public void BuyMegaJump()
    {
        _purchasedMegaJump = true;
    }

    public void BuyProtective()
    {
        _purchasedProtective = true;
    }
}
