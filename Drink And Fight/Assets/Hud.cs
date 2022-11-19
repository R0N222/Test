using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hud : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titel;
    public void Init(string name)
    {
        titel.text = name;
    }


}
