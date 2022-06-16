using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public Sprite[] idleFrames_S;
    // public Sprite[] idleFrames_SW;
    public Sprite[] idleFrames_W;
    // public Sprite[] idleFrames_NW;
    public Sprite[] idleFrames_N;
    // public Sprite[] idleFrames_NE;
    public Sprite[] idleFrames_E;
    // public Sprite[] idleFrames_SE;
    

    public Sprite[] walkFrames_S;
    // public Sprite[] walkFrames_SW;
    public Sprite[] walkFrames_W;
    // public Sprite[] walkFrames_NW;
    public Sprite[] walkFrames_N;
    // public Sprite[] walkFrames_NE;
    public Sprite[] walkFrames_E;
    // public Sprite[] walkFrames_SE;

    public int test_int = 1;
    public Vector2 test_Vector2 = new Vector2(0,0);

    private Sprite[] currentFrames;

    private SpriteRenderer spriteRenderer;

    private float timer = 0f;
    private int frameNumber = 0;
    private float frameRate = 1 / 3f;

    private CharacterAnimationType currentAnimationType;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        PlayAnimation(CharacterAnimationType.Idle_S);
    }

    void Update()
    {
        UpdateFrames();
    }

    private void UpdateFrames()
    {
        timer += Time.deltaTime;

        if (timer >= frameRate) {
            timer -= frameRate;

            frameNumber = (frameNumber + 1) % currentFrames.Length;

            spriteRenderer.sprite = currentFrames[frameNumber];
        }
    }

    public void PlayAnimation(CharacterAnimationType animationType)
    {
        timer = 0;
        frameNumber = 0;
        currentAnimationType = animationType;

        switch (animationType){
            case CharacterAnimationType.Idle_N: {
                currentFrames = idleFrames_N;
                break;
            }
            case CharacterAnimationType.Idle_E: {
                currentFrames = idleFrames_E;
                break;
            }
            case CharacterAnimationType.Idle_S: {
                currentFrames = idleFrames_S;
                break;
            }
            case CharacterAnimationType.Idle_W: {
                currentFrames = idleFrames_W;
                break;
            }
            case CharacterAnimationType.Walk_N: {
                currentFrames = walkFrames_N;
                break;
            }
            case CharacterAnimationType.Walk_E: {
                currentFrames = walkFrames_E;
                break;
            }
            case CharacterAnimationType.Walk_S: {
                currentFrames = walkFrames_S;
                break;
            }
            case CharacterAnimationType.Walk_W: {
                currentFrames = walkFrames_W;
                break;
            }
        }
    }

    public void setAnimation(Vector3 direction)
    {
        if (direction.x == 0 && direction.y == 0) {
            if (currentAnimationType == CharacterAnimationType.Walk_N){
                PlayAnimation(CharacterAnimationType.Idle_N);
            } else if (currentAnimationType == CharacterAnimationType.Walk_E){
                PlayAnimation(CharacterAnimationType.Idle_E);
            } else if (currentAnimationType == CharacterAnimationType.Walk_S){
                PlayAnimation(CharacterAnimationType.Idle_S);
            } else if (currentAnimationType == CharacterAnimationType.Walk_W){
                PlayAnimation(CharacterAnimationType.Idle_W);
            }
        } else if (direction.y > 0) {
            PlayAnimation(CharacterAnimationType.Walk_N);
        } else if (direction.x > 0) {
            PlayAnimation(CharacterAnimationType.Walk_E);
        } else if (direction.y < 0) {
            PlayAnimation(CharacterAnimationType.Walk_S);
        } else if (direction.x < 0) {
            PlayAnimation(CharacterAnimationType.Walk_W);
        }
    }
}
