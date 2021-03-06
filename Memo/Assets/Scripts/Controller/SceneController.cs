using UnityEngine;
using UnityEngine.SceneManagement;

namespace Memo.Controller
{
    public class SceneController : MonoBehaviour
    {
        AudioController audioController;

        private void Start()
        {
            audioController = GameObject.FindObjectOfType<AudioController>();
        }


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

        public void Play(string audioName)
        {
            audioController.Play(audioName);
        }
    }
}