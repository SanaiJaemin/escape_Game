using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NumberInput : MonoBehaviour
{
   
    public TextMeshProUGUI _textMeshProGUI;
    int number;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        _textMeshProGUI.text = null;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        _textMeshProGUI.text = $"{number}";
    }
    public void numpad1()
    {
        count++;
        number = 1;
        Debug.Log($"Å¬¸¯µÊ");
    }
  
    

}
