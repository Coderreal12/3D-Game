
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class Player_Controller : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] First_Person plays;



    [Header("Transforms")]
    [SerializeField] private Transform SphereCast;
    [SerializeField] private Transform Camera;

    RaycastHit hit;

    [Header("RigidBodies")]
    [SerializeField] private Rigidbody player;

    [Header("Floats")]
    [SerializeField] private float Player_Speed;
    [SerializeField] private float Max_Dis;
    [SerializeField] private float Radius;
    [SerializeField] public float senstivity;

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
        
    }
    private void Update()
    {
        GetInput();
        Set_Grounded();
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
        ray = new Ray(SphereCast.position, Vector3.down);
        if (Physics.SphereCast(ray,Radius,out hit, LayerMask.GetMask(Grounds)))
            {
            
            Grounded = false;
        }
        else
        {
            Grounded = true;
        }

    }




    private void Player_Movement()
    {
        

        //Adds relative force
        player.AddRelativeForce(x * Player_Speed, 0, z * Player_Speed);

        if(Grounded == true)
        {
            
            player.linearDamping = 5f;
        }
        else
        {
            player.linearDamping = 0;
        }
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
    
private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(SphereCast.position, Radius);

    }
}
