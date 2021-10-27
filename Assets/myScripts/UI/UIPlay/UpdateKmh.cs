using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UpdateKmh : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI txtKmh;
    private float kmh;


    private void Start()
    {
        txtKmh = GetComponent<TextMeshProUGUI>();
        
        
        CapNhatTocDo(0);
    }

    private void Update()
    {
        if (MyPlayer.instance != null)
        { 
            MyPlayer.instance.updateKmh.AddListener(CapNhatTocDo);
        }
        
    }
    private void CapNhatTocDo(float _kmh)
    {
        kmh += _kmh;
        txtKmh.text = $"{kmh*0.1f} Km/h";
    }

}
