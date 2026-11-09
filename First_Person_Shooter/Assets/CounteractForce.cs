using UnityEngine;
using UnityEngine.Rendering;

public class CounteractForce : MonoBehaviour
{
    public bool swi;
    private void OnCollisionEnter(Collision collision)
    {
        swi = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        swi = false;
    }
}
