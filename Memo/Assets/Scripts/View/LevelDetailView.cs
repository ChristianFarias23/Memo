using Memo.Data;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using Memo.Controller;

namespace Memo.View
{
    public class LevelDetailView : MonoBehaviour
    {
        public static LevelDetailView instance;

        private void Awake()
        {
            instance = this;
        }

        public LevelData Data;
        public Text Titulo, Subtitulo;
        public Text CantidadTarjetas, RecordActual;
        public List<Image> PreviewTarjetas;

        public void UpdateView()
        {
            Data = TransientController.instance.CurrentLevel;

            if (Data == null)
            {
                return;
            }

            Titulo.text = Data.Titulo;
            Subtitulo.text = Data.Subtitulo;
            CantidadTarjetas.text = string.Format("Cantidad de tarjetas: {0}", (Data.Tarjetas.Count * 2));
            RecordActual.text = string.Format("Record actual: {0}", "PLACEHOLDER");
            
            if (Data.Tarjetas == null || Data.Tarjetas.Count == 0)
            {
                return;
            }

            // El minimo de tarjetas = La cantidad de tarjetas que se muestran en la preview (3).
            for (int i = 0; i < 3; i++)
            {
                PreviewTarjetas[i].sprite = Data.Tarjetas[i] ?? null;
            }            
        }
    }
}