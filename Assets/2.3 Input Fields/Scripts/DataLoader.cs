using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataLoader : MonoBehaviour
{
    [SerializeField] private TMP_Text txt;

    void Start()
    {
        txt.text = PlayerPrefs.GetString("data", "No data found!");
    }
}
