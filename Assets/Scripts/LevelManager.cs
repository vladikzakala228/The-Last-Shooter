using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadMainLevel()
    {
        SceneManager.LoadScene("Level1_Scene", LoadSceneMode.Single);
    }

    public void ExitBtn()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu_Scene", LoadSceneMode.Single);
    }
}
