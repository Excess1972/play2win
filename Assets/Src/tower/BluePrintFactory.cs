using UnityEngine;

namespace Src.tower
{
	public class BluePrintFactory : MonoBehaviour
	{
		public GameObject tower_01_bp;
		public GameObject tower_02_bp;

		/**
	* callback for clicking on the buildbuttons 1
	*/
		public void spawn_tower_01_bp()
		{
			if (Gamemanager.Instance.TowerDrag)
			{
				return;
			}

			Instantiate(tower_01_bp);
		}

		/**
	* callback for clicking on the buildbuttons 2
	*/
		public void spawn_tower_02_bp()
		{
			if (Gamemanager.Instance.TowerDrag)
			{
				return;
			}

			Instantiate(tower_02_bp);
		}
	}
}