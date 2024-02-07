using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Garden : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private int maxLife = 100;
    [SerializeField] Slider lifeBar;

    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;
        lifeBar.value = life;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateLifeBar();
    }

    public void GetHit(int hit)
    {
        life -= hit;
        if (life < 0)
        {
            life = 0;
        }
    }

    public void GetRestoration(int restoration)
    {
        if (life != maxLife)
        {
            life += restoration;
        }
    }

    private void UpdateLifeBar()
    {
        lifeBar.value = life;
    }

    public int GetLife()
    {
        return life;
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("heere");
        if(life == maxLife) 
        {
            life = maxLife;
        }
        else
        {
            life += 1;
        }
        Debug.Log(life);
    }

    private void OnParticleTrigger()
    {
        
        
    }
}
