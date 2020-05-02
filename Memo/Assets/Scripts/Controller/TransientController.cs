using Memo.Data;
using Memo.View;
using UnityEngine;
namespace Memo.Controller
{
    public class TransientController : MonoBehaviour
    {
        public static TransientController instance;

        public LevelData CurrentLevel;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }

        public static string GetParsedSeconds(float seconds)
        {
            int min = (int) (seconds % 3600) / 60;
            int seg = (int) (seconds % 3600) % 60;

            string parsed = null;

            if (min == 0)
            {
                parsed = string.Format("{0}seg", seg);
            }
            else
            {
                if (seg == 0)
                {
                    parsed = string.Format("{0}min", min);
                }
                else
                {
                    parsed = string.Format("{0}min {1}seg", min, seg);
                }
            }

            return parsed;
        }
    }
}