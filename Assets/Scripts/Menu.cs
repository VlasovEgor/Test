using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject PauseButton;
    [SerializeField] private GameObject ShildButton;
    [SerializeField] private GameObject MenuWindow;
    [SerializeField] private Animator _animator;
    public void OpenMenuWindow()
    {
        PauseButton.SetActive(false);
        ShildButton.SetActive(false);
        MenuWindow.SetActive(true);
        Time.timeScale = 0.01f;
        _animator.SetBool("IsOpened", true);
    }
    public void CloseMenuWindow()
    {
        _animator.SetBool("IsOpened", false);
        PauseButton.SetActive(true);
        ShildButton.SetActive(true);
        MenuWindow.SetActive(false);
        Time.timeScale =1;
        
    }
    public void ExitingTheGame()
    {
        Application.Quit();
    }
}
