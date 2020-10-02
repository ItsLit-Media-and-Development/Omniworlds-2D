﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI nameText;
    public GameObject dialogBox;
    public GameObject nameBox;
    public string[] dialogLines;
    public int currentLine;
    private bool justStarted;
    public static DialogManager instance;
    
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (!justStarted)
                {
                    currentLine++;

                    if (currentLine >= dialogLines.Length)
                    {
                        dialogBox.SetActive(false);

                        GameManager.instance.dialogActive = false;
                    }
                    else
                    {
                        CheckIfName();
                        dialogText.text = dialogLines[currentLine];
                    }
                }
                else
                {
                    justStarted = false;
                }
            }
        }
    }

    public void ShowDialog(string[] newLines, bool isPerson)
    {
        dialogLines = newLines;

        currentLine = 0;

        CheckIfName();

        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);

        justStarted = true;
        nameBox.SetActive(isPerson);

        GameManager.instance.dialogActive = true;
    }

    public void CheckIfName()
    {
        //If the first line starts with n- then we know that line is the name
        if (dialogLines[currentLine].StartsWith("n-"))
        {
            //assign to the name box text and remove the n- from the start
            nameText.text = dialogLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }
    
    
}
