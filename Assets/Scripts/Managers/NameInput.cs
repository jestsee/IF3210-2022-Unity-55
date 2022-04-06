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
            textDisplay.GetComponent<TextMeshProUGUI>().text = "Welcome " + theName + "!";
            
            PlayerPrefs.SetString("name", theName);
            PlayerPrefs.Save();

            // direct ke main menu
            mainMenu.SetActive(true);
            nameInput.SetActive(false);
        }
    }

    private void Start()
    {
        Debug.Log("Start in NameInput is called");
        theName = PlayerPrefs.GetString("name");
        if (string.IsNullOrEmpty(theName) || string.IsNullOrWhiteSpace(theName))
        {
            nameInput.SetActive(true);
            mainMenu.SetActive(false);
        } else
        {
            mainMenu.SetActive(true);
            nameInput.SetActive(false);

            textDisplay.GetComponent<TextMeshProUGUI>().text = "Hi " + theName + "!";
        }
    }
}
