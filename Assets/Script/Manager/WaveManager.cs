using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    [SerializeField] private Transform[] _spotAppearEnemy;
    [SerializeField] private GameObject[] _enemiesPrefab;
    [SerializeField] private int _nbrIninialEnemy = 5;
    [SerializeField] private int _nbrStepEnemyAfterWave = 3;
    [SerializeField] private int _nbrTotalWave = 3;
    private int nbrEnemy;
    private int nbrCurrentEnemy;
    private int nbrCurrentWave = 1;
    private bool canAppear = true;

    // Start is called before the first frame update
    void Start()
    {
        nbrEnemy = _nbrIninialEnemy;
        nbrCurrentEnemy = 0;

        
    }

    // Update is called once per frame
    void Update()
    {
       if(canAppear)
        {
            int indexEnemy = Random.Range(0, _enemiesPrefab.Length);
            int indexSpot = Random.Range(0, _spotAppearEnemy.Length);
            Instantiate(_enemiesPrefab[indexEnemy], _spotAppearEnemy[indexSpot].position, Quaternion.identity);
            nbrCurrentEnemy++;
            if(nbrCurrentEnemy == nbrEnemy)
            {
                canAppear = false;
            }
        }

       if(canAppear == false && nbrCurrentEnemy == 0)
        {
            Invoke("NextWave", 10.0f);
        }
    }

    public void WaveEnemies()
    {
        if (nbrCurrentWave != _nbrTotalWave)
        {
            Debug.Log("wave");
            Invoke("NextWave", 10.0f);
           
            if(this.canAppear == true)
            {
                for (int i = 0; i < nbrEnemy; i++)
                {
                    Debug.Log("TRaitement");
                    int indexEnemy = Random.Range(0, _enemiesPrefab.Length);
                    int indexSpot = Random.Range(0, _spotAppearEnemy.Length);
                    Instantiate(_enemiesPrefab[indexEnemy], _spotAppearEnemy[indexSpot].position, Quaternion.identity);
                }
                nbrEnemy += _nbrStepEnemyAfterWave;
                nbrCurrentWave++;
            }
        }
    }

    public bool CheckEmptyEnemies()
    {
        if (nbrCurrentEnemy != 0)
        {
            this.canAppear = false;
        }
        return nbrCurrentEnemy == 0;
    }

    public void NextWave()
    {
        nbrEnemy += _nbrStepEnemyAfterWave;
        nbrCurrentEnemy = nbrEnemy;
        this.canAppear = true;
        if (nbrCurrentWave < _nbrTotalWave) 
        {
            nbrCurrentWave++;
        }
       
    }

    public void decrementCurrentEnemyNbr()
    {
        nbrCurrentEnemy--;
    }

    public int GetCurrentWave()
    {
        return nbrCurrentWave;
    }

    public int GetCurrentEnemiesNbr()
    {
        return nbrCurrentEnemy;
    }

    public int GetTotalNbrWave()
    {
        return _nbrTotalWave;
    }
}
