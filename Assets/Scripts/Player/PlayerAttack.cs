using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;//zaman baraye hamaleye dobare
    [SerializeField] private Transform firePoint;//noghte shoro fireball
    [SerializeField] private GameObject[] fireballs;//fireball ha
    [SerializeField] private AudioClip fireballSound;

    private Animator anim;//control animations
    private PlayerMovement playerMovement;//harkate player
    private float cooldownTimer = Mathf.Infinity;//zaman be hamle badi

    private void Awake()
    {
        anim = GetComponent<Animator>();//animator ha
        playerMovement = GetComponent<PlayerMovement>();//harkat
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack()
            && Time.timeScale > 0)//mouse chap baraye hamle? zama? player emkan attack?
            Attack();

        cooldownTimer += Time.deltaTime;//update time
    }

    private void Attack()
    {
       
        anim.SetTrigger("attack");//tanzim trigger attack baraye pakhsh animation
        cooldownTimer = 0;

        fireballs[FindFireball()].transform.position = firePoint.position;//fireball dar makan
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));//ersal fireball
    }
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)//kodoom fireball faal nist
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}