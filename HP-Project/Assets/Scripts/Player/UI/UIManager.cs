using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Objects to Disable on UI Change")]
    public GameObject inventory;
    public PlayerController controller;
    public GameObject hotbar;
    public GameObject wand;
    
    //[SerializeField]
    //public GameObject pauseMenu;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            } else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            controller.enabled = !controller.enabled;
            inventory.SetActive(!inventory.activeSelf);
        }
    }
}
