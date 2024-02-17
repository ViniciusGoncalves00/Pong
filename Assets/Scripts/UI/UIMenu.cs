using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuParent;
    [SerializeField] private Button _start;
    [SerializeField] private Button _options;
    [SerializeField] private Button _credits;
    [SerializeField] private Button _quit;
    
    [SerializeField] private GameObject _gameModeParent;
    [SerializeField] private Button _solo;
    [SerializeField] private Button _versus;
    [SerializeField] private Button _ia;

    [SerializeField] private TextMeshProUGUI _gameTitle;

    [SerializeField] private float _hueSpeed = 0.1f;
    
    private float _hue;
    private const float Saturation = 1f;
    private const float Value = 1f;

    private void Start()
    {
        _start.GetComponentInChildren<TMP_Text>().text = "Start";
        _options.GetComponentInChildren<TMP_Text>().text = "Options";
        _credits.GetComponentInChildren<TMP_Text>().text = "Credits";
        _quit.GetComponentInChildren<TMP_Text>().text = "Quit";
        
        _start.onClick.AddListener(StartOnClicked);
        _options.onClick.AddListener(OptionsOnClicked);
        _credits.onClick.AddListener(CreditsOnClicked);
        _quit.onClick.AddListener(QuitOnClicked);
        
        _solo.GetComponentInChildren<TMP_Text>().text = "Solo";
        _versus.GetComponentInChildren<TMP_Text>().text = "Versus";
        _ia.GetComponentInChildren<TMP_Text>().text = "Versus IA";
        
        _solo.onClick.AddListener(() => LoadSceneWithGameMode(SelectedMode.SoloMode));
        _versus.onClick.AddListener(() => LoadSceneWithGameMode(SelectedMode.VersusMode));
        _ia.onClick.AddListener(() => LoadSceneWithGameMode(SelectedMode.IaMode));
    }

    private void Update()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        _hue += _hueSpeed * Time.deltaTime;
        
        if (_hue >= 1)
        {
            _hue = 0;
        }
        
        _gameTitle.color = Color.HSVToRGB(_hue, Saturation, Value);
    }

    private void StartOnClicked()
    {
        _mainMenuParent.SetActive(false);
        _gameModeParent.SetActive(true);
    }
    
    private void OptionsOnClicked()
    {
        SetEnabled(false);
    }
    
    private void CreditsOnClicked()
    {
        SetEnabled(false);
    }
    
    private void QuitOnClicked()
    {
        SetEnabled(false);
        Application.Quit();
    }

    private void SetEnabled(bool value)
    {
        _start.enabled = value;
        _options.enabled = value;
        _credits.enabled = value;
        _quit.enabled = value;
    }
    
    private void LoadSceneWithGameMode(GameMode gameMode)
    {
        SelectedMode.SetGameMode(gameMode);
        SceneManager.LoadScene("GameScene");
    }

    private void OnValidate()
    {
        _start.GetComponentInChildren<TMP_Text>().text = "Start";
        _options.GetComponentInChildren<TMP_Text>().text = "Options";
        _credits.GetComponentInChildren<TMP_Text>().text = "Credits";
        _quit.GetComponentInChildren<TMP_Text>().text = "Quit";
        _solo.GetComponentInChildren<TMP_Text>().text = "Solo";
        _versus.GetComponentInChildren<TMP_Text>().text = "Versus";
    }
}