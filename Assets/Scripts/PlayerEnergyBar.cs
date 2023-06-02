using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergyBar : MonoBehaviour
{

    public float energy = 10;
    public float maxEnergy = 10;
    public RectTransform barRect;

    void Start()
    {
        // Update the bar's size based on the player's energy level.
        barRect.sizeDelta = new Vector2(maxEnergy, 1f);
        barRect.anchoredPosition = new Vector2(0f, 0f);
    }

    void Update()
    {
        // Update the bar's position based on the player's energy level.
        barRect.anchoredPosition = new Vector2(0f, -energy / maxEnergy * barRect.sizeDelta.y);
    }
}
