using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memo.Data
{
	[CreateAssetMenu(fileName = "LevelData", menuName = "Memo/LevelData", order = 0)]
	public class LevelData : ScriptableObject
	{
		/// <summary>
		/// El titulo del nivel.
		/// </summary>
		public string Titulo;

		/// <summary>
		/// La descripcion del nivel.
		/// </summary>
		[Multiline]
		public string Subtitulo;

		public Color Color;

		public List<Sprite> Tarjetas = new List<Sprite>();

		/// <summary>
		/// La cantidad de tarjetas trampa que tiene el nivel.
		/// </summary>
		[Range(0, 3)]
		public int CantidadTarjetasTrampa = 0;



		public float recordTimeSeconds;
		public float defaultRecordTimeSeconds;


        public static Color NoDataColor = new Color(0.7607844F, 0.7607844F, 0.7607844F);
	}
}