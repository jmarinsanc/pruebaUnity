using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System;

public class MenuController : MonoBehaviour
{
    UIDocument menu;
    Button playButton;
    Button exitButton;


    public void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        VisualElement root = menu.rootVisualElement;

        playButton = root.Q<Button>("play");
        exitButton= root.Q<Button>("exit");


        //callbacks
        playButton.RegisterCallback<ClickEvent>(loadForestScene);
        exitButton.RegisterCallback<ClickEvent>(exitgame);

    }

    private void exitgame(ClickEvent evt)
    {
        Application.Quit();
    }

    private void loadForestScene(ClickEvent evt)
    {
        SceneManager.LoadSceneAsync("Forest");
    }



}
