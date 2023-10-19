using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        private const string HORIZONTAL_AXIS = "Horizontal";
        private const string VERTICAL_AXIS = "Vertical";

        [SerializeField] private float speed;
        void Update()
        {
            transform.position += new Vector3(Input.GetAxis(HORIZONTAL_AXIS) * speed * Time.deltaTime, 0, Input.GetAxis(VERTICAL_AXIS) * speed * Time.deltaTime);
        }
    }
}