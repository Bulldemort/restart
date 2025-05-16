using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Jobs;

public class UIcontroller : MonoBehaviour
{
    
    public bool shopscreen;
    public GameObject shop1;
    public GameObject shopmaps;
    public GameObject startmenu;
    public GameObject controlsScreen;
    public GameObject weaponShop;
    

    void Start()
    {
        shopmaps.SetActive(false);
        shop1.SetActive(false);
        startmenu.SetActive(true);
        controlsScreen.SetActive(false);
        weaponShop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnEnableShop1()
    {
        shopmaps.SetActive(false);
        shop1.SetActive(true);
        startmenu.SetActive(false);
        controlsScreen.SetActive(false);
        weaponShop.SetActive(false);
    }
    public void Done()
    {
        shopmaps.SetActive(false);
        shop1.SetActive(false);
        startmenu.SetActive(true);
        controlsScreen.SetActive(false);
        weaponShop.SetActive(false);
    }
    public void Startgame()
    {
        SceneManager.LoadScene("map 1");
    }
    public void Controls()
    {
        shopmaps.SetActive(false);
        shop1.SetActive(false);
        startmenu.SetActive(false);
        controlsScreen.SetActive(true);
        weaponShop.SetActive(false);
    }
    public void Weapons()
    {
        shopmaps.SetActive(false);
        shop1.SetActive(false);
        startmenu.SetActive(false);
        controlsScreen.SetActive(false);
        weaponShop.SetActive(true);
    }
    public void Maps()
    {
        shopmaps.SetActive(true);
        shop1.SetActive(false);
        startmenu.SetActive(false);
        controlsScreen.SetActive(false);
        weaponShop.SetActive(false);
    }
}

