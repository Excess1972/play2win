using UnityEngine;

public class RenderWireframed : MonoBehaviour
{
    private Camera _mainCam;
    
    void Start()
    {
        _mainCam = Camera.main;
    }

    void Update()
    {
        transform.position = _mainCam.transform.position;
    }

    private void OnPreRender()
    {
        GL.wireframe = true;
    }

    private void OnPostRender()
    {
        GL.wireframe = false;
    }
}
