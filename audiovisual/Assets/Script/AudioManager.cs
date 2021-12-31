using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;
    public static float[] Music = new float[512];
    public static float[] _freq = new float[8];
    public static float[] _Buffer = new float[8];
    private float[] _BufferD = new float[8];
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        GetSpectrumAudioSource();
        MakeBand();
        BandB();
    }

    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(Music, 0, FFTWindow.Blackman);
    }

    void MakeBand()
    {
        int B_count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int SCount = (int) Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                SCount += 2;
            }

            for (int j = 0; j < SCount; j++)
            {
                average += Music[B_count] * (B_count + 1);
                B_count++;
            }

            average /= B_count;

            _freq[i] = average * 10;
        }
    }

    void BandB()
    {
        for (int k = 0; k < 8; k++)
        {
            if (_freq[k] > _Buffer[k])
            {
                _Buffer[k] = _freq[k];
                _BufferD[k] = 0.005f;
            }

            if (_freq[k] < _Buffer[k])
            {
                _Buffer[k] -= _BufferD[k];
                _BufferD[k] *= 1.2f;
            }
        }
    }
}
