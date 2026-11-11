
using UnityEngine;


public class First_Person : MonoBehaviour
{
    [SerializeField] private Transform Player;

    [SerializeField] private Player_Controller Plays;

    [SerializeField] public float snes;




    //floats;
    private float x;
    public float y;

    Vector3 transformation;
    private void Start()
    {
        
    }
    void Update()
    {
        Follow_Player();
        
    }


    private void Follow_Player()
    {
        //Gets x and y axis
        x += Input.GetAxis("Mouse Y");
        y += Input.GetAxis("Mouse X");

        if (-x >= 90)
        {
            x = -90;
        }
        else if(-x <= -90)
        {
            x = 90;
        } 


        //sets position to the player position.
            transform.position = Player.position;

        //sets rotation to a eular.
        transform.rotation =  Quaternion.Euler(new Vector3(- x * snes, y * snes,0));
        


    }

    


}
