using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace ClockworkSkies
{
    enum victoryConditions { Elimination, Survival, Escort, EnemyEscort, DestroyBase, DefendBase, DoubleEscort, DoubleBase};
    class Level
    {
        private Player p1;
        //private Enemy targetEnemy;
        //private Ally targetAlly;
        //private Base enemyBase;
        //private Base allyBase;
        //private List<NPC> npcs;
        private int timer;
        private victoryConditions victory;

        public Level(int time, int win, Vector3 playerData, Vector3 allyTarget, Vector3 enemyTarget, Vector2 allyBase, Vector2 enemyBase, List<Vector4> NPCList)
        {
            p1 = new Player(GameVariables.PlayerImage, new Vector2(playerData.X, playerData.Y), 32, 32, playerData.Z, 3 * (float)(Math.PI / 180), 150);
            timer = time;
            victory = (victoryConditions)win;
            if (allyTarget != null)
            {
                //make target ally
            }
            if (enemyTarget != null)
            {
                //make target enemy
            }
            if (allyBase != null)
            {
                //make ally base
            }
            if (enemyBase != null)
            {
                //make enemy base
            }
            //npcs = new List<NPC>();
            foreach (Vector4 data in NPCList)
            {
                //make npc
                //add to npcs
            }
        }
    }
}
