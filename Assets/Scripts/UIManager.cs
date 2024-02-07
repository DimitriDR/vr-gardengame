using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject button;
    public AudioSource audioSource;
    public AudioClip hoverButtonSound;
    [SerializeField] private GameObject m_console;
    private InputDevice _inputDevice;
    
    void Start()
    {
        pauseMenu.SetActive(false);
        InputDeviceCharacteristics controllerCharacteristics =
            InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller;
        _inputDevice =
            InputDevices.GetDeviceAtXRNode(XRNode
                .LeftHand); // or XRNode.LeftHand, depending on which hand you want to use
    }

    void Update()
    {
        // InputFeatureUsage<bool> primary = CommonUsages.triggerButton;
        bool primary2DAxisClick = false;
        
        if (pauseMenu.activeSelf)
        {
            // On bloque le joueur en mettant le temps à 0 :)
            Time.timeScale = 0;
        }
        else
        {
            // Ici, on remettra le temps à 1
            Time.timeScale = 1;
        }
    }

    public void PauseGame()
    {
        var cameraMain = Camera.main.transform;
        pauseMenu.transform.position = cameraMain.position + cameraMain.forward * 4f;
        pauseMenu.transform.rotation = cameraMain.rotation;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }

    public void ExitGame()
    {
        Application.Quit(0);
    }
    
    public void Continue()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        
        button.GetComponent<Image>().color = new Color32(89, 89, 89, 255);
        button.GetComponentInChildren<Text>().color = new Color32(255, 255, 255, 255);
        
        Time.timeScale = 1;
    }

    public void buttonOnHover()
    {
        button.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        button.GetComponentInChildren<Text>().color = new Color32(89, 89, 89, 255);
    }

    public void buttonNotOnHover()
    {
        button.GetComponent<Image>().color = new Color32(89, 89, 89, 255);
        button.GetComponentInChildren<Text>().color = new Color32(255, 255, 255, 255);
    }

    public void PlayHoverButtonSound()
    {
        //audioSource.clip = hoverButtonSound;
        //audioSource.volume = 0.25f;
       // audioSource.Play();
        AudioManager.instance.PlaySFX(0);
    }

    public void ShowConsole()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        m_console.SetActive(!m_console.activeSelf);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("EnemiesSimulation");
    }
}