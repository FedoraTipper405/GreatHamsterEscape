using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuNavigationScript : MonoBehaviour
{
    // Volume 
    public Button decreaseVolumeButton;
    public Button increaseVolumeButton;
    public float volumeChangeAmount = 0.1f;
    public float holdDuration = 0.2f;

    private float holdTimer = 0f;
    private bool isHolding = false;
    private bool isIncreasing = false;

    public TextMeshProUGUI volumeText;

    // Menu 
    [SerializeField]
    public Button[] menuButtons;
    [SerializeField]
    public int currentButtonIndex = 0;
    [SerializeField]
    public bool isSelected = false;
    [SerializeField]
    public Color normalColor = Color.white;
    [SerializeField]
    public Color highlightColor = Color.red;
    [SerializeField]
    public Color holdColor = Color.green;

    private int previousButtonIndex = 0;

    void Start()
    {
        decreaseVolumeButton.onClick.AddListener(DecreaseVolume); //vol
        increaseVolumeButton.onClick.AddListener(IncreaseVolume); //vol

        SetButtonColor(menuButtons[currentButtonIndex], highlightColor);
    }

    void Update()
    {
        volumeText.text = Mathf.RoundToInt(AudioListener.volume * 100f) + " %";
        HandleVolumeChanges(); //vol
        HandleMenuNavigation();
    }

    private void HandleVolumeChanges() //vol
    {
        if (isHolding)
        {
            holdTimer += Time.deltaTime;
            if (holdTimer >= holdDuration)
            {
                if (isIncreasing)
                {
                    AudioListener.volume = Mathf.Clamp(AudioListener.volume + volumeChangeAmount * Time.deltaTime, 0f, 1f);
                }
                else
                {
                    AudioListener.volume = Mathf.Clamp(AudioListener.volume - volumeChangeAmount * Time.deltaTime, 0f, 1f);
                }
            }
        }
    }

    private void HandleMenuNavigation()
    {
        //Single tap
        if (Input.GetKeyDown(KeyCode.Space) && !isHolding)
        {
            CycleMenu();
        }

        //hold
        if (Input.GetKey(KeyCode.Space))
        {
            isHolding = true;
            holdTimer += Time.deltaTime;

            float holdProgress = holdTimer / holdDuration;
            Color currentColor = Color.Lerp(highlightColor, holdColor, holdProgress);
            SetButtonColor(menuButtons[currentButtonIndex], currentColor);

            if (holdTimer >= holdDuration && !isSelected)
            {
                SelectButton();
            }
        }
        else
        {
            ResetHoldState();
        }
    }

    public void DecreaseVolume()
    {
        isHolding = true;
        isIncreasing = false;
        holdTimer = 0f;
    }

    public void IncreaseVolume()
    {
        isHolding = true;
        isIncreasing = true;
        holdTimer = 0f;
    }

    public void CycleMenu()
    {
        if (isSelected)
        {
            SetButtonColor(menuButtons[currentButtonIndex], highlightColor);
            isSelected = false;
        }
        else
        {
            SetButtonColor(menuButtons[previousButtonIndex], normalColor);
        }

        previousButtonIndex = currentButtonIndex;
        currentButtonIndex = (currentButtonIndex + 1) % menuButtons.Length;

        SetButtonColor(menuButtons[currentButtonIndex], highlightColor);
    }

    public void SelectButton()
    {
        isSelected = true;
        SetButtonColor(menuButtons[previousButtonIndex], normalColor);
        menuButtons[currentButtonIndex].onClick.Invoke();
    }

    public void SetButtonColor(Button button, Color color)
    {
        ColorBlock colorBlock = button.colors;
        colorBlock.normalColor = color;
        colorBlock.highlightedColor = color;
        button.colors = colorBlock;

    }

    private void ResetHoldState()
    {
        holdTimer = 0f;
        isHolding = false;
        SetButtonColor(menuButtons[currentButtonIndex], isSelected ? highlightColor : normalColor);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
