using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectorController : MonoBehaviour
{
    [SerializeField] private AudioSource m_audioPickUpClick, m_audioActiveShield;
    [SerializeField] private GameObject m_loveShield, m_normalShield, m_snowShield;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.CompareTag("Shield"))
                {
                    StartCoroutine( ActiveShield(hit.collider.gameObject, m_normalShield) );
                }
                else if (hit.collider.gameObject.CompareTag("Love"))
                {
                    StartCoroutine( ActiveShield(hit.collider.gameObject, m_loveShield));
                }
                else if (hit.collider.gameObject.CompareTag("SnowFlake"))
                {
                    StartCoroutine(ActiveShield(hit.collider.gameObject, m_snowShield) );

                }
            }
        }
    }

    private IEnumerator ActiveShield(GameObject _shieldOf, GameObject shield)
    {
        PlayAudio(m_audioPickUpClick);
        //_shieldOf.SetActive(false);
        shield.SetActive(true);
        PlayAudio(m_audioActiveShield);
        yield return new WaitForSeconds(2f);
        shield.SetActive(false);
    }

    private void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }


}
