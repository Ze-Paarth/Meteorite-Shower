// BGMCtrl

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMCtrl : MonoBehaviour
{
    public static BGMCtrl BGMStatic;

    void Awake()
    {
        if (BGMStatic == null)
        {
            BGMStatic = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
////////////////////////////////////////////////////////////////////////////////
