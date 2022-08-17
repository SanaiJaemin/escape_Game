using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAssualtRifle : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip audioCipleTakeWeapon;

    [Header("Weapon Settiong")] 
    [SerializeField]
    private WeaponSetting weaponSetting;

    private float lastAttacktime = 0;

    private AudioSource audioSource;
    private PlayerAnimatorController animator;

    public GameObject BulletFrefeb;
    public  Transform Fire;
    // Start is called before the first frame update
    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();
        animator = GetComponentInParent<PlayerAnimatorController>();

        
    }

    private void OnEnable()
    {

    }
    
    public void StartWeaponAction(int type=0)
    {
         if(type == 0)
        {
            if (weaponSetting.isAutomaticAttack == true)
            {
                StartCoroutine("OnAttackLoop");
            }
            else
            {
                OnAttack();
            }
        }
    }

    public void StopWeaponAction(int type = 0)
    {
        if (type == 0)
        {
            StopCoroutine("OnAttackLoop");
        }
    }

    private IEnumerator OnAttackLoop()
    {
        while(true)
        {
            OnAttack();

            yield return null;
        }
    }

    public void OnAttack()
    {
        if(Time.time - lastAttacktime > weaponSetting.attackRate)
        {
            if (animator.moveSpeed > 0.5f)
            {
                return;
            }

            lastAttacktime = Time.time;

            animator.Play("Fire", -1, 0);

            Instantiate(BulletFrefeb, Fire.position, transform.rotation);
        }
    }

    //public void PlaySound(AudioClip)
    //{

    //}


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
