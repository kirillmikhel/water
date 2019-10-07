using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public bool isOn = false;
    
    private GameObject _city;
    private VisionToggleable[] _visionToggleables;

    private bool _previousIsOn = false;
    private GameObject _sun;
    private Animator _lightAnimator;
    private SoundController _soundController;
    private Inventory _inventory;

    // Start is called before the first frame update
    void Start()
    {
        _inventory = GetComponent<Inventory>();
        _soundController = GameManager.Instance.GetComponent<SoundController>();
        _city = GameObject.FindGameObjectWithTag("City");
        _visionToggleables = _city.GetComponentsInChildren<VisionToggleable>();
        
        _sun = GameObject.FindGameObjectWithTag("Sun");
        _lightAnimator = _sun.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_inventory.Contains(ItemType.Artifact)) return;
            
        isOn = Input.GetAxisRaw("Vision") == 1;
        
        var isVisionFlagChanged = isOn != _previousIsOn;

        if (!isVisionFlagChanged) return;

        _previousIsOn = isOn;
        
        foreach (var visionToggleable in _visionToggleables)
        {
            _lightAnimator.SetBool("Vision", isOn);
            _soundController.SwitchBackgroundMusic(isOn);
            
            if (isOn)
            {
                visionToggleable.SwitchToPast();
            }
            else
            {
                visionToggleable.SwitchToPresent();
            }
        }
    }
}
