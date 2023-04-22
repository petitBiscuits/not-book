using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuManagerMB : MonoBehaviour
{
    [SerializeField]
    private UIDocument document;

    private Button _btnStart;
    private Button _btnQuit;

    void Awake()
    {
        _btnStart = document.rootVisualElement.Q<Button>("start");
        _btnQuit = document.rootVisualElement.Q<Button>("quit");
    }

    private void OnEnable()
    {
        _btnStart.clicked += OnStartClicked;
        _btnQuit.clicked += OnQuitClicked;
    }

    private void OnDisable()
    {
        _btnStart.clicked -= OnStartClicked;
        _btnQuit.clicked -= OnQuitClicked;
    }

    private void OnStartClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void OnQuitClicked()
    {
        Application.Quit();
    }


}
