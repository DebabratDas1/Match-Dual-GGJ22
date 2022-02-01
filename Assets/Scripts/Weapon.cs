using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Fire"))
        {
            Debug.Log("Fire snowflake");
            if (other.gameObject.CompareTag("SnowShield"))
            {
                ActionOnShieldDetected();
            }
        }
        else if (gameObject.CompareTag("Angry"))
        {
            if (other.gameObject.CompareTag("LoveShield"))
            {
                ActionOnShieldDetected();
            }
        }
        else if (gameObject.CompareTag("Sword"))
        {
            if (other.gameObject.CompareTag("SwordShield"))
            {
                ActionOnShieldDetected();
            }
        }
    }

    private void ActionOnShieldDetected()
    {
        gameObject.SetActive(false);
        GameController.Instance.CurrentAttack++;
    }

    public void StartAttacking()
    {
        StartCoroutine( LerpPosition(GameController.Instance.player.transform.position, 4) );
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine( GameController.Instance.GameOver(gameObject) );
        }
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        yield return new WaitForSeconds(2f);
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
