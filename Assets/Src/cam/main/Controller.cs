using UnityEngine;

namespace Src.cam.main
{
	public class Controller : MonoBehaviour
	{
		private Camera  _cam;
		private Vector3 touchStart;

		private void Awake()
		{
			_cam = Camera.main;
			// _cam.fieldOfView = 40;
		}

		void Update()
		{
			// float wheelVal = -Input.GetAxis("Mouse ScrollWheel");
			// if (wheelVal != 0f)
			// {
			// 	float fov = Mathf.MoveTowards(
			// 		_cam.fieldOfView,
			// 		60,
			// 		wheelVal * 2000 * Time.deltaTime
			// 	);
			// 	_cam.fieldOfView = Mathf.Clamp(fov, 20, 40);
			// 	return;
			// }

			if (Gamemanager.Instance.TowerDrag)
			{
				return;
			}

			if (Input.GetMouseButtonDown(0))
			{
				touchStart = GetWorldPosition(0);
			}

			if (Input.GetMouseButton(0))
			{
				Vector3 direction = touchStart - GetWorldPosition(0);
				_cam.transform.position += direction;
			}
		}

		private Vector3 GetWorldPosition(float z)
		{
			Ray   mousePos = _cam.ScreenPointToRay(Input.mousePosition);
			Plane ground   = new Plane(Vector3.down, new Vector3(0, 0, z));
			float distance;
			ground.Raycast(mousePos, out distance);
			return mousePos.GetPoint(distance);
		}
	}
}