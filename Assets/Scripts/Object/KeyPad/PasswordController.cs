using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

enum PasswordKeys
{
    clear = 10,
    delete
}

public class PasswordController : MonoBehaviour
{
    public static event Action PasswordUnlock = delegate { };

    [SerializeField] private TextMeshPro ScreenText;


    public static bool IsGameWin;
    private string CorrectNum;
    private AudioSource audioSource;

    private void Awake()
    {
        IsGameWin = false;
        CorrectNum = "4678";
        PasswordKey.KeypadSignal += ShowPasswordOnScreen;
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Start()
    {
        ScreenText.text = "0";
    }

    string keyStr = "";
    private void ShowPasswordOnScreen(int key)
    {
        if (false == IsGameWin)
        {
            if (key == (int)PasswordKeys.clear)
            {
                ScreenText.text = "0";
            }

            else if (key == (int)PasswordKeys.delete)
            {
                if (ScreenText.text.Length == 1)
                {
                    ScreenText.text = "0";
                    return;
                }

                if (keyStr == "0")
                {
                    return;
                }
                else
                {
                    ScreenText.text = ScreenText.text.Substring(0, ScreenText.text.Length - 1);
                }
            }

            else
            {
                keyStr = key.ToString();

                if (ScreenText.text == "0")
                {
                    ScreenText.text = "";
                    ScreenText.text += keyStr;
                }
                else
                {
                    ScreenText.text += keyStr;
                }
            }

            if (ScreenText.text == CorrectNum)
            {
                IsGameWin = true;
                PasswordUnlock();
              
                Debug.Log("���ӿ��� �¸��ϼ̽��ϴ�.");
                return;
            }

            if (ScreenText.text.Length == 5)
            {
                ScreenText.text = "0";
                return;
            }
        }
    }

    float lightingDuration = 1f;
  
}
