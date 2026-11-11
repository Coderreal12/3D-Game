

using UnityEngine;


public class Shoot : MonoBehaviour
{
    //Bullets
    [SerializeField] private GameObject bullet;

    [SerializeField] private Transform shootpos;
    GameObject bulleter;
    [SerializeField] private detect_Gun Gun;
    private float time;
    [Header("Floats")]
    [SerializeField] private float MaxDistance;


    [Header("Strings")]
    [SerializeField] private string[] Layermasks;

    [SerializeField] private Transform cam;
    //For Raycasting
    RaycastHit hit;
    private GameObject TempGame;
    private Vector3 Direction;
    private Ray ray;
    void Update()
    {
       
        time += Time.deltaTime;
        




   

        if (Gun.show() && Input.GetMouseButtonDown(0) && time >= 1)
        {
            Shoots();
            time = 0;
        }
    }


    private void Shoots()
    {
        
         bulleter = Instantiate(bullet);
        bulleter.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 3f;
        



        bulleter.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 570f,ForceMode.Acceleration);


       
        bulleter = null;

        
        




       
    }



}
