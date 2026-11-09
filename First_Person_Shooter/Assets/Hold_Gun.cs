using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class detect_Gun : MonoBehaviour
{
    [SerializeField] PickUP Script;
    [SerializeField] private Transform GunPos;
    [SerializeField] private Vector3 offset;

    //TempVariables
    private Transform TempTransform;
    private Rigidbody TempRigid;
    private Collider[] TempCollider;

    //Vector 3
private Vector3 distance;


    //Variables
public bool detect = false;
private float maxdis;
    private bool Holding = false;
   
    //Raycasts
private RaycastHit Hit;

    //scripts
    

    void Update()
    {
      

        if (Camera.main.transform.position == transform.position)
        {
           
            GunPos.SetParent(Camera.main.transform);
        }
        
        send();
        Hitinfo();
        Hold_Gun();

    }



    private void send()
    { 
        maxdis = Script.Show();
       

        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

       

        if(Physics.Raycast(ray, out Hit, maxdis, LayerMask.GetMask("Gun")) && Input.GetKeyDown(KeyCode.E) && Script.pickup == false && Holding == false)
        {
            detect = true;
        }
        else 
          {
            detect = false;
        }

            Debug.DrawRay(ray.origin,ray.direction * maxdis,Color.red);

    }


    private void Hitinfo()
    {

        if (detect)
        {

            TempTransform = Hit.collider.gameObject.transform;
            TempRigid = Hit.collider.attachedRigidbody;
            TempCollider = Hit.collider.gameObject.GetComponentsInChildren<Collider>();
            
            

            TempTransform.eulerAngles = new Vector3(0, 0, 0);
            

            Holding = true;

            
    
        }
       

    }

    private void Hold_Gun()
    {
        if (Holding)
        {
            foreach(Collider coll in TempCollider)
            {
                coll.enabled = false;
            }
            
            TempRigid.isKinematic = true;

            TempTransform.rotation = GunPos.rotation;
            TempTransform.position = GunPos.position;
            TempTransform.SetParent(GunPos);

            
            
            
           


        }
        if (Holding && Input.GetKeyDown(KeyCode.F))
        {
            TempRigid.isKinematic = false;
            TempTransform.position = TempTransform.position;
            TempTransform.parent = null;
            foreach (Collider coll in TempCollider)
            {
                coll.enabled = true;
            }

            TempRigid = null;
            TempTransform = null;
            Holding = false;

        }
    }
    // Quaternion(-0.502286553,0.628397048,0.449171573,0.388677597) Vector3(-0.540014625,-0.255387723,0.913473129)
}
