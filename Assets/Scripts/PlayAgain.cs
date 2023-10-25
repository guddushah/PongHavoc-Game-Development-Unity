using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgain : MonoBehaviour
{
    public void PlayAfterFail()
    {
        ball.ball_instance.PlayAgain();
    }
}
