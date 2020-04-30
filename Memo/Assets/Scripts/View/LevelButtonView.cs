using Memo.Data;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Memo.View
{
    public class LevelButtonView : MonoBehaviour
    {
        public LevelData Data;

        public Button Boton;

        private void OnValidate()
        {
            Boton = null ?? GetComponent<Button>();
            var image = Boton.GetComponent<Image>();
            var textos = Boton.GetComponentsInChildren<Text>();
            var titulo = textos.First(t => t.CompareTag("Titulo"));
            var subtitulo = textos.First(t => t.CompareTag("Subtitulo"));

            if (!Data)
            {
                titulo.text = "Nivel Bloqueado";
                subtitulo.text = "Algun dia!";
                image.color = LevelData.NoDataColor;
            }
            else
            {
                titulo.text = Data.Titulo;
                subtitulo.text = Data.Subtitulo;
                image.color = Data.Color;
            }
        }
    }
}