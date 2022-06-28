using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _panelScore;
    [SerializeField] private GameObject _panelCredits;
    public TextMeshProUGUI myScore;
    public ScoreData scoreData;
    

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Score()
    {
        _mainMenu.SetActive(false);
        _panelScore.SetActive(true);
        myScore.text = "My record score  " + scoreData.scoreData;

    }
    
    public void Credits()
    {
        _mainMenu.SetActive(false);
        _panelCredits.SetActive(true);
    }

    public void ExitMenu()
    {
        _mainMenu.SetActive(true);
        _panelCredits.SetActive(false);
        _panelScore.SetActive(false);
    }
}
