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
        public Player p1;
        private Enemy targetEnemy;
        private Ally targetAlly;
        private Base enemyBase;
        private Base allyBase;
        private List<NPC> npcs;
        private int timer;
        private victoryConditions victory;

        public Level(int time, int win, Vector3 playerData, Vector3 allyTarget, Vector3 enemyTarget, Vector2 allyBaseData, Vector2 enemyBaseData, List<Vector4> NPCList)
        {
            p1 = new Player(GameVariables.PlayerImage, new Vector2(playerData.X, playerData.Y), 32, 32, playerData.Z, 3 * (float)(Math.PI / 180), 150);
            timer = time;
            victory = (victoryConditions)win;
            if (allyTarget != null)
            {
                targetAlly = new Ally(GameVariables.PlayerImage, new Vector2(allyTarget.X, allyTarget.Y), 32, 32, allyTarget.Z, 3 * (float)(Math.PI / 180), 150);
            }
            if (enemyTarget != null)
            {
                targetEnemy = new Enemy(GameVariables.PlayerImage, new Vector2(enemyTarget.X, enemyTarget.Y), 32, 32, enemyTarget.Z, 3 * (float)(Math.PI / 180), 150, p1);
            }
            if (allyBaseData != null)
            {
                allyBase = new Base(allyBaseData);
            }
            if (enemyBaseData != null)
            {
                enemyBase = new Base(enemyBaseData);
            }
            npcs = new List<NPC>();
            foreach (Vector4 data in NPCList)
            {
                NPC newNPC = null;
                if (data.W == 0)
                {
                    newNPC = new Enemy(GameVariables.PlayerImage, new Vector2(data.X, data.Y), 32, 32, data.Z, 3 * (float)(Math.PI / 180), 150, p1);
                }
                else
                {
                    newNPC = new Ally(GameVariables.PlayerImage, new Vector2(data.X, data.Y), 32, 32, data.Z, 3 * (float)(Math.PI / 180), 150);
                }
                npcs.Add(newNPC);
            }
        }
    }
}
