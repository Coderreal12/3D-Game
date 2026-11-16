
using UnityEngine;
using TMPro;




public class Die : MonoBehaviour
{
        [SerializeField] GameObject deathscreen;
    [SerializeField] private Player_Controller controller;
    [SerializeField] GameObject WinScreen;
    [SerializeField] private Chase_Player npc;

    [SerializeField] private TextMeshProUGUI time;
    private float equa;
    bool alive = true;
    private void Start()
    {
        Time.timeScale = 1;
        deathscreen.SetActive(false);
    }


    private void Update()
    {
        equa += Time.deltaTime;
        if (alive)
        {
time.SetText("Time: " + equa);
        }
        else
        {
            time.SetText("Final Time: " + equa); 
        }    
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Kill"))
        {
            Time.timeScale = 0;
            controller.Die();
                deathscreen.SetActive(true);
            npc.NPC_Speed = 0f;
        }

        if(collision.collider.CompareTag("Win"))
        {
            alive = false;
            Time.timeScale = 0;
            controller.Die();
            WinScreen.SetActive(true);
            npc.NPC_Speed = 0f;
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Kill"))
        {
            Time.timeScale = 0;
            controller.Die();
            deathscreen.SetActive(true);
        }
    }


    

}




