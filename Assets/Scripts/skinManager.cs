using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using demir;

public class skinManager : MonoBehaviour
{
    public GameObject[] sapka;
    public GameObject[] sopa;

    public  List<itemData> _itemData = new List<itemData>();

    dataManager dataManager=new dataManager();
    ItemManager �temManager = new ItemManager();
    private void Start()
    {
        //�temManager.save(_itemData);
        �temManager.Load();
        _itemData = �temManager.listeOpen();
    }

   
    
}
