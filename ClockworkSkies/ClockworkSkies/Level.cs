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
    public enum victoryConditions { Elimination, Survival, Escort, EnemyEscort, DestroyBase, DefendBase, DoubleEscort, DoubleBase };

    public class Level
    {
        //attributes
        public Player p1;
        private Enemy targetEnemy;
        private Ally targetAlly;
        private Base enemyBase;
        private Base allyBase;
        private List<NPC> npcs;
        private int timer;
        private victoryConditions victory;

        //constructor
        public Level(int time, int win, Vector3 playerData, Vector3 allyTarget, Vector3 enemyTarget, Vector2 allyBaseData, Vector2 enemyBaseData, List<Vector4> NPCList)
        {
            //create player
            p1 = new Player(GameVariables.PlayerImage, new Vector2(playerData.X, playerData.Y), (float)(Math.PI * 2 * playerData.Z / 8));
            //set time limit
            timer = time;
            //set vicrory condition
            victory = (victoryConditions)win;
            //set target ally if present
            if ((victory == victoryConditions.Escort) || (victory == victoryConditions.DoubleEscort))
            {
                targetAlly = new Ally(GameVariables.PlayerImage, new Vector2(allyTarget.X, allyTarget.Y), (float)(Math.PI * 2 * allyTarget.Z / 8));
            }
            //set target enemy if present
            if ((victory == victoryConditions.EnemyEscort)||(victory == victoryConditions.DoubleEscort))
            {
                targetEnemy = new Enemy(GameVariables.PlayerImage, new Vector2(enemyTarget.X, enemyTarget.Y), (float)(Math.PI * 2 * enemyTarget.Z / 8), p1);
            }
            //set allied base if present
            if ((victory == victoryConditions.DefendBase)||(victory == victoryConditions.DoubleBase))
            {
                allyBase = new Base(allyBaseData, true);
            }
            //set enemy base if present
            if ((victory == victoryConditions.DestroyBase)||(victory == victoryConditions.DoubleBase))
            {
                enemyBase = new Base(enemyBaseData, false);
            }
            //create NPC list
            npcs = new List<NPC>();
            //create NPCs and add to list
            foreach (Vector4 data in NPCList)
            {
                NPC newNPC = null;
                if (data.W == 0)
                {
                    newNPC = new Enemy(GameVariables.PlayerImage, new Vector2(data.X, data.Y), (float)(Math.PI * 2 * data.Z / 8), p1);
                }
                else
                {
                    newNPC = new Ally(GameVariables.PlayerImage, new Vector2(data.X, data.Y), (float)(Math.PI * 2 * data.Z / 8));
                }
                npcs.Add(newNPC);
            }

        }

        public void Update()
        {
            //run update methods for Player, NPCS and bases
            p1.Update();
            if (targetAlly != null)
            {
                targetAlly.Update();
            }
            if (targetEnemy != null)
            {
                targetEnemy.Update();
            }
            if (allyBase != null)
            {
                allyBase.Update();
            }
            if (enemyBase != null)
            {
                enemyBase.Update();
            }
            foreach (NPC npc in npcs)
            {
                npc.Update();
            }
            //timer code
            //victory test code
        }
    }
}
