using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _panelScore;
    [SerializeField] private GameObject _panelCredits;
    [SerializeField] private AudioSource _audioEffect;
    public TextMeshProUGUI myScore;
    public ScoreData scoreData;
    

    public void StartGame()
    {
        _audioEffect.Play();
        SceneManager.LoadScene(1);
    }
    
    public void ExitGame()
    {
        _audioEffect.Play();
        Application.Quit();
    }

    public void Score()
    {
        _audioEffect.Play();
        _mainMenu.SetActive(false);
        _panelScore.SetActive(true);
        myScore.text = "My record score  " + scoreData.scoreData;

    }
    
    public void Credits()
    {
        _audioEffect.Play();
        _mainMenu.SetActive(false);
        _panelCredits.SetActive(true);
    }

    public void ExitMenu()
    {
        _audioEffect.Play();
        _mainMenu.SetActive(true);
        _panelCredits.SetActive(false);
        _panelScore.SetActive(false);
    }
}
