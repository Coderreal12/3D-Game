
using UnityEngine;


public class Chase_Player : MonoBehaviour
{
    [SerializeField] private Rigidbody self;
    [SerializeField] private Transform player;

    [SerializeField] private float NPC_Speed;

    [SerializeField] private Transform[] bones;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i <= bones.Length - 1; i++)
        {
            bones[i].LookAt(player.transform, Vector3.up);
        }
        
    }



    private void FixedUpdate()
    {
        Vector3 direction = player.transform.position - self.transform.position;
        self.AddForce(direction * NPC_Speed - self.linearVelocity * 1f, ForceMode.Acceleration);
        self.linearDamping = 5;
    }
}
