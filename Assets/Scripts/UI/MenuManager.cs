using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Reference to the pause menu, found under Canvas.")]
    [SerializeField] private GameObject _pauseMenu;
    [Tooltip("Reference to the death menu, found under Canvas.")]
    [SerializeField] private GameObject _deathMenu;
    
    [Header("Variables")]
    private bool togglePause;
    private bool hasDied;

    private void Start()
    {
        _pauseMenu.SetActive(false);
        _deathMenu.SetActive(false);
    }

    private void Update()
    {
        if (_pauseMenu == null || _deathMenu == null) return;
        
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            ShowDeathScreen();
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            togglePause = !togglePause;
        }

        if (togglePause)
        {
            Pause();
            return;
        }

        Resume();
    }

    public void Pause()
    {
        _pauseMenu.SetActive(true);
        togglePause = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        _pauseMenu.SetActive(false);
        togglePause = false;
        Time.timeScale = 1f;
    }

    public void QuitToMainMenu(int id)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(id);
    }

    public void PlayAgain(int id)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(id);
    }
    
    public void ShowDeathScreen()
    {
        _pauseMenu.SetActive(false);
        togglePause = false;
        
        _deathMenu.SetActive(true);
    }
}
