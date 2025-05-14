using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcontroller : MonoBehaviour
{
    [SerializeField] controlsscreen control;
    public shop shop;
    public start start;
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
        if(shop.shopscreen == true)
        {
            startmenu.SetActive(false);
            shop1.SetActive(true);
        }
    }
}
