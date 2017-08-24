using UnityEngine;

namespace Utils{

	public class ScreenSize {
		
		public static float Width {
			get {
				return Screen.width * (Camera.main.orthographicSize / ((float)Screen.height / 2f));
			}
		}
		
		public static float Height {
			get {
				return Screen.height * (Camera.main.orthographicSize / ((float)Screen.height / 2f));
			}
		}
		
		public static float MaxX {
			get {
				return Width / 2;
			}
		}
		
		public static float MinX {
			get {
				return MaxX * (-1);
			}
		}
		
		public static float MaxY {
			get {
				return Height / 2;
			}
		}
		
		public static float MinY {
			get {
				return MaxY * (-1);
			}
		}
	}
}