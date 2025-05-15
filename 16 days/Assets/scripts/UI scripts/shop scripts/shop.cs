using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shop : MonoBehaviour
{
    // Start is called before the first frame update
    public bool shopscreen = false;
    void Start()
    {
        shopscreen = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnEnable()
    {
        shopscreen = true;
    }
}
