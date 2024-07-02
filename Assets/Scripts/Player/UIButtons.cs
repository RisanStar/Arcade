using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public void Retry()
    {
       SceneManager.LoadScene("Lvl 3D"); 
    }

    public void MainMenu()
    {
        Application.Quit();
    }
}
