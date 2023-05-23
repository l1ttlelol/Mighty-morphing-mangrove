using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCheckpoint : MonoBehaviour
{
    public GameObject WinScreen;
    public GameObject Tips;
    public Button FirstButtonSelect;

    // Start is called before the first frame update
    void Start()
    {
        WinScreen.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            WinScreen.SetActive(true);
            Tips.SetActive(false);
            FirstButtonSelect.Select();
        }
    }
}
