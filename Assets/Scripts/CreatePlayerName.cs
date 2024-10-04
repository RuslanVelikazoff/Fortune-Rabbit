using UnityEngine;

public class CreatePlayerName : MonoBehaviour
{
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Username"))
        {
            string username = "Player" + Random.Range(0, 999);
            
            PlayerPrefs.SetString("Username", username);
        }
    }
}
