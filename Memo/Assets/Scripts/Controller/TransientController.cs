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
    }
}