

using UnityEngine;


public class Chase_Player : MonoBehaviour
{
    [SerializeField] private Rigidbody self;
    [SerializeField] private Transform player;

    [SerializeField] public float NPC_Speed;

    [SerializeField] private Transform[] bones;


    [SerializeField] private float Radius;

    [SerializeField] private Collider coll;
    Ray ray;
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
         ray = new Ray(transform.position, transform.forward);
        if (Physics.CheckSphere(ray.origin, Radius, LayerMask.GetMask("Player")))
            {
RunPlayer();



        }
        
    }


    private void RunPlayer()
    {
        coll.isTrigger = true;
Vector3 direction = player.transform.position - self.transform.position;
        self.AddForce(direction * NPC_Speed - self.linearVelocity * 1f, ForceMode.Acceleration);
        self.linearDamping = 5;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(ray.origin, Radius);
    }

}
