using UnityEngine;

public class Destroy_Self : MonoBehaviour
{
    private float time;
    bool e;
    private void OnCollisionEnter(Collision collision)
    {
        e = true;
       
    }


    private void Update()
    {
        if (e == true)
        {
time += Time.deltaTime;
        if (time >= 1)
        {
 Destroy(gameObject);
        }
        }
        

    }


}
