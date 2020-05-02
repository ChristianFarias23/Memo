using System;
using System.Collections.Generic;
using Memo.Behaviour;
using Memo.Data;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;

namespace Memo.Controller
{
    public class LevelController : MonoBehaviour
    {
        public static LevelController instance;
        public LevelData Data;

        public SceneController SceneController;


        public Card TarjetaPrefab;
        public Transform TarjetasContainer;
        public List<CardPosition> TarjetasPositions;
		public List<Card> Tarjetas = new List<Card>();


        public Text PauseLevelTitle;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            Data = TransientController.instance.CurrentLevel;

            if (Data == null)
            {
                return;
            }

            PauseLevelTitle.text = Data.Titulo;

            for (int i = 0; i < Data.Tarjetas.Count; i++)
            {
                try
                {
                    Tarjetas.Add(InitiateTarjeta(i));
                    Tarjetas.Add(InitiateTarjeta(i));
                }
                catch (UnityException)
                {
                    // No hay mas espacios disponibles.
                    // Volver al menu principal.
                    TransientController.instance.CurrentLevel = null;
                    SceneController.LoadMainMenuScene();
                }
            }
        }

        private Card InitiateTarjeta(int index)
        {
            var randomPosition = Vector3.zero;
            try
            {
                randomPosition = GetRandomPosition();
            }
            catch (UnityException)
            {
                throw;
            }

            CardData data = new CardData()
            {
                id = index,
                sprite = Data.Tarjetas[index],
                position = randomPosition
            };

            var tarjeta = Instantiate(TarjetaPrefab, Vector3.zero, Quaternion.identity, TarjetasContainer);
            tarjeta.Initialize(data);
            return tarjeta;
        }

        public List<CardPosition> AvailableList;

        private Vector3 GetRandomPosition()
        {
            AvailableList = TarjetasPositions.FindAll(t => t.Available);

            if (AvailableList.Count == 0)
            {
                throw new UnityException();
            }

            var cardPosition = AvailableList.ElementAt(UnityEngine.Random.Range(0, AvailableList.Count));
            cardPosition.Available = false;

            return cardPosition.transform.position;
        }

        public Card flippedCard1;
        public Card flippedCard2;

        private void Update()
        {
            if (flippedCard1 == null || flippedCard2 == null)
            {
                return;
            }

            if (!lockCheckCompletePair)
            {
                StartCoroutine(CheckCompletePair());
            }
        }

        public bool NotifyFlipCard(Card card)
        {
            if (flippedCard1 == null && flippedCard2 != card)
            {
                Debug.Log("Flipped 1");
                flippedCard1 = card;
                return true;
            }

            if (flippedCard2 == null && flippedCard1 != card)
            {
                Debug.Log("Flipped 2");
                flippedCard2 = card;
                return true;
            }

            Debug.Log("Cant Flip");
            return false;
        }

        bool lockCheckCompletePair = false;
        IEnumerator CheckCompletePair()
        {
            lockCheckCompletePair = true;

            if (flippedCard1.Data.id == flippedCard2.Data.id)
            {
                // Caso misma carta:
                Debug.Log("COMPLETED");
                yield return new WaitForSeconds(0.5f);
                flippedCard1.Complete();
                flippedCard2.Complete();
            }
            else
            {
                // Caso carta distinta:
                Debug.Log("DISCARD, flipping");
                yield return new WaitForSeconds(0.5f);
                flippedCard1.Flip();
                flippedCard2.Flip();

            }

            // En cualquiera de ambos casos:
            flippedCard1 = null;
            flippedCard2 = null;


            lockCheckCompletePair = false;
        }

        public void LevelStart()
        {
            foreach (var tarjeta in Tarjetas)
            {
                tarjeta.Flip();
            }
        }
    }
}