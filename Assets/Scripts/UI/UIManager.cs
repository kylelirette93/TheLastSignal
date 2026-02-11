using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject gameplayPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject resultPanel;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject gameOverPanel;

    public void DisableAllUI()
    {
        if (menuPanel != null) menuPanel.SetActive(false);
        if (gameplayPanel != null) gameplayPanel.SetActive(false);
        if (pausePanel != null) pausePanel.SetActive(false);
        if (resultPanel != null) resultPanel.SetActive(false);
        if (settingsPanel != null) settingsPanel.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    public void ShowMenu()
    {
        DisableAllUI();
        if (menuPanel != null) menuPanel.SetActive(true);
    }

    public void ShowGameplay()
    {
        DisableAllUI();
        if (gameplayPanel != null) gameplayPanel.SetActive(true);
    }

    public void ShowPause()
    {
        DisableAllUI();
        if (pausePanel != null) pausePanel.SetActive(true);
    }
    public void ShowResult()
    {
        DisableAllUI();
        if (resultPanel != null) resultPanel.SetActive(true);
    }

    public void ShowSettings()
    {
        DisableAllUI();
        if (settingsPanel != null) settingsPanel.SetActive(true);
    }

    public void ShowGameOver()
    {
        DisableAllUI();
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
    }
}
