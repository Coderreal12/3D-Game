
using UnityEngine;






public class FlashLight : MonoBehaviour
{
    RaycastHit hit;
    private Transform temptransform;
    private Rigidbody temprigid;
    private bool HoldingFlash = false;
    [SerializeField] private Transform Flash;

    void Update()
    {
        if (HoldingFlash == false)
        {
        Raycast();
       
           
        }
        else
        {
Hold();
        }
            

    }


    private void Raycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        if (Physics.Raycast(ray, out hit, 3f, LayerMask.GetMask("Flashlight")) && Input.GetMouseButtonDown(1))
        {

            Hitinfo();
            
            HoldingFlash = true;
        }
    }




    private void Hitinfo()
    {
temptransform = hit.collider.GetComponent<Transform>();
            temprigid = hit.collider.GetComponent<Rigidbody>();
        
        temptransform.position = Flash.position;
       


        temprigid.isKinematic = true;
        
    }



    private void Hold()
    {


        temptransform.SetParent(Camera.main.transform);
        temptransform.rotation = Flash.rotation;





    }



}
