using Memo.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Memo.View
{
    public class LevelButtonView : MonoBehaviour
    {
        public LevelData Data;

        public Button Boton;

        private void OnValidate()
        {
            Boton = null ?? GetComponent<Button>();
            
            if (!Data)
            {
                Boton.GetComponentInChildren<Text>().text = "Nivel Bloqueado";
                Boton.GetComponent<Image>().color = LevelData.NoDataColor;
            }
            else
            {
                Boton.GetComponentInChildren<Text>().text = Data.TituloNivel;
                Boton.GetComponent<Image>().color = Data.Color;
            }
        }
    }
}