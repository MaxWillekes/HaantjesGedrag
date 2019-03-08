using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : StateMachineBehaviour
{
    //int fled = 0;
    //public GameObject,

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Application.loadedLevelName == "level0")
        {
            Application.LoadLevel("level1");
        }
        if (Application.loadedLevelName == "level1")
        {
            /*if (fled < 1)
            {
                fled++;
                Debug.Log(fled);
            }
            else
            {
                Debug.Log('level1');
                Application.LoadLevel("Home");
            }*/
            Application.LoadLevel("Home");
        }
    }


    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callback
       
    

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateMove is called right after Animator.OnAnimatorMove()
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that processes and affects root motion
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK()
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that sets up animation IK (inverse kinematics)
        //}
}
