using Memo.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Memo.Controller
{
    public class LevelController : MonoBehaviour
    {
        public LevelData Data;

        public Text PauseLevelTitle;

        private void Awake()
        {
            Data = TransientController.instance.CurrentLevel;

            if (Data == null)
            {
                return;
            }

            PauseLevelTitle.text = Data.Titulo;
        }
    }
}