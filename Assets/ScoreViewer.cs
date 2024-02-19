using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreViewer : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI m_TextMeshProUGUI;
    void Start()
    {
        m_TextMeshProUGUI.text = "Score: " + BalloonSpawner.Score;
    }

}
