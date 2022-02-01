using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private AudioSource destroySound; 
    public static GameController Instance;
    public GameObject destroyFX;
    public GameObject player;

    public int totalAttack = 1;
    private int currentAttack = 0;

    public bool isAttacking = false;
    public float attackingTime = 4;


    public int CurrentAttack
    {
        get { return currentAttack; }
        set
        {
            currentAttack = value;
            UIManager.Instance.attackText.text = "Attack : " + currentAttack.ToString() + "/" + totalAttack.ToString();
            CheckFinishLevel();

        }
    }
    public int levelNo = 1;



    private void Awake()
    {
        if(Instance!=null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        //StopParticles();
    }

    public IEnumerator GameOver(GameObject _weapon)
    {
        destroyFX.SetActive(true);
        ParticleSystem[] allParticles = destroyFX.GetComponentsInChildren<ParticleSystem>();
        Debug.Log(allParticles.Length);
        for (int i = 0; i < allParticles.Length; i++)
        {
            if(allParticles[i].isPlaying)
                allParticles[i].Stop();
            var emission = allParticles[i].emission;
            emission.enabled = true;
            allParticles[i].Play();
        }
        destroySound.Play();
        yield return new WaitForSeconds(2);
        //destroyFX.SetActive(false);
        player.SetActive(false);
        _weapon.SetActive(false);
        UIManager.Instance.OpenGameOverPanel();
    }

    private void StopParticles()
    {
        ParticleSystem[] allParticles = destroyFX.GetComponentsInChildren<ParticleSystem>();
        Debug.Log(allParticles.Length);
        for (int i = 0; i < allParticles.Length; i++)
        {
            allParticles[i].Stop();
        }
    }


    public void CheckFinishLevel()
    {
        if (currentAttack == totalAttack)
        {
            StartCoroutine(CompleteLevel());
        }
    }


    private IEnumerator CompleteLevel()
    {
        
        yield return new WaitForSeconds(2);
        if (SceneManager.GetActiveScene().buildIndex > 2)
            UIManager.Instance.OpenLevelCompletePanel();
        else
            UIManager.Instance.OpenGameFinishPanel();
    }
}
