using UnityEngine;

namespace Memo.Behaviour
{
    public class Timer : MonoBehaviour
    {
        public float Seconds;
        private bool IsOn = false;

        private void FixedUpdate()
        {
            if (IsOn)
            {
                Tick();
            }
        }
        
        public void StartTimer()
        {
            IsOn = true;
        }

        public void PauseTimer()
        {
            IsOn = false;
        }
    
        private void Tick()
        {
            Seconds += Time.fixedDeltaTime;
        }
    }
}