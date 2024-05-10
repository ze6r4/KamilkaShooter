using enemyspace;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public GameObject EText;
    float HP = 100f;
    float maxHP = 100f;
    public Scrollbar scroll;
    public GameObject magic;
    public TextMeshProUGUI hpText;
    private Animator anim;
    [SerializeField] private Cooldown _shootCooldown;
    public bool attacking = false;

    public PlayerSettings set;
    public WeaponSettings weapon;

    void Start()
    {
        magic.SetActive(false);
        scroll.size = 1;
        HP = set.HP;
        hpText.text = "HP: " + HP;
        anim = GetComponent<Animator>();
        _shootCooldown.cooldownTime = weapon.coolDown;

        SetUpWeapon();
    }
    public void SetUpWeapon()
    {
        Light light = magic.GetComponentInChildren<Light>();
        light.color = weapon.color;
        MeshRenderer mesh = magic.GetComponent<MeshRenderer>();
        mesh.materials[0] = weapon.material;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _shootCooldown.canDoAction)
        {
            attacking = true;
            anim.SetBool("Attack", true);
            _shootCooldown.StartTimer();
            EText.SetActive(false);
        }
        else
        {
            anim.SetBool("Attack", false);
            attacking = false;
        }

    }

    public void GetDamage(float damage)
    {
        anim.SetTrigger("Damage");
        HP -= damage;

        if (HP <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
        UpdateScroll();
        
        
    }

    public void Heal(float heal)
    {
        float result = HP + heal;
        if (result > maxHP) result = maxHP;
        HP = result;
        UpdateScroll(); 
    }
    private void UpdateScroll()
    {
        scroll.size = HP / maxHP;
        hpText.text = "HP: " + HP;
        var color = scroll.colors;
        if (scroll.size <= 0.3f)
        {

            color.normalColor = UnityEngine.Color.red;
        }
        else if (scroll.size <= 0.6f)
        {
            color.normalColor = UnityEngine.Color.yellow;
        }
        else
        {
            color.normalColor = UnityEngine.Color.green;

        }
        scroll.colors = color;
    }
}
