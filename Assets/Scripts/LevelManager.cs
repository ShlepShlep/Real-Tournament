using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TMP_Text waveIndicatorText;

    async public void AnnounceWave()
    {
        waveIndicatorText.text = "Wave Incoming";
        await new WaitForSeconds(2f);
        waveIndicatorText.text = "";
    }

    async public void waveEnded()
    {
        waveIndicatorText.text = "Wave Ended";
        await new WaitForSeconds(2f);
        waveIndicatorText.text = " ";
    }
}
