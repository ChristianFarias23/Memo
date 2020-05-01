using Memo.Data;
using Memo.View;
using UnityEngine;
using UnityEngine.UI;

namespace Memo.Controller
{
    public class MainMenuController : MonoBehaviour
    {
        public Animator MainMenuAnimator;

        private void Start()
        {
            var data = TransientController.instance.CurrentLevel;

            if (data == null)
            {
                return;
            }

            LevelDetailView.instance.Data = data;
            LevelDetailView.instance.UpdateView();
            MainMenuAnimator.SetTrigger("level_open");
        }

        public void SetCurrentLevelData(LevelButtonView levelButton)
        {
            if (levelButton == null || levelButton.Data == null)
            {
                return;
            }

            TransientController.instance.CurrentLevel = levelButton.Data;
            LevelDetailView.instance.UpdateView();
        }
    }
}