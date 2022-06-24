using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float Speed;
    public float HP = 100;
    
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        

        // �ִϸ����� ��Ʈ�ѷ����� ���� �ִϸ������� ������ �̸��̡�close���� �� 
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack1"))
        {
            // ���� �ִϸ��̼��� ���൵�� 1���� ũ�ų� ���ٸ� damage ���� ���
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                HP -= 10;
                animator.Rebind();
            }
        }

        if(HP <= 0)
        {
            Destroy(gameObject);
        }


        RaycastHit hit;

        Vector3 dir = new Vector3(transform.position.x, transform.position.z);

        Ray ray = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(ray, out hit, 2.0f))
        {
            Speed = 0.0f;
            animator.SetBool("Attack", true);
        }
        else
        {
            Speed = 3.0f;
            animator.SetBool("Attack", false);
        }

    }

   




  
}
