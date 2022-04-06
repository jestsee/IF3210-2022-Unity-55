using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameInput : MonoBehaviour
{
    private string theName;
    public GameObject inputField;
    public GameObject textDisplay;
    public GameObject labelText;
    public GameObject mainMenu;
    public GameObject nameInput;

    public void StoreName()
    {
        theName = inputField.GetComponent<Text>().text;

        // cek kosong ga
        if (string.IsNullOrEmpty(theName) || string.IsNullOrWhiteSpace(theName))
        {
            labelText.GetComponent<TextMeshProUGUI>().text = "Name cannot be empty!";
        } else
        {
            // direct ke main menu
            mainMenu.SetActive(true);
            nameInput.SetActive(false);

            textDisplay.GetComponent<TextMeshProUGUI>().text = "Welcome " + theName + "!";
        }
    }
}
