using UnityEngine;

public class CurencyData : MonoBehaviour
{
    private const string SaveKey = "DataCurency";
    
    private int _carrot;
    private int _clover;

    public static CurencyData Instance;
    
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

        _carrot = data.carrot;
        _clover = data.clover;
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
            carrot = _carrot,
            clover = _clover
        };

        return data;
    }

    public int GetCloverAmount()
    {
        return _clover;
    }

    public void PlusClover(int amount)
    {
        _clover += amount;
        Save();
    }

    public void MinusClover(int amount)
    {
        _clover -= amount;
        Save();
    }

    public int GetCarrotAmount()
    {
        return _carrot;
    }

    public void PlusCarrot(int amount)
    {
        _carrot += amount;
        Save();
    }

    public void MinusCarrot(int amount)
    {
        _carrot -= amount;
        Save();
    }
}
