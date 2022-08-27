using UnityEngine;

public class build_tower_bp : MonoBehaviour
{
	private RaycastHit _hit;
	private Vector3    _mousePoint;
	public  GameObject prefab;
	public  LayerMask  mask;

	private Transform[] entItemsTransforms;

	private void Start()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out _hit, Mathf.Infinity, mask))
		{
			transform.position = _hit.point;
		}

		entItemsTransforms = GameObject.Find("environment_items").GetComponentsInChildren<Transform>();
	}

	private void Update()
	{
		if (Input.GetMouseButton(1))
		{
			Destroy(gameObject);
		}

		gameObject.GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.green);

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out _hit, Mathf.Infinity, mask))
		{
			transform.position = _hit.point;
		}

		float distToBase = Vector3.Distance(transform.position, Gamemanager.Instance._base.transform.position);

		if (distToBase < 6f)
		{
			gameObject.GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.red);
			return;
		}

		foreach (Transform envTransform in entItemsTransforms)
		{
			if (Vector3.Distance(transform.position, envTransform.position) < 2.5f)
			{
				gameObject.GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.red);
				return;
			}
		}

		foreach (Vector3 pos in Gamemanager.Instance.towersPositions)
		{
			if (Vector3.Distance(transform.position, pos) < 2.5f)
			{
				gameObject.GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.red);
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
}