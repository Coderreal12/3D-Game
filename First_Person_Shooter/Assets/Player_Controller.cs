
using Unity.VisualScripting;
using UnityEngine;





public class Player_Controller : MonoBehaviour
{
    public Vector3 wallforce;
    [SerializeField] Wall_Run script;

    [SerializeField] Camera cam;
    [Header("Scripts")]
    [SerializeField] First_Person plays;

    bool Alive = true;
    [Header("Colliders")]
    [SerializeField] private Collider Defualt;
    [SerializeField] private Collider SlidingCol;



    [Header("Transforms")]
    [SerializeField] private Transform SphereCast;
    [SerializeField] private Transform Camera;
    [SerializeField] private Transform SSS;
    RaycastHit hit;

    [Header("RigidBodies")]
    [SerializeField] private Rigidbody player;

    [Header("Floats")]
    [SerializeField] public float Player_Speed;
    private float e;
    [SerializeField] private float Max_Dis;
    [SerializeField] private float Radius;
    [SerializeField] public float senstivity;
    [SerializeField] private float jump;
    [SerializeField] private float Inair;


    [Header("Strings")]
    [SerializeField] private string[] Grounds;
   
    //Bools
    private bool Focus = false;
    public bool Grounded;
    private bool sliding = false;


    //Raycasts
    Ray ray;
    Vector3 newcam;
    //Floats
    public float y;
   public float x;
    float z;
    float[] norm = new float[3];
    float[] Timespeed = new float[3];
    private void Start()
    {
        Timespeed[0] = Player_Speed * 2.3f;
        norm[0] = Player_Speed;

        Timespeed[1] = Inair * 2.3f;
        norm[1] = Inair;

        norm[2] = Player_Speed;
        Timespeed[2] = Player_Speed;

       
    }
    private void Update()
    {
        newcam = cam.transform.position + Vector3.down * 2f;
        GetInput();
        Set_Grounded();
        
        Jump();
        RotatePlayer();
        Exit_Enter_Lock();
        


    }

    private void FixedUpdate()
    {
        Player_Movement();
     
    }


    private void GetInput()
    {
        //Movement values W A S D
 x = Input.GetAxisRaw("Horizontal");
z = Input.GetAxisRaw("Vertical");
    }
    private void Set_Grounded()
    {
        //SPHERE CAST DOWN
        ray = new Ray(SSS.position,Vector3.down);



        Grounded = Physics.CheckSphere(SphereCast.position, Radius, LayerMask.GetMask(Grounds));




        

       
       

    }




    private void Player_Movement()
    {
        

       
        //If Grounded is true, then Set the linear damping to 5 (So it doesnt slide) 
        if(Grounded == true)
        {
            
            
            player.linearDamping = 5f;
        }
        //If not true then set the lineardamping to 0 (so it doesnt fall Like a parachute)
        else
        {
            player.linearDamping = 0f;
            
        }
        

        //When Sprinting Set the PLayers speed to the TimesSpeed
        if (Input.GetKey(KeyCode.LeftControl) && Grounded)

        {
            Slide();
            Player_Speed = Timespeed[0];
          
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Grounded)
        {
            Timespeed[0] = 25f * 1.5f;
            Player_Speed = Timespeed[0];
            SlidingCol.isTrigger = true;
            Defualt.isTrigger = false;

        }
        else
        {
            SlidingCol.isTrigger = true;
            Defualt.isTrigger = false;
            Player_Speed = norm[0];
        }

       
            //Adds relative force On the ground
            if (Grounded == true  )
        {


           player.AddRelativeForce(x * Player_Speed, 0, z * Player_Speed);


        }
        else 
        //If the grounded is false, then take the starting velo and minus it from the current velo which stops the skating affect.
        {



            Vector3 startgin = player.linearVelocity;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Inair = Timespeed[1];
            }
            else
            {
                Inair = norm[1];
            }



 player.AddRelativeForce(new Vector3(x * Inair, 0, z * Inair));



            player.linearVelocity = new Vector3(player.linearVelocity.x - startgin.x, player.linearVelocity.y, player.linearVelocity.z - startgin.z);


        }
        
        

    }


    private void RotatePlayer()
    {



        player.transform.eulerAngles = new Vector3(player.rotation.x, Camera.eulerAngles.y, 0);
        //Wrong Is Player.transform.rotation
    }
    private void Exit_Enter_Lock()
    {
        if (Alive)
        {
 //Making the Bool for the object
        if (Input.GetKeyDown(KeyCode.L))
        {
            Focus = !Focus;
        }


        
       if (Focus == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
       else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        }
       

        

       

}
    private void Jump()
    {
        if (Grounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            player.AddForce(player.transform.up * jump);
        }

    }


    


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(SphereCast.position, Radius);

    }

    public void Die()
    {
        for (int i = 0; i <= 1; i++)
        {
            Timespeed[i] = 0;
            norm[i] = 0;
        }
        jump = 0;
        Alive = false;
            Cursor.lockState = CursorLockMode.None;




    }

    private void Slide()
    {

        SlidingCol.isTrigger = false;
        Defualt.isTrigger = true;

      
         
            
        Timespeed[0] *= .96f;
        sliding = true;
        



    }

  
}
