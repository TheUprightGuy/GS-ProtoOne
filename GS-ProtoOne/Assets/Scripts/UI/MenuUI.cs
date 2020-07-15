﻿using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuUI : MonoBehaviour
{
    public GameObject menuLayout;
    public GameObject optionsCanvas;
    [Header("First selected gameObjects")] 
    public GameObject menuFirstSelected;
    public GameObject optionsFirstSelected;
    
    private bool _viewingOptionsMenu;
    private EventSystem _eventSystem;
    public void Awake()
    {
        _eventSystem = EventSystem.current;
        _viewingOptionsMenu = false;
    }

    public void ToggleOptionsCanvas()
    {
        _viewingOptionsMenu = !_viewingOptionsMenu;
        if (_eventSystem != null && menuFirstSelected != null && optionsFirstSelected != null)
        {
            _eventSystem.SetSelectedGameObject(_viewingOptionsMenu ? optionsFirstSelected : menuFirstSelected);
        }
        if (optionsCanvas != null) optionsCanvas.SetActive(_viewingOptionsMenu);
        if (menuLayout != null) menuLayout.SetActive(!_viewingOptionsMenu);
    }
}