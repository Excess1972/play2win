using UnityEngine;

public class build_tower_bp : MonoBehaviour
{
	private RaycastHit _hit;
	private Camera     _camera;
	private Vector3    _mousePoint;
	public  LayerMask  mask;
	
	// the preview of the tower
	public  GameObject prefab;
	
	// to set the color of the preview
	private Material   _material;

	// need to check the min builddistance
	private Transform[] objectsInSceneTransforms;

	private void Start()
	{
		_camera = Camera.main;
		Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out _hit, Mathf.Infinity, mask))
		{
			transform.position = _hit.point;
		}

		objectsInSceneTransforms = GameObject.Find("environment_items").GetComponentsInChildren<Transform>();
	}

	/**
	 * mousemove updates the position of the preview
	 * if position is in valid buildposition the preview is green otherwise it will display in red
	 * rightclick abourts the positioning
	 *
	 * leftclick set builds the tower
	 */
	private void Update()
	{
		// right click to abort
		if (Input.GetMouseButton(1))
		{
			Destroy(gameObject);
			return;
		}

		setColor(Color.green);

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

		if (Input.GetMouseButton(0))
		{
			Gamemanager.Instance.spendGold(100);
			GameObject ret = Instantiate(prefab, transform.position, transform.rotation);
			Gamemanager.Instance.towersPositions.Add(ret.transform.position);
			Destroy(gameObject);
		}
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