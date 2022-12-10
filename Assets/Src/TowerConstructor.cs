using System;
using UnityEngine;

public class TowerConstructor : MonoBehaviour
{
	private RaycastHit _hit;
	private Camera     _camera;
	private Vector3    _mousePoint;
	private bool       _validBuildPosition;
	public  LayerMask  mask;

	// the preview of the tower
	public GameObject prefab;

	// to set the color of the preview
	private Material _material;

	// need to check the min builddistance
	// TODO : must be in the glabel scope ... not for EACH tower !!!
	private Transform[] objectsInSceneTransforms;

	private void Start()
	{
		Gamemanager.Instance.TowerDrag = false;
		_camera = Camera.main;
		Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out _hit, Mathf.Infinity, mask))
		{
			transform.position = new Vector3(_hit.point.x, _hit.point.y, _hit.point.z);
		}

		objectsInSceneTransforms = GameObject.Find("environment_items").GetComponentsInChildren<Transform>();
	}

	private void OnMouseDown()
	{
		Gamemanager.Instance.TowerDrag = true;
	}

	/**
	 * mousemove updates the position of the preview
	 * if position is in valid buildposition the preview is green otherwise it will display in red
	 * mouse/touch UP abourts the positioning
	 *
	 */
	private void OnMouseDrag()
	{
		if (!Gamemanager.Instance.TowerDrag)
		{
			return;
		}

		setColor(Color.green);
		_validBuildPosition = false;

		var ray = _camera.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out _hit, Mathf.Infinity, mask))
		{
			transform.position = _hit.point;
		}

		float distToBase = Vector3.Distance(transform.position, Gamemanager.Instance._base.transform.position);

		if (distToBase < 6f)
		{
			setColor(Color.red);
			return;
		}

		foreach (Transform envTransform in objectsInSceneTransforms)
		{
			if (Vector3.Distance(transform.position, envTransform.position) < 2.5f)
			{
				setColor(Color.red);
				return;
			}
		}

		foreach (Vector3 pos in Gamemanager.Instance.towersPositions)
		{
			if (Vector3.Distance(transform.position, pos) < 2.5f)
			{
				setColor(Color.red);
				return;
			}
		}

		_validBuildPosition = true;
	}

	private void OnMouseUp()
	{
		if (_validBuildPosition)
		{
			Gamemanager.Instance.spendGold(100);
			GameObject ret = Instantiate(prefab, transform.position, transform.rotation);
			Gamemanager.Instance.towersPositions.Add(ret.transform.position);
			Destroy(gameObject);
		}

		Gamemanager.Instance.TowerDrag = false;
		Destroy(gameObject);
	}

	private void setColor(Color color)
	{
		if (_material == null)
		{
			_material = gameObject.GetComponentInChildren<Renderer>().material;
		}

		_material.SetColor("_Color", color);
	}
}