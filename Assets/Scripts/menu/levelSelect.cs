using demir;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelSelect : MonoBehaviour
{
    public Button[] buttons;
    public Sprite keyImage;

    public int level;

    dataManager _dataManager=new dataManager();

    private void Start()
    {
        _dataManager.dataSaveInt("LastLevel", level);

        int currentLevel = _dataManager.dataGetInt("LastLevel") - 2;

        Debug.Log(_dataManager.dataGetInt("LastLevel"));

        int _Index = 1;
        for (int i = 0; i < buttons.Length; i++)
        {
            if (_Index <= currentLevel)
            {
                buttons[i].GetComponentInChildren<Text>().text = (i + 1).ToString();

               

                buttons[i].onClick.AddListener(delegate { sceneUpload(_Index); });

            }
            else
            {
                buttons[i].GetComponent<Image>().sprite = keyImage;
                buttons[i].interactable = false;
            }
            _Index++;
        }
    }

    public void sceneUpload(int index)
    {
        SceneManager.LoadScene(index);
    }
}
