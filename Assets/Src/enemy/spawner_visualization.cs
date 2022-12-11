using UnityEngine;

namespace Src.enemy
{
    public class spawner_visualization : MonoBehaviour
    {
        public float _size = 10;

        //Draws Cube thats only visible when selected <- big nice
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(1, 0, 0, 0.4F);
            Gizmos.DrawCube(transform.position, new Vector3(_size, 0.1f, _size));
        }
    }
}
