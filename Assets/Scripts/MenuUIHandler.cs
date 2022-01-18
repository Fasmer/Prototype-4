using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUiHandler : MonoBehaviour
{
    [SerializeField] InputField playerNameInput;
    [SerializeField] Text errorMessage;
    private string m_playerName = "";
    public string PlayerName // ENCAPSULATION
    {
        get { return m_playerName; }
        set
        {
            if (value.Length <= 0)
            {
                errorMessage.gameObject.SetActive(true);
                StartCoroutine("ErrorMessage");
            }
            else
            {
                m_playerName = value;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (GetPlayerName()) // ABSTRACTION
            {
                SceneManager.LoadScene(1);
            }
        }

    }

    private bool GetPlayerName()
    {
        PlayerName = playerNameInput.text;
        MainManager.Instance.PlayerName = PlayerName;
        if (PlayerName.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator ErrorMessage()
    {
        yield return new WaitForSeconds(3);
        errorMessage.gameObject.SetActive(false);
    }
}
