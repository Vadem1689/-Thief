using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmManager : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmAudio;
    [SerializeField] private float _startVolume = 0.2f;
    [SerializeField] private float _endVolume = 1;
    [SerializeField] private float _volumeScale = 5f;

    private bool comeIn=false;
    private bool isExit=false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Player")
        {
            if (isExit==true)
            {
                _volumeScale = -_volumeScale;
            }
            comeIn=true;
            _alarmAudio.Play();
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isExit=true;
            _volumeScale = -_volumeScale;
        }
        
    }
    private void Update()
    {
        if (comeIn==true )
        {
            _alarmAudio.volume += Mathf.MoveTowards(_startVolume, _endVolume, _volumeScale*Time.deltaTime);
        }
    }
}
