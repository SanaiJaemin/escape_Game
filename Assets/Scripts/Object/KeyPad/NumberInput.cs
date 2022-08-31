using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NumberInput : MonoBehaviour
{
   
    public TextMeshProUGUI _textMeshProGUI;
    [HideInInspector] public bool Clear = false;
    public GameObject KeyPadUi;
    private string ClearNumber = "7375";
    
    // Start is called before the first frame update
    void Start()
    {
        Clear = false;
        _textMeshProGUI.text = null;
        Cursor.visible = true;
        
    }

    // Update is called once per frame
    public void numpad0()
    {
        _textMeshProGUI.text += "0";

    }
    public void numpad1()
    {
        _textMeshProGUI.text += "1";
        
    }
    public void numpad2()
    {
        _textMeshProGUI.text += "2";

    }
    public void numpad3()
    {
        _textMeshProGUI.text += "3";
    }
    public void numpad4()
    {
        _textMeshProGUI.text += "4";

    }
    public void numpad5()
    {
        _textMeshProGUI.text += "5";
    }
    public void numpad6()
    {
        _textMeshProGUI.text += "6";

    }
    public void numpad7()
    {
        _textMeshProGUI.text += "7";
    }
    public void numpad8()
    {
        _textMeshProGUI.text += "8";

    }
    public void numpad9()
    {
        _textMeshProGUI.text += "9";
    }
    public void numEmpty()
    {
        _textMeshProGUI.text = null;
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
        }
    }
    public void Exit()
    {
        KeyPadUi.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    



}
