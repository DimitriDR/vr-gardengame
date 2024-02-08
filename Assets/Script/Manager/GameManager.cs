using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject garden;
    [SerializeField] private GameObject Menu;
    private WaveManager waveManager = WaveManager.instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckGardenDestroyed()
    {
        if(garden.GetComponent<Garden>().GetLife() == 0)
        {
            Debug.Log("Finishe");
            Console.Instance.AddLine("finished");
        }
    }

    public void CheckGameOver()
    {
        
         Time.timeScale = 0;
         Menu.SetActive(true);
         Console.Instance.AddLine("GameOver");
        
    }
}
