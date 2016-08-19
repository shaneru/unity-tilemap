﻿using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace toinfiniityandbeyond.Tilemapping
{
	[Serializable]
	public class Eraser : ScriptableTool
	{
		public int radius;

		public Eraser () : base ()
		{
			radius = 1;
		}
		public override KeyCode Shortcut { get { return KeyCode.E; } }
		public override string Description { get { return "Sets the painted tile to nothing"; } }

		public override bool Use (Coordinate point, ScriptableTile tile, TileMap map)
		{
			if (tile == null && map == null)
				return false;

			int correctedRadius = radius - 1;

			bool result = false;
			for (int x = -correctedRadius; x <= correctedRadius; x++)
			{
				for (int y = -correctedRadius; y <= correctedRadius; y++)
				{
					Coordinate offsetPoint = point + new Coordinate (x, y);

					if (map.SetTileAt (offsetPoint, null))
					{
						result = true;
					}
				}
			}
			return result;
		}
	}
}
