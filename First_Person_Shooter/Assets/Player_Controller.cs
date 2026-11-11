
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;



public class Player_Controller : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] First_Person plays;



    [Header("Transforms")]
    [SerializeField] private Transform SphereCast;
    [SerializeField] private Transform Camera;
    [SerializeField] private Transform SSS;
    RaycastHit hit;

    [Header("RigidBodies")]
    [SerializeField] private Rigidbody player;

    [Header("Floats")]
    [SerializeField] private float Player_Speed;
    private float e;
    [SerializeField] private float Max_Dis;
    [SerializeField] private float Radius;
    [SerializeField] public float senstivity;
    [SerializeField] private float jump;
    [Header("Strings")]
    [SerializeField] private string[] Grounds;
    //Bools
    private bool Focus = false;
    private bool Grounded;

    //Raycasts
    Ray ray;

    //Floats
    public float y;
    float x;
    float z;
    private void Start()
    {
        e = Player_Speed;
    }
    private void Update()
    {
        if (hit.collider != null)
        {
            Debug.Log(hit.collider);
        }
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
        

       

        if(Grounded == true)
        {
            
           
            player.linearDamping = 5f;
        }
        else
        {
          
            player.linearDamping = 0f;
        }

 //Adds relative force
        player.AddRelativeForce(x * Player_Speed, 0, z * Player_Speed);
    }


    private void RotatePlayer()
    {



        player.transform.eulerAngles = new Vector3(player.rotation.x, Camera.eulerAngles.y, 0);
        //Wrong Is Player.transform.rotation
    }
    private void Exit_Enter_Lock()
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
}
