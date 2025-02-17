using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;//sorat fireball
    private float direction;//jahat
    private bool hit;//barkhord
    private float lifetime;//zamanesh

    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 5) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");

        if (collision.tag == "Enemy")//agar enemy khord damage bede behesh
            collision.GetComponent<Health>()?.TakeDamage(1);
    }
    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);//active
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;//jahat player
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);//deactive aval
    }
}