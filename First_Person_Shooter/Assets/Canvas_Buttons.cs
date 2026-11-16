using UnityEngine;
using UnityEngine.SceneManagement;
public class Canvas_Buttons : MonoBehaviour
{
    int FirstLevel = 0;



    public void Respawn()
    {
        SceneManager.LoadScene(FirstLevel);
    }
}
