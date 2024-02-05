using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeasonMenuButton : MonoBehaviour
{
    public RainController rainController; 
    public RainController.Season selectedSeason; 
    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }
    private void OnButtonClick()
    {
        if (rainController != null)
        {
            rainController.AdjustRainBasedOnSeason(selectedSeason);
        }

    }
}
