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

        public Sprite DefaultIfEmptySprite;

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
            RecordActual.text = Data.recordTimeSeconds != Data.defaultRecordTimeSeconds ? 
                "Tiempo Record: " + TransientController.GetParsedSeconds(Data.recordTimeSeconds) : "Sin tiempo record";
            
            if (Data.Tarjetas == null || Data.Tarjetas.Count == 0)
            {
                return;
            }

            // El minimo de tarjetas = La cantidad de tarjetas que se muestran en la preview (3).
            for (int i = 0; i < 3; i++)
            {
                if (Data.Tarjetas.Count - 1 >= i)
                {
                    PreviewTarjetas[i].sprite = Data.Tarjetas[i];
                }
                else
                {
                    PreviewTarjetas[i].sprite = DefaultIfEmptySprite;
                }
            }
        }
    }
}