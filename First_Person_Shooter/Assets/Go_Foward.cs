using UnityEngine;

public class Go_Foward : MonoBehaviour
{
    public Transform Player;
    [SerializeField] Rigidbody Self;
    void FixedUpdate()
    {
        Move();
    }


    public void Move()
    {
        if (Player != null)
        {
            Self.AddForce(Player.forward * 10f);
        }
    }
}
