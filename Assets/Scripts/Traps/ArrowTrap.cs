using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;//zamane beyn har tir
    [SerializeField] private Transform firePoint;//noghte partab
    [SerializeField] private GameObject[] arrows;//aroow ha
    private float cooldownTimer;//next tir

    [Header("SFX")]
    [SerializeField] private AudioClip arrowSound;

    private void Attack()
    {
        cooldownTimer = 0;

       // SoundManager.instance.PlaySound(arrowSound);//arrow haro faal mikone va mifreste
        arrows[FindArrow()].transform.position = firePoint.position;
        arrows[FindArrow()].GetComponent<EnemyProjectile>().ActivateProjectile();//faal kardan tir
    }
    private int FindArrow()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)//tir faal ya na?
                return i;
        }
        return 0;
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= attackCooldown)
            Attack();
    }
}