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
		public string TituloNivel;

		public Color Color;

		/// <summary>
		/// La cantidad de tarjetas que tiene el nivel.
		/// Debe ser un numero par.
		/// </summary>
		[Range(4, 30)]
		public int CantidadTarjetas = 4;

		/// <summary>
		/// La cantidad de tarjetas trampa que tiene el nivel.
		/// </summary>
		[Range(0, 3)]
		public int CantidadTarjetasTrampa = 0;

		public void OnValidate()
		{
			if (CantidadTarjetas%2 != 0)
			{
				CantidadTarjetas++;
			}
		}
	}
}