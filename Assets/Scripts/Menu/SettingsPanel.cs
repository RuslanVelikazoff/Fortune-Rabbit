using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField]
    private Button backButton;
    [SerializeField] 
    private Button saveButton;
    [SerializeField]
    private GameObject mainPanel;

    [Space(13)]
    
    [SerializeField]
    private Slider musicSlider;
    [SerializeField] 
    private Slider soundSlider;
    [SerializeField]
    private Slider sensitivitySlider;

    [Space(13)]
    
    [SerializeField] 
    private TMP_Dropdown graphicsDropDown;

    private float musicVolume;
    private float soundVolume;
    private float sensitivityValue;
    private int selectedGraphicIndex;

    private const string PLAYER_PREFS_SENSITIVITY_VOLUME = "SensitivityVolume";
    private const string PLAYER_PREFS_GRAPHIC_INDEX = "GraphicIndex";

    private void Awake()
    {
        SettingsButtonClickAction();
    }

    private void OnEnable()
    {
        SetSettingsValue();
    }

    public void MusicVolumeSlider()
    {
        AudioManager.Instance.SetMusicVolume(musicSlider.value);
    }

    public void SoundVolumeSlider()
    {
        AudioManager.Instance.SetSoundVolume(soundSlider.value);
    }

    private void SettingsButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
                ResetSettings();
            });
        }

        if (saveButton != null)
        {
            saveButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
                SaveSettings();
            });
        }
    }

    private void SetSettingsValue()
    {
        musicVolume = AudioManager.Instance.GetMusicVolume();
        soundVolume = AudioManager.Instance.GetSoundVolume();
        sensitivityValue = PlayerPrefs.GetFloat(PLAYER_PREFS_SENSITIVITY_VOLUME, 1f);

        selectedGraphicIndex = PlayerPrefs.GetInt(PLAYER_PREFS_GRAPHIC_INDEX, 0);

        musicSlider.value = musicVolume;
        soundSlider.value = soundVolume;
        sensitivitySlider.value = sensitivityValue;

        graphicsDropDown.value = selectedGraphicIndex;
    }

    private void SaveSettings()
    {
        AudioManager.Instance.SetMusicVolume(musicSlider.value);
        AudioManager.Instance.SetSoundVolume(soundSlider.value);
        PlayerPrefs.SetFloat(PLAYER_PREFS_SENSITIVITY_VOLUME, sensitivitySlider.value);
        
        PlayerPrefs.SetInt(PLAYER_PREFS_GRAPHIC_INDEX, graphicsDropDown.value);
    }

    private void ResetSettings()
    {
        AudioManager.Instance.SetMusicVolume(musicVolume);
        AudioManager.Instance.SetSoundVolume(soundVolume);
        PlayerPrefs.SetFloat(PLAYER_PREFS_SENSITIVITY_VOLUME, sensitivityValue);

        PlayerPrefs.SetInt(PLAYER_PREFS_GRAPHIC_INDEX, selectedGraphicIndex);
    }
}
