

using UnityEngine;

public class Wall_Run : MonoBehaviour
{
    [SerializeField] private float inty;
    [Header("Scripts")]

    [SerializeField] private Player_Controller script;

    [Header("Rigidbodies")]
    public bool onwall;
    
    [SerializeField] private Rigidbody player;

    [Header("Transfroms")]
    [SerializeField] private Transform Infront;

    [Header("Floats")]
    [SerializeField] private float Raycast_Offset;
    [SerializeField] private float downForce;
    [SerializeField] private float Wall_DashForce;
    private float InputY;
    private float Minus;
    
    public bool addForce;
    bool jumponwall;
    


    [Header("RaycastsLeft")]
    //raycast Left
   Vector3 DirectionLeft;
    
    Ray ray;
 bool wallLeft = false;
[SerializeField] private float Distance;
[SerializeField] private float Force;
[SerializeField] private Transform Wall_Raycast;

    [Header("Raycasts Right")]
    Vector3 DirectionRight;
    [SerializeField] private Transform Wall_RayastRight;
    bool wallRight = false;
    bool jumping;
    bool bug;

    // Update is called once per frame

    private void Update()
    {
        
        //Getting Input;
      InputY = Input.GetAxisRaw("Horizontal");
        jumponwall = Input.GetKeyDown(KeyCode.Space);
        //So it slides down.
       if (bug == true)
        {
            player.linearVelocity = new Vector3(0, inty, 0);
        }

    }


    void FixedUpdate()
    {
        // WallJump();
        //Gets Input for Y
        
       
        //Sends raycasts.
        SendLeft();
        SendRight();
        WallJump();
       // if grounded then Change the wall dash force to variable MINUS.
       /* if (script.Grounded == true)
        {
            Minus = Wall_DashForce;
            addForce = true;
        }*/
       


        //Asks if Input is greater or less than 0, and Raycast is true, and It is not ground then wall run.
        if (wallLeft && InputY > 0 || wallLeft && InputY < 0 && script.Grounded == false && Input.GetKey(KeyCode.Space)|| wallRight && InputY > 0 || wallRight && InputY < 0 && script.Grounded == false && Input.GetKey(KeyCode.Space))
        {
            
           
            if(player.linearVelocity == new Vector3(0,0,0) )
            {
               
                bug = true;
                
            }
            else
            {
                bug = false;
            }

                float x = Input.GetAxisRaw("Horizontal");


            addForce = true;
            Minus = Minus / 0.5f;




            //   player.AddForce(transform.right * InputY * Force);
           
           
            player.AddRelativeForce(Vector3.down * downForce);

        }

    }


    private void SendLeft()
    {
        DirectionLeft = Wall_Raycast.position - transform.position;
        Ray ray = new Ray(Wall_Raycast.position, DirectionLeft);
        wallLeft = Physics.Raycast(ray, Distance, LayerMask.GetMask("Wall"));
        Debug.DrawRay(ray.origin, ray.direction * Distance, Color.red) ;
        
    }


    private void SendRight()
    {
        DirectionRight =  Wall_RayastRight.position - transform.position;
        Ray ray = new Ray(Wall_RayastRight.position, DirectionRight);
        wallRight = Physics.Raycast(ray, Distance, LayerMask.GetMask("Wall"));
       
        Debug.DrawRay(ray.origin, ray.direction * Distance,Color.black);
        
    }


    private void WallJump()
    {
        if (addForce == true && jumponwall && script.Grounded == false)
        {
            player.AddForce(Camera.main.transform.forward * Wall_DashForce);
            addForce = false;

        }
    }


}
