using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NumberInput : MonoBehaviour
{
   
    public TextMeshProUGUI _textMeshProGUI;
    [HideInInspector] public bool Clear = false;
    public GameObject KeyPadUi;
    private string ClearNumber = "7475";
    private int MaxIndex = 4;
    private int count = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Clear = false;
        
        Cursor.visible = true;
       

    }

    // Update is called once per frame
    public void numpad0()
    {
        if(count < MaxIndex)
        {
        _textMeshProGUI.text += "0";
        count++;
        }
    }
    public void numpad1()
    {
        if (count < MaxIndex)
        {
            _textMeshProGUI.text += "1";
            count++;
        }
    }
    public void numpad2()
    {
        if (count < MaxIndex)
        {
            _textMeshProGUI.text += "2";
            count++;
        }
    }
    public void numpad3()
    {
        if (count < MaxIndex)
        {
            _textMeshProGUI.text += "3";
            count++;
        }
    }
    public void numpad4()
    {
        if(count < MaxIndex)
        {
            _textMeshProGUI.text += "4";
            count++;
        }
    }
    public void numpad5()
    {
        if (count < MaxIndex)
        {
            _textMeshProGUI.text += "5";
            count++;
        }
    }
    public void numpad6()
    {
        if (count < MaxIndex)
        {
            _textMeshProGUI.text += "6";
            count++;
        }
    }
    public void numpad7()
    {
        if (count < MaxIndex)
        {
            _textMeshProGUI.text += "7";
            count++;
        }
    }
    public void numpad8()
    {
        if (count < MaxIndex)
        {
            _textMeshProGUI.text += "8";
            count++;
        }
    }
    public void numpad9()
    {
        if (count < MaxIndex)
        {
            _textMeshProGUI.text += "9";
            count++;
        }
    }
    public void numEmpty()
    {
        _textMeshProGUI.text = null;
        count = 0;

    }
    public void confirmation()
    {
        if (_textMeshProGUI.text == ClearNumber)
        {
            _textMeshProGUI.text = "Clear";
            Clear = true;


        }
        else
        {
            _textMeshProGUI.text = "Error";
            Clear = false;
            count = 0;
        }
    }
    public void Exit()
    {
        _textMeshProGUI.text = null;
        KeyPadUi.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    



}
