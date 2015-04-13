using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CSkiesLevelEditor
{
    enum directions { N, NE, E, SE, S, SW, W, NW};
    enum NPCTypes { Enemy, Ally};
    enum victoryConditions { Elimination, Survival, Escort, EnemyEscort, DestroyBase, DefendBase, DoubleEscort, DoubleBase};

    public partial class Form1 : Form
    {
        public static List<NPCControlSet> NPCList;
        private int numNPCs;

        public Form1()
        {
            InitializeComponent();
            NPCList = new List<NPCControlSet>();
            numNPCs = 0;
            comboBoxAllyDirection.Items.Add(directions.N);
            comboBoxAllyDirection.Items.Add(directions.E);
            comboBoxAllyDirection.Items.Add(directions.S);
            comboBoxAllyDirection.Items.Add(directions.W);
            comboBoxAllyDirection.Items.Add(directions.NE);
            comboBoxAllyDirection.Items.Add(directions.NW);
            comboBoxAllyDirection.Items.Add(directions.SE);
            comboBoxAllyDirection.Items.Add(directions.SW);

            comboBoxEnemyDirection.Items.Add(directions.N);
            comboBoxEnemyDirection.Items.Add(directions.E);
            comboBoxEnemyDirection.Items.Add(directions.S);
            comboBoxEnemyDirection.Items.Add(directions.W);
            comboBoxEnemyDirection.Items.Add(directions.NE);
            comboBoxEnemyDirection.Items.Add(directions.NW);
            comboBoxEnemyDirection.Items.Add(directions.SE);
            comboBoxEnemyDirection.Items.Add(directions.SW);

            comboBoxPlayerDirection.Items.Add(directions.N);
            comboBoxPlayerDirection.Items.Add(directions.E);
            comboBoxPlayerDirection.Items.Add(directions.S);
            comboBoxPlayerDirection.Items.Add(directions.W);
            comboBoxPlayerDirection.Items.Add(directions.NE);
            comboBoxPlayerDirection.Items.Add(directions.NW);
            comboBoxPlayerDirection.Items.Add(directions.SE);
            comboBoxPlayerDirection.Items.Add(directions.SW);

            comboBoxVictory.Items.Add(victoryConditions.Elimination);
            comboBoxVictory.Items.Add(victoryConditions.Survival);
            comboBoxVictory.Items.Add(victoryConditions.Escort);
            comboBoxVictory.Items.Add(victoryConditions.EnemyEscort);
            comboBoxVictory.Items.Add(victoryConditions.DoubleEscort);
            comboBoxVictory.Items.Add(victoryConditions.DestroyBase);
            comboBoxVictory.Items.Add(victoryConditions.DefendBase);
            comboBoxVictory.Items.Add(victoryConditions.DoubleBase);

            comboBoxAllyDirection.SelectedIndex = 0;
            comboBoxEnemyDirection.SelectedIndex = 2;
            comboBoxPlayerDirection.SelectedIndex = 0;
            comboBoxVictory.SelectedIndex = 0;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void buttonNewNPC_Click(object sender, EventArgs e)
        {
            Label typeLabel = new Label();
            typeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            typeLabel.Location = new Point(4, (NPCList.Count * 30) + 4);
            typeLabel.Name = "labelNPCType" + numNPCs;
            typeLabel.Size = new System.Drawing.Size(74, 16);
            typeLabel.TabIndex = 0;
            typeLabel.Text = "NPC Type:";
            panelNPCList.Controls.Add(typeLabel);

            Label xLabel = new Label();
            xLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xLabel.Location = new Point(150, (NPCList.Count * 30) + 4);
            xLabel.Name = "labelNPCX" + numNPCs;
            xLabel.Size = new System.Drawing.Size(19, 16);
            xLabel.TabIndex = 0;
            xLabel.Text = "X:";
            panelNPCList.Controls.Add(xLabel);

            Label yLabel = new Label();
            yLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            yLabel.Location = new Point(213, (NPCList.Count * 30) + 4);
            yLabel.Name = "labelNPCY" + numNPCs;
            yLabel.Size = new System.Drawing.Size(20, 16);
            yLabel.TabIndex = 0;
            yLabel.Text = "Y:";
            panelNPCList.Controls.Add(yLabel);

            Label directionLabel = new Label();
            directionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            directionLabel.Location = new Point(277, (NPCList.Count * 30) + 4);
            directionLabel.Name = "labelNPCDirection" + numNPCs;
            directionLabel.Size = new System.Drawing.Size(64, 16);
            directionLabel.TabIndex = 0;
            directionLabel.Text = "Direction:";
            panelNPCList.Controls.Add(directionLabel);

            ComboBox typeBox = new ComboBox();
            typeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            typeBox.FormattingEnabled = true;
            typeBox.Location = new System.Drawing.Point(84, (NPCList.Count * 30) + 4);
            typeBox.Name = "comboBoxNPCDirection" + numNPCs;
            typeBox.Size = new System.Drawing.Size(60, 21);
            typeBox.TabIndex = 3;
            panelNPCList.Controls.Add(typeBox);

            ComboBox directionBox = new ComboBox();
            directionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            directionBox.FormattingEnabled = true;
            directionBox.Location = new System.Drawing.Point(347, (NPCList.Count * 30) + 4);
            directionBox.Name = "comboBoxNPCDirection" + numNPCs;
            directionBox.Size = new System.Drawing.Size(49, 21);
            directionBox.TabIndex = 3;
            panelNPCList.Controls.Add(directionBox);

            NumericUpDown xUpDown = new NumericUpDown();
            xUpDown.Location = new System.Drawing.Point(175, (NPCList.Count * 30) + 4);
            xUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            xUpDown.Name = "numericUpDownNPCX" + numNPCs;
            xUpDown.Size = new System.Drawing.Size(32, 20);
            xUpDown.TabIndex = 7;
            panelNPCList.Controls.Add(xUpDown);

            NumericUpDown yUpDown = new NumericUpDown();
            yUpDown.Location = new System.Drawing.Point(239, (NPCList.Count * 30) + 4);
            yUpDown.Maximum = new decimal(new int[] {
            33,
            0,
            0,
            0});
            yUpDown.Name = "numericUpDownNPCX" + numNPCs;
            yUpDown.Size = new System.Drawing.Size(32, 20);
            yUpDown.TabIndex = 7;
            panelNPCList.Controls.Add(yUpDown);

            Button deleteButton = new Button();
            deleteButton.Location = new System.Drawing.Point(402, (NPCList.Count * 30) + 4);
            deleteButton.Name = "buttonNPCDelete" + numNPCs;
            deleteButton.Size = new System.Drawing.Size(75, 23);
            deleteButton.TabIndex = 14;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            //deleteButton.Click += new EventHandler(deleteButton_Click);
            panelNPCList.Controls.Add(deleteButton);

            NPCControlSet buttonSet = new NPCControlSet(NPCList.Count, typeLabel, typeBox, xLabel, xUpDown, yLabel, yUpDown, directionLabel, directionBox, deleteButton);
            NPCList.Add(buttonSet);
            numNPCs++;
        }

        private void comboBoxVictory_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((victoryConditions)comboBoxVictory.SelectedItem)
            {
                case(victoryConditions.Elimination):
                    labelAlly.Enabled = false;
                    labelAllyX.Enabled = false;
                    labelAllyY.Enabled = false;
                    labelAllyDirection.Enabled = false;
                    numericUpDownAllyX.Enabled = false;
                    numericUpDownAllyY.Enabled = false;
                    comboBoxAllyDirection.Enabled = false;

                    labelEnemy.Enabled = false;
                    labelEnemyX.Enabled = false;
                    labelEnemyY.Enabled = false;
                    labelEnemyDirection.Enabled = false;
                    numericUpDownEnemyX.Enabled = false;
                    numericUpDownEnemyY.Enabled = false;
                    comboBoxEnemyDirection.Enabled = false;

                    labelAllyBase.Enabled = false;
                    labelABaseX.Enabled = false;
                    labelABaseY.Enabled = false;
                    numericUpDownABaseX.Enabled = false;
                    numericUpDownABaseY.Enabled = false;

                    labelEnemyBase.Enabled = false;
                    labelEBaseX.Enabled = false;
                    labelEBaseY.Enabled = false;
                    numericUpDownEBaseX.Enabled = false;
                    numericUpDownEBaseY.Enabled = false;
                    break;
                case(victoryConditions.Survival):
                    labelAlly.Enabled = false;
                    labelAllyX.Enabled = false;
                    labelAllyY.Enabled = false;
                    labelAllyDirection.Enabled = false;
                    numericUpDownAllyX.Enabled = false;
                    numericUpDownAllyY.Enabled = false;
                    comboBoxAllyDirection.Enabled = false;

                    labelEnemy.Enabled = false;
                    labelEnemyX.Enabled = false;
                    labelEnemyY.Enabled = false;
                    labelEnemyDirection.Enabled = false;
                    numericUpDownEnemyX.Enabled = false;
                    numericUpDownEnemyY.Enabled = false;
                    comboBoxEnemyDirection.Enabled = false;

                    labelAllyBase.Enabled = false;
                    labelABaseX.Enabled = false;
                    labelABaseY.Enabled = false;
                    numericUpDownABaseX.Enabled = false;
                    numericUpDownABaseY.Enabled = false;

                    labelEnemyBase.Enabled = false;
                    labelEBaseX.Enabled = false;
                    labelEBaseY.Enabled = false;
                    numericUpDownEBaseX.Enabled = false;
                    numericUpDownEBaseY.Enabled = false;
                    break;
                case(victoryConditions.Escort):
                    labelAlly.Enabled = true;
                    labelAllyX.Enabled = true;
                    labelAllyY.Enabled = true;
                    labelAllyDirection.Enabled = true;
                    numericUpDownAllyX.Enabled = true;
                    numericUpDownAllyY.Enabled = true;
                    comboBoxAllyDirection.Enabled = true;

                    labelEnemy.Enabled = false;
                    labelEnemyX.Enabled = false;
                    labelEnemyY.Enabled = false;
                    labelEnemyDirection.Enabled = false;
                    numericUpDownEnemyX.Enabled = false;
                    numericUpDownEnemyY.Enabled = false;
                    comboBoxEnemyDirection.Enabled = false;

                    labelAllyBase.Enabled = false;
                    labelABaseX.Enabled = false;
                    labelABaseY.Enabled = false;
                    numericUpDownABaseX.Enabled = false;
                    numericUpDownABaseY.Enabled = false;

                    labelEnemyBase.Enabled = false;
                    labelEBaseX.Enabled = false;
                    labelEBaseY.Enabled = false;
                    numericUpDownEBaseX.Enabled = false;
                    numericUpDownEBaseY.Enabled = false;
                    break;
                case(victoryConditions.EnemyEscort):
                    labelAlly.Enabled = false;
                    labelAllyX.Enabled = false;
                    labelAllyY.Enabled = false;
                    labelAllyDirection.Enabled = false;
                    numericUpDownAllyX.Enabled = false;
                    numericUpDownAllyY.Enabled = false;
                    comboBoxAllyDirection.Enabled = false;

                    labelEnemy.Enabled = true;
                    labelEnemyX.Enabled = true;
                    labelEnemyY.Enabled = true;
                    labelEnemyDirection.Enabled = true;
                    numericUpDownEnemyX.Enabled = true;
                    numericUpDownEnemyY.Enabled = true;
                    comboBoxEnemyDirection.Enabled = true;

                    labelAllyBase.Enabled = false;
                    labelABaseX.Enabled = false;
                    labelABaseY.Enabled = false;
                    numericUpDownABaseX.Enabled = false;
                    numericUpDownABaseY.Enabled = false;

                    labelEnemyBase.Enabled = false;
                    labelEBaseX.Enabled = false;
                    labelEBaseY.Enabled = false;
                    numericUpDownEBaseX.Enabled = false;
                    numericUpDownEBaseY.Enabled = false;
                    break;
                case(victoryConditions.DoubleEscort):
                    labelAlly.Enabled = true;
                    labelAllyX.Enabled = true;
                    labelAllyY.Enabled = true;
                    labelAllyDirection.Enabled = true;
                    numericUpDownAllyX.Enabled = true;
                    numericUpDownAllyY.Enabled = true;
                    comboBoxAllyDirection.Enabled = true;

                    labelEnemy.Enabled = true;
                    labelEnemyX.Enabled = true;
                    labelEnemyY.Enabled = true;
                    labelEnemyDirection.Enabled = true;
                    numericUpDownEnemyX.Enabled = true;
                    numericUpDownEnemyY.Enabled = true;
                    comboBoxEnemyDirection.Enabled = true;

                    labelAllyBase.Enabled = false;
                    labelABaseX.Enabled = false;
                    labelABaseY.Enabled = false;
                    numericUpDownABaseX.Enabled = false;
                    numericUpDownABaseY.Enabled = false;

                    labelEnemyBase.Enabled = false;
                    labelEBaseX.Enabled = false;
                    labelEBaseY.Enabled = false;
                    numericUpDownEBaseX.Enabled = false;
                    numericUpDownEBaseY.Enabled = false;
                    break;
                case(victoryConditions.DefendBase):
                    labelAlly.Enabled = false;
                    labelAllyX.Enabled = false;
                    labelAllyY.Enabled = false;
                    labelAllyDirection.Enabled = false;
                    numericUpDownAllyX.Enabled = false;
                    numericUpDownAllyY.Enabled = false;
                    comboBoxAllyDirection.Enabled = false;

                    labelEnemy.Enabled = false;
                    labelEnemyX.Enabled = false;
                    labelEnemyY.Enabled = false;
                    labelEnemyDirection.Enabled = false;
                    numericUpDownEnemyX.Enabled = false;
                    numericUpDownEnemyY.Enabled = false;
                    comboBoxEnemyDirection.Enabled = false;

                    labelAllyBase.Enabled = true;
                    labelABaseX.Enabled = true;
                    labelABaseY.Enabled = true;
                    numericUpDownABaseX.Enabled = true;
                    numericUpDownABaseY.Enabled = true;

                    labelEnemyBase.Enabled = false;
                    labelEBaseX.Enabled = false;
                    labelEBaseY.Enabled = false;
                    numericUpDownEBaseX.Enabled = false;
                    numericUpDownEBaseY.Enabled = false;
                    break;
                case(victoryConditions.DestroyBase):
                    labelAlly.Enabled = false;
                    labelAllyX.Enabled = false;
                    labelAllyY.Enabled = false;
                    labelAllyDirection.Enabled = false;
                    numericUpDownAllyX.Enabled = false;
                    numericUpDownAllyY.Enabled = false;
                    comboBoxAllyDirection.Enabled = false;

                    labelEnemy.Enabled = false;
                    labelEnemyX.Enabled = false;
                    labelEnemyY.Enabled = false;
                    labelEnemyDirection.Enabled = false;
                    numericUpDownEnemyX.Enabled = false;
                    numericUpDownEnemyY.Enabled = false;
                    comboBoxEnemyDirection.Enabled = false;

                    labelAllyBase.Enabled = false;
                    labelABaseX.Enabled = false;
                    labelABaseY.Enabled = false;
                    numericUpDownABaseX.Enabled = false;
                    numericUpDownABaseY.Enabled = false;

                    labelEnemyBase.Enabled = true;
                    labelEBaseX.Enabled = true;
                    labelEBaseY.Enabled = true;
                    numericUpDownEBaseX.Enabled = true;
                    numericUpDownEBaseY.Enabled = true;
                    break;
                case(victoryConditions.DoubleBase):
                    labelAlly.Enabled = false;
                    labelAllyX.Enabled = false;
                    labelAllyY.Enabled = false;
                    labelAllyDirection.Enabled = false;
                    numericUpDownAllyX.Enabled = false;
                    numericUpDownAllyY.Enabled = false;
                    comboBoxAllyDirection.Enabled = false;

                    labelEnemy.Enabled = false;
                    labelEnemyX.Enabled = false;
                    labelEnemyY.Enabled = false;
                    labelEnemyDirection.Enabled = false;
                    numericUpDownEnemyX.Enabled = false;
                    numericUpDownEnemyY.Enabled = false;
                    comboBoxEnemyDirection.Enabled = false;

                    labelAllyBase.Enabled = true;
                    labelABaseX.Enabled = true;
                    labelABaseY.Enabled = true;
                    numericUpDownABaseX.Enabled = true;
                    numericUpDownABaseY.Enabled = true;

                    labelEnemyBase.Enabled = true;
                    labelEBaseX.Enabled = true;
                    labelEBaseY.Enabled = true;
                    numericUpDownEBaseX.Enabled = true;
                    numericUpDownEBaseY.Enabled = true;
                    break;
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                MessageBox.Show("You must enter a level name before exporting.");
                return;
            }
            int fileNum = 1;
            try
            {
                //Level filenames should be CSkiesL#
                //If there are holes in the sequence the later levels won't be found
                //Looks for levels in an infinite loop until file isn't found
                for (fileNum = 1; fileNum > 0; fileNum++)
                {
                    StreamReader reader = new StreamReader("Levels/CSkiesL" + fileNum + ".txt");
                    reader.Close();
                }
            }
            catch (FileNotFoundException fnf)
            {
            }

            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter("Levels/CSkiesL" + fileNum + ".txt");
                writer.WriteLine("Level generated with the official Clockwork Skies level editor.");

                writer.WriteLine(":L-" + textBoxName.Text);
                writer.WriteLine(":T-" + numericUpDownTime.Value);
                writer.WriteLine(":V-" + (int)(victoryConditions)comboBoxVictory.SelectedItem);
                writer.WriteLine(":P-" + ((numericUpDownPlayerX.Value * 32) + 11) + "," + (numericUpDownPlayerY.Value * 32) + "," + (int)(directions)comboBoxPlayerDirection.SelectedItem);
                if ((victoryConditions)comboBoxVictory.SelectedItem == victoryConditions.Escort || (victoryConditions)comboBoxVictory.SelectedItem == victoryConditions.DoubleEscort)
                {
                    writer.WriteLine(":A-" + (numericUpDownAllyX.Value * 32) + "," + ((numericUpDownAllyY.Value * 32) + 12) + "," + (int)(directions)comboBoxAllyDirection.SelectedItem);
                }
                if ((victoryConditions)comboBoxVictory.SelectedItem == victoryConditions.EnemyEscort || (victoryConditions)comboBoxVictory.SelectedItem == victoryConditions.DoubleEscort)
                {
                    writer.WriteLine(":R-" + (numericUpDownEnemyX.Value * 32) + "," + ((numericUpDownEnemyY.Value * 32) + 12) + "," + (int)(directions)comboBoxEnemyDirection.SelectedItem);
                }
                if ((victoryConditions)comboBoxVictory.SelectedItem == victoryConditions.DefendBase || (victoryConditions)comboBoxVictory.SelectedItem == victoryConditions.DoubleBase)
                {
                    writer.WriteLine(":F-" + (numericUpDownABaseX.Value * 32) + "," + ((numericUpDownABaseY.Value * 32) + 12));
                }
                if ((victoryConditions)comboBoxVictory.SelectedItem == victoryConditions.DestroyBase || (victoryConditions)comboBoxVictory.SelectedItem == victoryConditions.DoubleBase)
                {
                    writer.WriteLine(":B-" + (numericUpDownEBaseX.Value * 32) + "," + ((numericUpDownEBaseY.Value * 32) + 12));
                }
                foreach (NPCControlSet set in NPCList)
                {
                    writer.WriteLine(":E-" + (set.xUpDown.Value * 32) + "," + ((set.yUpDown.Value * 32) + 12) + "," + (int)(directions)set.directionBox.SelectedItem + "," + (int)(NPCTypes)set.typeBox.SelectedItem);
                }
            }
            catch (Exception imanexceptiondammit)
            {
                MessageBox.Show("Something Fucked Up!");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

            MessageBox.Show("Level Export Complete");
        }



        //private void 

    }
}
