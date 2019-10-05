using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    private GameObject _city;
    private VisionToggleable[] _visionToggleables;

    private bool _previousVisionFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        _city = GameObject.FindGameObjectWithTag("City");
        _visionToggleables = _city.GetComponentsInChildren<VisionToggleable>();
    }

    // Update is called once per frame
    void Update()
    {
        var isVisionOn = Input.GetAxisRaw("Vision") == 1;
        
        var isVisionFlagChanged = isVisionOn != _previousVisionFlag;

        if (!isVisionFlagChanged) return;

        _previousVisionFlag = isVisionOn;
        
        foreach (var visionToggleable in _visionToggleables)
        {
            if (isVisionOn)
                visionToggleable.SwitchToPast();
            else
                visionToggleable.SwitchToPresent();
        }
    }
}
