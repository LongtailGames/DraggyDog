using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LifeMeter : MonoBehaviour
{
    private Slider slider;
    private WaitForSeconds wait = new WaitForSeconds(1);
    private float currentTime;
    [SerializeField] private int MaxTime;
    private IEnumerator TheCountDown;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
        slider.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    public void StartCountdownRoutine()
    {
        currentTime = 0;
        TheCountDown = CountDown();
        StartCoroutine(TheCountDown);
    }

    public IEnumerator CountDown()
    {
        yield return null;
        slider.gameObject.SetActive(true);

        while (currentTime < MaxTime)
        {
            currentTime++;
            SetValue(currentTime / MaxTime);
            yield return wait;
        }

        timeout?.Invoke();
    }

    public UnityEvent timeout = new UnityEvent();

    public void SetValue(float ratio)
    {
        slider.value = ratio;
    }

    public void StopCountdownRoutine()
    {
        slider.gameObject.SetActive(false);
        StopCoroutine(TheCountDown);
    }
}