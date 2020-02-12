using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void UnPause()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
