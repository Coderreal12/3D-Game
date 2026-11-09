using System.Transactions;
using UnityEngine;
using UnityEngine.InputSystem;

public class Go_To : MonoBehaviour
{

    [Header("Min (Less than 0) /Max (Greater than 0)")]

    [SerializeField] private float Min;
    [SerializeField] private float Max;

    [Header("Random")]
    [SerializeField] private float offset;
    [SerializeField] private Transform player;

    [Header("Scripts")]
    [SerializeField] private PickUP Holding;

    private float scrolldis = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Holding.pickup)
        {
Move();
        }
        else
        {
            transform.Translate(new Vector3(-1 * scrolldis, 0, 0));
                scrolldis = 0;
        }
        

    }

    private void Move()
    {
        scrolldis += Input.mouseScrollDelta.y;


        
        transform.Translate(new Vector3(1 * Input.mouseScrollDelta.y, 0, 0) );

        if (scrolldis > Min)
        {
            scrolldis--;
            transform.Translate(new Vector3(-1, 0, 0));
            if (scrolldis == Min)
            {
                scrolldis = Min;
            }
        }


        if (scrolldis <= Max)
        {
            scrolldis++;
            transform.Translate(new Vector3(1, 0, 0));

            if (scrolldis == Max)
            {
                scrolldis = Max;
            }
        }



      
    }
         


}
