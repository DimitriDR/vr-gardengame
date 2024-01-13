using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu; 

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pauseMenu.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2f;
            pauseMenu.transform.rotation = Camera.main.transform.rotation;
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }

        if (pauseMenu.activeSelf)
        {
            // On bloque le joueur en mettant le temps à 0 :)
            Time.timeScale = 0;
        } else {
            // Ici, on remettra le temps à 1
            Time.timeScale = 1;
        }
    }
    
    public void ExitGame()
    {
        Application.Quit(0);
    }

    public void Continue()
    {
        pauseMenu.SetActive(false);
    }
}
