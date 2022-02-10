using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FormController : MonoBehaviour
{
    [SerializeField] private TMP_InputField firstName;
    [SerializeField] private TMP_InputField lastName;
    [SerializeField] private TMP_InputField email;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TMP_Text errorText;

    public void OnSubmit()
	{
        errorText.text = "";

        if (string.IsNullOrEmpty(firstName.text) || string.IsNullOrEmpty(lastName.text))
		{
            errorText.text = "Please enter a first and last name!";
            return;
		}
        string nametxt = $"{firstName.text} {lastName.text}";
        
        if(!email.text.Contains("@") || !email.text.Contains("."))
		{
            errorText.text = "Please enter a valid email address!";
            return;
        }
        string emailtxt = email.text;

        if(password.text.Length < 6)
		{
            errorText.text = "Password should be at least 6 characters long!";
            return;
        }
        string pwtxt = password.text;

        Debug.Log($"User created: {nametxt}, {emailtxt} : {pwtxt}");
        PlayerPrefs.SetString("data", $"{ nametxt}, { emailtxt} : { pwtxt}");
        SceneManager.LoadScene("2.3.1");
	}

    public void Clear()
	{
        firstName.text = "";
        lastName.text = "";
        email.text = "";
        password.text = "";
    }
}
