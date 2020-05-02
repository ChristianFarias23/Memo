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

        public bool flipped = true;

        public void Initialize(CardData data)
        {
            Data = data;
            
            Simbolo.sprite = Data.sprite;
            transform.position = Data.position;
            this.Flip();
        }

        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("UI");
                return;
            }

            Flip();
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
        }
    }
}