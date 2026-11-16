using UnityEngine;

public class OnShoot : MonoBehaviour
{
     private Vector3 start;
    private Vector3 up;
    [SerializeField] private Transform door;
    private float speed = 3;
    private void Start()
    {
        start = door.position;
        up = door.position + door.transform.up * 3f;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Boii");
            door.position = Vector3.MoveTowards(door.position, up, speed);
        }
    }
}
