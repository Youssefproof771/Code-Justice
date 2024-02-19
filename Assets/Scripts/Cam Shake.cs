using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    CinemachineVirtualCamera cam;
    public static CamShake instants;
    private void Start()
    {
        instants = this;
        cam = GetComponent<CinemachineVirtualCamera>();
    }
    public void ShakeCamera(float amp, float duration)
    {
        StartCoroutine(shakeCoroutine(amp, duration));
    }
    IEnumerator shakeCoroutine(float amp, float duration)
    {
        cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amp;
        yield return new WaitForSeconds(duration);
        cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
    }
}
