using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ChangePostProcessingValue : MonoBehaviour
{
    [SerializeField]
    private VolumeProfile profile;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.SpeedChange += OnSpeedChange;
    }

    private void OnSpeedChange(float s)
    {
        float temp = Mathf.Lerp(0f, -0.7f, s/13f);
        LensDistortion tmp;
        if (profile.TryGet<LensDistortion>(out tmp))
        {
            tmp.intensity.value = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
