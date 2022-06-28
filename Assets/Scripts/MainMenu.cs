using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _panelScore;
    [SerializeField] private GameObject _panelCredits;
   
    

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
