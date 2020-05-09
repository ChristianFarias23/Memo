using UnityEngine;
using UnityEngine.SceneManagement;

namespace Memo.Controller
{
    public class SceneController : MonoBehaviour
    {
        public void LoadLevelScene()
        {
            SceneManager.LoadScene("LevelScene", LoadSceneMode.Single);
        }

        public void LoadMainMenuScene()
        {
            SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}