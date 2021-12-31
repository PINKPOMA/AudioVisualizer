using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCube : MonoBehaviour
{
    public int _band;
    public float SScale, scaleM;
    public bool _BufferU;
    void Start()
    {
        
    }
    
    void Update()
    {   
        transform.localScale = new Vector3(transform.localScale.x, (AudioManager._Buffer[_band] * scaleM) + SScale,
            transform.localScale.z);
        transform.localScale = new Vector3(transform.localScale.x, (AudioManager._freq[_band] * scaleM) + SScale,
            transform.localScale.z);
    }
}
