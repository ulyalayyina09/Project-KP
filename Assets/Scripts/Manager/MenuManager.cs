using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject defaultPanel;

    public void NewGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void LoadGame()
    {
        Debug.Log("Load Game");
    }

    public void Settings()
    {
        settingsPanel.SetActive(true);
        defaultPanel.SetActive(false);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
