using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour
{
    private int qSamples = 1024;
    private float refValue = 0.002f;
    private float rmsValue;
    private float dbValue;
    private float Delay = 0.0f;

    private float[] Smaples;
    private float fSmaples;

    private string MicroPhoneName;
    private List<string> allMicroPhone = new List<string>();
    private AudioSource Source;
    private int Index;

    void Start()
    {
        Smaples = new float[qSamples];
        fSmaples = AudioSettings.outputSampleRate;

        Source = GetComponent<AudioSource>();

        for (int i = 0; i < Microphone.devices.Length; i++)
        {
            if (MicroPhoneName == null)
            {
                MicroPhoneName = Microphone.devices[i];
                Index = i;

            }
            allMicroPhone.Add(Microphone.devices[i]);
        }
        StartMicroPhone();
    }

    void StartMicroPhone()
    {
        Source.Stop();

        Source.clip = Microphone.Start(MicroPhoneName, true, 10, 44100);
        Source.loop = true;

        Debug.Log(Microphone.IsRecording(MicroPhoneName).ToString());

        if (Microphone.IsRecording(MicroPhoneName))
        {
            while (!(Microphone.GetPosition(MicroPhoneName) > 0)) ;
            Debug.Log("녹음 시작!");
            Source.Play();
        }
        else
        {
            Debug.Log("녹음 실패!");
        }
    }

    void SoundCal()
    {
        Source.GetOutputData(Smaples, Index);
        float Sum = 0.0f;
        for (int i = 0; i < qSamples; i++)
        {
            Sum += Smaples[i] * Smaples[i];
        }
        rmsValue = Mathf.Sqrt(Sum / qSamples);
        dbValue = 20 * Mathf.Log10(rmsValue / refValue);
        dbValue = dbValue * 0.6f;
        if (dbValue >= 10 && dbValue < 15)
        {
            dbValue = (10 + 15) / 2;
        }
        else if(dbValue >= 15 && dbValue < 20){
            dbValue = (15 + 20) / 2;
        }
    }

    void Update()
    {
        if (Delay >= 0.0f)
        {
            SoundCal();
            Delay = 0.0f;
        }
        Delay += Time.deltaTime;
    }

    public float GetDecibel() { return dbValue; }
}