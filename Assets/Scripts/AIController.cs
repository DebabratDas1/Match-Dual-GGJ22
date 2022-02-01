using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public GameObject[] m_aiWeapons;
    private GameObject currentWeapon;

    



    // Start is called before the first frame update
    void Start()
    {
        Shuffle(m_aiWeapons);
        StartCoroutine( AIWeaponFire() );
    }

    

    private void Shuffle(GameObject[] _weapons)
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            int rnd = Random.Range(0, _weapons.Length);
            GameObject tempGO = _weapons[rnd];
            _weapons[rnd] = _weapons[i];
            _weapons[i] = tempGO;
        }
    }


    IEnumerator AIWeaponFire()
    {
        int timeToWait = Random.Range(3, 6);
        yield return new WaitForSeconds(timeToWait);
        AILevels(GameController.Instance.levelNo);

    }


    public IEnumerator AILevel1()
    {
        currentWeapon = m_aiWeapons[0];
        currentWeapon.SetActive(true);
        currentWeapon.GetComponent<Weapon>().StartAttacking();
        yield return new WaitForSeconds(1);
    }


    public IEnumerator AILevel2()
    {
        for (int i= 0;i < GameController.Instance.totalAttack; i++)
        {
            currentWeapon = m_aiWeapons[i];
            currentWeapon.SetActive(true);
            currentWeapon.GetComponent<Weapon>().StartAttacking();
            yield return new WaitForSeconds(GameController.Instance.attackingTime);
            int timeToWait = Random.Range(1, 4);
            yield return new WaitForSeconds(timeToWait);
        }
        
    }

    private void AILevels(int _level)
    {
        if (_level == 1)
        {
            StartCoroutine(AILevel1());
        }
        else if (_level == 2 || _level == 3)
        {
            StartCoroutine(AILevel2());
        }
    }
}
