using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{
    
    public bool shopscreen;
    public GameObject shop1;
    public GameObject shopweapons;
    public GameObject shopmaps;
    public GameObject startmenu;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shopscreen == true)
        {
            startmenu.SetActive(false);
            shop1.SetActive(true);
        }
        if (shopscreen == false)
        {
            startmenu.SetActive(true);
            shop1.SetActive(false);
        }
    }
    public void OnEnableShop1()
    {
        shopscreen = true;
    }
    public void Done()
    {
        shop1.SetActive(false);
        startmenu.SetActive(true);
        shopscreen = false;

    }
    public void Startgame()
    {
        
    }
}

