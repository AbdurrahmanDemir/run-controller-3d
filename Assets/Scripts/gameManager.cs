using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using demir;

public class gameManager : MonoBehaviour
{
    public GameObject spawmPas;
    public GameObject heroPos;
    public static int liveHero=1; //hero sayýmýz
    public List<GameObject> heroList;
    public List<GameObject> heroCreatParticleList;
    public List<GameObject> heroDeadParticleList;

    [Header("Level Settings")]
    public List<GameObject> enemyList;
    public int numberEnemy; //leveldeki enemy sayýsý
    public bool gameOver;

    mathLibrary _math= new mathLibrary();
    dataManager _dataManager= new dataManager();

    private void Start()
    {
        enemyCreat();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (var hero in heroList)
            {
                if (!hero.activeInHierarchy)
                {
                    hero.transform.position = spawmPas.transform.position;
                    hero.SetActive(true);
                    liveHero++;
                    break;
                }
            }
        }
    }

    public void battleStatus()
    {
        if (liveHero == 1 )
        {
            gameOver = true;

            if (liveHero < numberEnemy || liveHero == numberEnemy)
            {
                Debug.Log("you lost");

            }
            else
            {
                Debug.Log("you win");
            }
        }


    }

    public void heroControl(string type, int number, Transform pos)
    {
        switch (type)
        {
            case "add":
                _math.add(number, heroList, pos, heroCreatParticleList);

                break;
            case "multiplication":
                _math.multiplication(number, heroList, pos, heroCreatParticleList);
                break;
            case "division":
                _math.division(number, heroList, heroDeadParticleList);

                break;
            case "extraction":
                _math.extraction(number, heroList, heroDeadParticleList);

                break;


        }
    }

    public void heroDeadParcile(Vector3 pos, bool whichCharac=false)
    {
        foreach (var item in heroDeadParticleList)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position=pos;
                if (!whichCharac)
                    liveHero--;
                else
                    numberEnemy--;
                item.GetComponent<ParticleSystem>().Play();
                break;
            }
        }
        if(!gameOver)
          battleStatus();
    }

    public void enemyCreat()
    {
        for (int i = 0; i < numberEnemy; i++)
        {
            enemyList[i].SetActive(true);
        }
    }

    public void enemyAttack()
    {
        foreach (var item in enemyList)
        {
            if (item.activeInHierarchy)
            {
                item.GetComponent<enemyController>().animationStart();
            }
        }
        battleStatus();

    }
}
