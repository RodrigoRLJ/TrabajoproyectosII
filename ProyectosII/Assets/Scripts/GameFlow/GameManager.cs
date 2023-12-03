using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton guarantee

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            //Limita los frames por segundo para que unity no se vuelva loco
            Application.targetFrameRate = 60;
            //Fuerza los FPS? comprobar en rendimiento.
            QualitySettings.vSyncCount = 0;
        }
        else
        {
            Destroy(Instance);
        }
    }

    #endregion

    public static void PauseGame()
    {
        Time.timeScale = 0;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public static void ChangeScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName: sceneName);
    }


    public static void QuitGame()
    {
#if UNITY_EDITOR // Si esta en el editor de unity cierra el modo juegp
        UnityEditor.EditorApplication.isPlaying = false;
#endif //Si esta en el juego compilado sal del juego
        Application.Quit();
    }
}