using Memo.Controller;
using Memo.Data;
using Memo.Effects;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Memo.Behaviour
{
    public class Card : MonoBehaviour
    {
        public CardData Data;

        public SpriteRenderer Simbolo;
        public Animator Animator;
        public DropShadow Shadow;

        public bool completed = false;
        public bool started = false;

        public bool flipped = true;

        public void Initialize(CardData data)
        {
            Data = data;

            Simbolo.sprite = Data.sprite;
            transform.position = Data.position;
        }

        private void OnMouseDown()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // Check if finger is over a UI element
                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    Debug.Log("Touched the UI");
                    return;
                }
            }

            if (Input.touchCount > 1)
            {
                Debug.Log("Only 1 touch allowed...");
                return;
            }

            if (completed || !started)
            {
                return;
            }

            if (LevelController.instance.NotifyFlipCard(this))
            {
                Flip();
            }
        }

        public void Flip()
        {
            if (!flipped)
            {
                Animator.SetTrigger("card_flip");
            }
            else
            {
                Animator.SetTrigger("card_unflip");
            }
            
            flipped = !flipped;
            LevelController.instance.Play("Flip " + UnityEngine.Random.Range(1, 5));
        }

        public void Complete()
        {
            Animator.SetTrigger("card_complete");
            completed = true;

            LevelController.instance.Play("Slide " + UnityEngine.Random.Range(1, 6));
        }
    }
}