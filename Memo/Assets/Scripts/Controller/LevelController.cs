using System;
using System.Collections.Generic;
using Memo.Behaviour;
using Memo.Data;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Memo.Controller
{
    public class LevelController : MonoBehaviour
    {
        public LevelData Data;

        public SceneController SceneController;


        public Card TarjetaPrefab;
        public Transform TarjetasContainer;
        public List<CardPosition> TarjetasPositions;
		public List<Card> Tarjetas = new List<Card>();


        public Text PauseLevelTitle;

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

        public void LevelStart()
        {
            foreach (var tarjeta in Tarjetas)
            {
                tarjeta.Flip();
            }
        }
    }
}