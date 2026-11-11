using UnityEngine;

public class Door_Up : MonoBehaviour
{
    [SerializeField] private Transform door;
    [SerializeField] private  float speed;
    private Vector3 up;
    private Vector3 start;
    private float time;
    private void Start()
    {
        start = door.position;
        up = door.position + door.transform.up * 3f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.collider.CompareTag("Cube"))
        {

            door.position = Vector3.MoveTowards(door.position, up, speed);


        }
    }

    private void OnCollisionExit(Collision collision)
    {
        door.position = Vector3.MoveTowards(door.position, start, speed);
    }





}
