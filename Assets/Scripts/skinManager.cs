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
    ItemManager ętemManager = new ItemManager();
    private void Start()
    {
        //ętemManager.save(_itemData);
        ętemManager.Load();
        _itemData = ętemManager.listeOpen();
    }

   
    
}
