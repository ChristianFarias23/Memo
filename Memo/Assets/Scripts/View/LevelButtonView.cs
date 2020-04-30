using Memo.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Memo.View
{
    public class LevelButtonView : MonoBehaviour
    {
        public LevelData Data;

        public Button Boton;

        
        private static Color _noDataColor = new Color(0.7607844F, 0.7607844F, 0.7607844F);
        private void OnValidate()
        {
            Boton = null ?? GetComponent<Button>();
            
            if (!Data)
            {
                Boton.GetComponentInChildren<Text>().text = "Nivel Bloqueado";
                Boton.GetComponent<Image>().color = _noDataColor;
            }
            else
            {
                Data.OnValidate();
                Boton.GetComponentInChildren<Text>().text = Data.TituloNivel;
                Boton.GetComponent<Image>().color = Data.Color;
            }
        }
    }
}