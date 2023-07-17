using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


namespace demir
{
    public class mathLibrary
    {
        public void multiplication(int number, List<GameObject> heros, Transform pos, List<GameObject> heroCreatEffect)
        {
            int royaleNumber = (gameManager.liveHero * number) - gameManager.liveHero;

            int numb = 0;

            foreach (var item in heros)
            {
                if (numb < royaleNumber)
                {
                    if (!item.activeInHierarchy)
                    {
                        foreach (var item2 in heroCreatEffect)
                        {
                            if (!item2.activeInHierarchy)
                            {
                                item2.SetActive(true);
                                item2.transform.position = pos.position;
                                item2.GetComponent<ParticleSystem>().Play();
                                //item2.GetComponent<AudioSource>().Play();
                                break;
                            }
                        }

                        item.transform.position = pos.position;
                        item.SetActive(true);
                        numb++;
                    }
                }
                else
                {
                    numb = 0;
                    break;
                }
            }

            gameManager.liveHero *= number;
        }

        public void add(int number, List<GameObject> heros, Transform pos, List<GameObject> heroCreatEffect)
        {
            int numb2 = 0;

            foreach (var item in heros)
            {
                if (numb2 < number)
                {
                    if (!item.activeInHierarchy)
                    {
                        foreach (var item2 in heroCreatEffect)
                        {
                            if (!item2.activeInHierarchy)
                            {
                                item2.SetActive(true);
                                item2.transform.position = pos.position;
                                item2.GetComponent<ParticleSystem>().Play();
                                //item2.GetComponent<AudioSource>().Play();

                                break;
                            }
                        }

                        item.transform.position = pos.position;
                        item.SetActive(true);
                        numb2++;
                    }
                    else
                    {
                        numb2 = 0;
                        break;
                    }
                }
            }

            gameManager.liveHero += number;

        }

        public void extraction(int number, List<GameObject> heros, List<GameObject> heroDeadEffect)
        {
            if (gameManager.liveHero < number)
            {
                foreach (var item in heros)
                {
                    foreach (var item2 in heroDeadEffect)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            Vector3 newPos = new Vector3(item.transform.position.x, .23f, item.transform.position.z);



                            item2.SetActive(true);
                            item2.transform.position = newPos;
                            item2.GetComponent<ParticleSystem>().Play();
                            break;
                        }
                    }



                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                gameManager.liveHero = 1;
            }
            else
            {
                int numb3 = 0;
                foreach (var item in heros)
                {
                    if (numb3 != number)
                    {

                        if (item.activeInHierarchy)
                        {
                            foreach (var item2 in heroDeadEffect)
                            {
                                if (!item2.activeInHierarchy)
                                {

                                    Vector3 newPos = new Vector3(item.transform.position.x, .23f, item.transform.position.z);


                                    item2.SetActive(true);
                                    item2.transform.position = newPos;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    break;
                                }
                            }


                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            numb3++;

                        }
                        else
                        {
                            numb3 = 0;
                            break;
                        }

                    }
                    gameManager.liveHero -= number;
                }
            }

        }

        public void division(int number, List<GameObject> heros, List<GameObject> heroDeadEffect)
        {
            if (gameManager.liveHero <= number)
            {
                foreach (var item in heros)
                {
                    foreach (var item2 in heroDeadEffect)
                    {
                        if (!item2.activeInHierarchy)
                        {

                            Vector3 newPos = new Vector3(item.transform.position.x, .23f, item.transform.position.z);


                            item2.SetActive(true);
                            item2.transform.position = newPos;
                            item2.GetComponent<ParticleSystem>().Play();
                            break;
                        }
                    }

                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                gameManager.liveHero = 1;
            }
            else
            {
                int bolen = gameManager.liveHero / number;

                int numb3 = 0;
                foreach (var item in heros)
                {
                    if (numb3 != bolen)
                    {
                        if (item.activeInHierarchy)
                        {
                            foreach (var item2 in heroDeadEffect)
                            {
                                if (!item2.activeInHierarchy)
                                {

                                    Vector3 newPos = new Vector3(item.transform.position.x, .23f, item.transform.position.z);


                                    item2.SetActive(true);
                                    item2.transform.position = newPos;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    break;
                                }
                            }

                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            numb3++;

                        }
                        else
                        {
                            numb3 = 0;
                            break;
                        }
                    }
                }
            }

            if (gameManager.liveHero % number == 0)
            {
                gameManager.liveHero /= number;
            } else if (gameManager.liveHero % number == 1)
            {
                gameManager.liveHero /= number;
                gameManager.liveHero++;
            } else if (gameManager.liveHero % number == 2)
            {
                gameManager.liveHero /= number;
                gameManager.liveHero += 2;
            }

        }





    }

    public class dataManager
    {
        public void dataSaveString(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
            PlayerPrefs.Save();
        }
        public void dataSaveInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.Save();
        }
        public void dataSaveFloat(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
            PlayerPrefs.Save();
        }

        public string dataGetString(string key)
        {
            return PlayerPrefs.GetString(key);
        }
        public int dataGetInt(string key)
        {
            return PlayerPrefs.GetInt(key);
        }
        public float dataGetFloat(string key)
        {
            return PlayerPrefs.GetFloat(key);
        }

        public void checkitAndSet()
        {
            if (!PlayerPrefs.HasKey("LastLevel"))
            {
                PlayerPrefs.SetInt("LastLevel", 3);
                PlayerPrefs.SetInt("Puan", 100);

            }
        }

    }
}
public class mydata
{
    public static List<itemData> _itemData = new List<itemData>();

}

[Serializable]
public class itemData
{
    public int grupIndex;
    public int ItemIndex;
    public string ItemAd;
    public int puan;
    public bool satinAlmaDurumu;
}

public class ItemManager
{
    public void save(List<itemData> _itemData)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.OpenWrite(Application.persistentDataPath + "/Itemdata.gd");
        bf.Serialize(file, _itemData);
        file.Close();
    }

    public void firstTimeSave(List<itemData> _itemData)
    {
        if (!File.Exists(Application.persistentDataPath + "/Itemdata.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/Itemdata.gd");
            bf.Serialize(file, _itemData);
            file.Close();
        }
    }

    List<itemData> _itemData2;
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/Itemdata.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Itemdata.gd", FileMode.Open);
            _itemData2 = (List<itemData>)bf.Deserialize(file);
            file.Close();

            Debug.Log(_itemData2[1].ItemAd);
        }
    }

    public List<itemData> listeOpen()
    {

        return _itemData2;
    }
}
