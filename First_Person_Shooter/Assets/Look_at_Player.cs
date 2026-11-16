using UnityEngine;

public class Look_at_Player : MonoBehaviour
{
    [SerializeField] private Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(player.position.x,   player.position.y,player.position.z), Vector3.up);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y  - 180f, transform.eulerAngles.z);
    }
}
