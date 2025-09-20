using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Animator anim;

    readonly int IsMoveHash = Animator.StringToHash("isMove");

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.layer == LayerMask.NameToLayer("Goal"))
            anim.SetBool(IsMoveHash, false);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Goal"))
            anim.SetBool(IsMoveHash, true);
    }
}
