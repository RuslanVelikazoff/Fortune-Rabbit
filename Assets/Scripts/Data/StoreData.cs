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
        PlayerPrefs.GetInt("SelectedRabbit", 0);
        PlayerPrefs.GetInt("PurchasedMegaJump", 0);
        PlayerPrefs.GetInt("PurchasedProtective", 0);
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
        _selectedRabbit = data.selectedRabbit;
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
            purchasedRabbit = _purchasedRabbit,
            selectedRabbit = _selectedRabbit
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

    public bool GetSelectedRabbit(int index)
    {
        return _selectedRabbit[index];
    }

    public void BuyMegaJump()
    {
        _purchasedMegaJump = true;
        PlayerPrefs.SetInt("PurchasedMegaJump", 1);
        Save();
    }

    public void BuyProtective()
    {
        _purchasedProtective = true;
        PlayerPrefs.SetInt("PurchasedProtective", 1);
        Save();
    }

    public void BuyRabbit(int index)
    {
        _purchasedRabbit[index] = true;
        SelectRabbit(index);
        Save();
    }

    public void SelectRabbit(int index)
    {
        for (int i = 0; i < _selectedRabbit.Length; i++)
        {
            if (i == index)
            {
                _selectedRabbit[i] = true;
                PlayerPrefs.SetInt("SelectedRabbit", i);
            }
            else
            {
                _selectedRabbit[i] = false;
            }
        }
        Save();
    }
}
