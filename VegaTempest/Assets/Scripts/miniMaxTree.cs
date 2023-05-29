using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniMaxTree : MonoBehaviour
{
    public class node
    {
        public BattleSystem BSystem { get; set; }

        public List<node> Children;
        public node(BattleSystem bsystem)
        {
            BSystem = bsystem;
            Children = new List<node>();
        }
    }
    private void generateRecursiveTree(node parent, int depth, bool playermaximizing)
    {
        //if (depth == 0 && parent.BSystem.State = BattleStates.Lose)
        {
            return;
        }

        
    }
    public node createTree(BattleSystem battleSystem, int depth)
    {
        node Root = new node(battleSystem);
        generateRecursiveTree(Root, depth, true);
        return Root;
    }
}
