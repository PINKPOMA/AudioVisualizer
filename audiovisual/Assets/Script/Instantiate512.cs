using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Instantiate512 : MonoBehaviour
{
    public GameObject CPrefab;
    GameObject[] _Cube = new GameObject[512];
    public float _MXScale;
    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject _instanceC = (GameObject) Instantiate(CPrefab);
            _instanceC.transform.position = this.transform.position;
            _instanceC.transform.parent = this.transform;
            _instanceC.name = "Scube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            _instanceC.transform.transform.position = Vector3.forward * 100;
            _Cube[i] = _instanceC;
        }
    }
    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            if (_Cube != null)
            {
                _Cube[i].transform.localScale = new Vector3(10, (AudioManager.Music[i] * _MXScale) + 2, 10);
            }

        }
    }
}
