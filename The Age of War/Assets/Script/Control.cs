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

        

        // 애니메이터 컨트롤러에서 현재 애니메이터의 상태의 이름이“close”일 때 
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack1"))
        {
            // 현재 애니메이션의 진행도가 1보다 크거나 같다면 damage 변수 출력
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
