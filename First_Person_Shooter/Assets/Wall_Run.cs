using UnityEngine;

public class Wall_Run : MonoBehaviour
{
    [SerializeField] private Player_Controller script;
    [SerializeField] private Rigidbody player;
    
    [SerializeField] private float Raycast_Offset;
    
    
    [SerializeField] private float downForce;
    [SerializeField] private float Wall_DashForce;
    private float InputY;
    bool addForce;

    


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
    
    // Update is called once per frame
    void Update()
    {
        //Gets Input for Y
        InputY = Input.GetAxisRaw("Horizontal");
       

        SendLeft();
        SendRight();
        if (script.Grounded == true)
        {
            addForce = true;
        }    


        //Asks if Input is greater or less than 0, and Raycast is true, and It is not ground then wall run.
        if (wallLeft && InputY > 0 || wallLeft && InputY < 0 && script.Grounded == false || wallRight && InputY > 0 || wallRight && InputY < 0 && script.Grounded == false)
        {

            if(addForce == true)
            {
                player.AddForce(Camera.main.transform.right * Wall_DashForce);
                addForce = false;
            }



            player.AddForce(transform.right * InputY * Force );
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
        DirectionRight =  Wall_RayastRight.position - Wall_RayastRight.transform.forward;
        Ray ray = new Ray(Wall_RayastRight.position, DirectionRight);
        wallRight = Physics.Raycast(ray, Distance, LayerMask.GetMask("Wall"));
        

    }


    


}
