using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Observer : MonoBehaviour
{
    [SerializeField] AppleSpawner subjectToObserve;
    public GameObject panel;
    private SpriteRenderer panelImage;

    private void Start()
    {
        panelImage = panel.GetComponent<SpriteRenderer>();
        panelImage.enabled = false;
    }

    private void OnGoldenAppleSpawned(bool state)
    {
        panelImage.enabled = state;
    }

    private void Awake()
    {
        if (subjectToObserve != null)
        {
            subjectToObserve.OnGoldenAppleSpawned += OnGoldenAppleSpawned;
        }
    }

    private void OnDestroy() 
    {
        if (subjectToObserve != null)
        {
            subjectToObserve.OnGoldenAppleSpawned -= OnGoldenAppleSpawned;
        }
    }
}
