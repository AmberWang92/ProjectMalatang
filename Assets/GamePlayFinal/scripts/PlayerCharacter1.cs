using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter1 : MonoBehaviour
{
    public float speed;

    CharacterController cc;
    Animator animator;

    bool isAlive = true;

    public float turnSpeed;

    public Rigidbody shell;
    public Transform muzzle;
    public float launchForce = 10;

    public AudioSource shootAudioSource;

    bool attacking = false;
    public float attackTime;

    float hp;
    public float hpMax = 100; 


    public Slider hpSlider;
    public Image hpFillImage;
    public Color hpColorFull = Color.green;
    public Color hpColorNull = Color.red;

    public ParticleSystem explosionEffect;
        


    public void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        hp = hpMax;
        RefreshHealthHUD();
    }
    public void Move(Vector3 v)
    {
        if (!isAlive) return;
        if (attacking) return;

        Vector3 movement = v * speed;
        cc.SimpleMove(movement);

        if(animator)
        {
            animator.SetFloat("Speed", cc.velocity.magnitude);
        }
        
    }
  
    public void Rotate(Vector3 lookDir)
    {

        var targetPos = transform.position + lookDir;
        var characterPos = transform.position;

        characterPos.y = 0;
        targetPos.y = 0;

        var faceToTaregetDir = targetPos - characterPos;

        var faceToQuat = Quaternion.LookRotation(faceToTaregetDir);

        Quaternion slerp = Quaternion.Slerp(transform.rotation, faceToQuat, turnSpeed * Time.deltaTime);

        transform.rotation = slerp;
    }

    public void Attack()
    {
        if (!isAlive) return;
        if (attacking) return;

        var shellInstance = Instantiate(shell, muzzle.position,muzzle.rotation) as Rigidbody;
        shellInstance.velocity = launchForce * muzzle.forward;

        if(animator)
        {
            animator.SetTrigger("Attack");
        }

        attacking = true;
        shootAudioSource.Play();

        Invoke("RefreshAttack", attackTime);

    }

    void RefreshAttack()
    {
        attacking = false;
    }
    public void Death()
    {
        isAlive = false;
        explosionEffect.transform.parent = null;
        explosionEffect.gameObject.SetActive(true);

        ParticleSystem.MainModule mainModule = explosionEffect.main;
        Destroy(explosionEffect.gameObject, mainModule.duration);

        gameObject.SetActive(false);
    }

    public void TakeDamage(float amount)
    {
        hp -= amount;
        if(hp <= 0 && isAlive)
        {
            Death();
        }
        RefreshHealthHUD();
    }

    public void RefreshHealthHUD()
    {
        hpSlider.value = hp;
        hpFillImage.color = Color.Lerp(hpColorNull, hpColorFull, hp / hpMax);
    }
}
