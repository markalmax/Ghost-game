using UnityEngine;

public class MainmenuManager : MonoBehaviour
{
    public GameObject SettingsCamera, MainCamera, PlayMenu;
    public GameObject PlayButton, TutorialButton, SampleButton, SettingsButton, BackButton1 ,BackButton2, QuitButton;
    public void Start()
    {
        PlayButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(Play);
        TutorialButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(Tutorial);
        SampleButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(Sample);
        SettingsButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(Settings);
        BackButton1.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(Back);
        BackButton2.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(Back);
        QuitButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(Quit);
    }
    public void Play()
    {
        PlayMenu.SetActive(true);
        MainCamera.SetActive(true);
        SettingsCamera.SetActive(false);
        Debug.Log("Play");
    }
    public void Tutorial()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);

    }
    public void Sample()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
    public void Settings()
    {
        SettingsCamera.SetActive(true);
        MainCamera.SetActive(false);
        PlayMenu.SetActive(false);
        Debug.Log("Settings");
    }
    public void Back()
    {
        MainCamera.SetActive(true);
        SettingsCamera.SetActive(false);
        PlayMenu.SetActive(false);
        Debug.Log("Back");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

}
