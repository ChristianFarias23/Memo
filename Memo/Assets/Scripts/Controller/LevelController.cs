using System.Collections.Generic;
using Memo.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Memo.Controller
{
    public class LevelController : MonoBehaviour
    {
        public LevelData Data;


        public SpriteRenderer TarjetaPrefab;
        public Transform TarjetasContainer;
        public List<Transform> TarjetasPositions;
		public List<SpriteRenderer> Tarjetas = new List<SpriteRenderer>();


        public Text PauseLevelTitle;

        private void Awake()
        {
            Data = TransientController.instance.CurrentLevel;

            if (Data == null)
            {
                return;
            }

            PauseLevelTitle.text = Data.Titulo;

            for (int i = 0; i < Data.Tarjetas.Count; i++)
            {
                var tarjeta = Instantiate(TarjetaPrefab, Vector3.zero, Quaternion.identity, TarjetasContainer);
                Tarjetas.Add(tarjeta);
                tarjeta.transform.position = TarjetasPositions[i].position;
            }


        }

        private void Update()
        {
            
        }
    }
}