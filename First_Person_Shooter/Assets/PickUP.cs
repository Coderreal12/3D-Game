

using UnityEngine;

public class PickUP : MonoBehaviour
{
    private detect_Gun Gun;
    RaycastHit hit;
    [SerializeField] float speed;
    [Header("Transforms")]
    [SerializeField] private Transform Grabbing;
  


    [Header("floats")]
    [SerializeField] private  float maxdis;
    [SerializeField] float Offset;


    [Header("Strings")]
    [SerializeField] private string[] Pickups;

    [SerializeField] float radius;

    //Bools
    public bool pickup = false;

    //scripts
    CounteractForce force;

    RaycastHit Sphit;

    private Rigidbody TempRigidBody;
    private Transform TempTransform;
    private Vector3 Exitvelo;
    Ray sp;
    void Update()
    {
        Send();

        
       
     
       
if (pickup && Input.GetKeyDown(KeyCode.T))
        {
            LetGo();
        }


        
    }
    private void FixedUpdate()
    {
        if (pickup)
        {
            Grab();
        }

    }
    private void Send()
    {




        //Direction of which the player is facing.
        Vector3 direction = (Camera.main.transform.position + Offset * Camera.main.transform.forward) - (-1 * Camera.main.transform.forward * maxdis);

        //Ray of which to send the raycast
         Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        //draws ray.
       

        //If it is hitting the object that has Pickup as its tag then:
        if (Physics.Raycast(ray, out hit,maxdis, LayerMask.GetMask(Pickups))  && Input.GetKeyDown(KeyCode.R) && pickup == false)
            {
            
            pickup = true;
            //set Rigid Body to the colliders rigidbody.
            TempRigidBody = hit.collider.gameObject.GetComponent<Rigidbody>();
            //set the transfrom to the colliers transform.
            TempTransform = hit.collider.gameObject.GetComponent<Transform>();

            force = hit.collider.gameObject.GetComponent<CounteractForce>();

        }
        
        

        

        



      
    }

    private void Grab()
    {
        Vector3 direction = (Grabbing.position - TempTransform.position);

        float dis = Vector3.Distance(Grabbing.transform.position, TempTransform.transform.position ) ;

       
        


        TempRigidBody.isKinematic = false;

        TempRigidBody.useGravity = false;
         
        //Adds force Mimnus the linear velo So it counteracts the overshooting effect.
            TempRigidBody.AddForce(direction * 50f - TempRigidBody.linearVelocity * 15f,
                ForceMode.Acceleration);
       
            
      

        

           


        




       
            //Debug.Log(Sphit.collider.gameObject);




        //TempRigidBody.MovePosition(Grabbing.position);
        TempRigidBody.maxLinearVelocity = 5f;

        /*TempTransform.position = Grabbing.position;*/
        

    }


    private void LetGo()
    {
        TempRigidBody.useGravity = true;
        TempRigidBody.linearDamping = 0f;
        TempRigidBody.maxLinearVelocity = 10000000f;
     
        TempRigidBody = null;
        
        TempTransform.SetParent(null);
        TempTransform = null;
        pickup = false;
        force = null;
    }

   




    public float Show()
    {
        return maxdis;
    }

   

}
