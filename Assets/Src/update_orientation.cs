using UnityEngine;

public class update_orientation : MonoBehaviour
{
    private Camera _cam;
    // Start is called before the first frame update
    private void Awake()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = _cam.transform.eulerAngles;
    }
}
