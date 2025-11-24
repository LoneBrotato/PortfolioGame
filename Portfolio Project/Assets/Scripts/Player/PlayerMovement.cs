using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [Header("Player Component Refrences")]
    [SerializeField] Rigidbody2D RB;

    [Header("Player Settings Refrences")]
    [SerializeField] float Speed = 5f;
    [SerializeField] float JumpPower = 1f;
    bool PlayerCanMove = false;


    [Header("Grounding")]
    [SerializeField] LayerMask GroundLayer;
    [SerializeField] Transform GroundCheck;
    [SerializeField] CapsuleCollider2D GroundCheckCapsule;

    [Header("Interacting")]
    [SerializeField] LayerMask IntreractionLayer;
    [SerializeField] Transform InteractionCheck;
    [SerializeField] CapsuleCollider2D InteractionCheckCapsule;
    [SerializeField] Transform LeftPoint;
    [SerializeField] Transform RightPoint;


    protected ContactFilter2D InteractionContactFilter;
 



    float HorizontalMovement;

    Vector2 MovementVector = new Vector2(0, 0);

    private void FixedUpdate()
    {
       
        RB.linearVelocity = new Vector2(HorizontalMovement * Speed, RB.linearVelocityY);

        if(RB.linearVelocityX>0)
        {
            InteractionCheck.parent = RightPoint;
            InteractionCheck.localPosition = Vector2.zero;
        }
        else if(RB.linearVelocityX<0)
        {
            InteractionCheck.parent = LeftPoint;
            InteractionCheck.localPosition = Vector2.zero;
        }

    }


    #region Player Controls
    public void Move(InputAction.CallbackContext context)
    {
        HorizontalMovement = context.ReadValue<Vector2>().x;

    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("JumpPressed");
        if (IsGrounded())
        {
            RB.linearVelocity = new Vector2(RB.linearVelocityX, JumpPower * Speed);
            Debug.Log("Jump");
        }
       
    }

    public void Interact(InputAction.CallbackContext context)
    {
        List<Collider2D> overlapping = new List<Collider2D>();
        InteractionCheckCapsule.Overlap(overlapping);

        if(overlapping.Count>0)
        {
            foreach (Collider2D coll in overlapping)
            {
                if(coll.CompareTag("Interact"))
                {
                    Interactable interactOBJ = coll.gameObject.GetComponent<Interactable>();
                    interactOBJ.Activate();
                }
            }
        }
        else
        {
            Debug.Log("Nothing Is there");
        }
    }
    public void ScoreItems(InputAction.CallbackContext context)
    {
    

    }


    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB = this.GetComponent<Rigidbody2D>();
        InteractionContactFilter.SetLayerMask(IntreractionLayer);
        InteractionContactFilter.useLayerMask = true;
        
       
    }
    private void OnDestroy()
    {
        
    }


    private void GameStart(bool arg0)
    {
        PlayerCanMove = true;
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(GroundCheck.position, GroundCheckCapsule.size, CapsuleDirection2D.Horizontal, 0, GroundLayer);
    }

    // Update is called once per frame
    void Update()
    {




    }
}
