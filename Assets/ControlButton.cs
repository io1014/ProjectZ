using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlButton : MonoBehaviour
{

    [SerializeField] GameObject _movePanel;
    [SerializeField] GameObject _attackPanel;
    [SerializeField] GameObject _itemPanel;
    [SerializeField] GameObject _buildingPanel;
    [SerializeField] GameObject _conditionPanel;


    void Start()
    {
        AllOffPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AllOffPanel()
    {
        _movePanel.SetActive(false);
        _attackPanel.SetActive(false);
        _itemPanel.SetActive(false);
        _buildingPanel.SetActive(false);
        _conditionPanel.SetActive(false);    
    }

    public void moveButton()
    {
        AllOffPanel();
        _movePanel.SetActive(true);
    }

    public void attackButton()
    {
        AllOffPanel();
        _attackPanel.SetActive(true);
    }

    public void itemButton()
    {
        AllOffPanel();
        _itemPanel.SetActive(true);
    }

    public void buildingButton()
    {
        AllOffPanel();
        _buildingPanel.SetActive(true);
    }

    public void conditionButton()
    {
        AllOffPanel();
        _conditionPanel.SetActive(true);
    }
}
