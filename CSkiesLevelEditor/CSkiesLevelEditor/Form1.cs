using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSkiesLevelEditor
{
    public partial class Form1 : Form
    {
        public static List<NPCControlSet> NPCList;

        public Form1()
        {
            InitializeComponent();
            NPCList = new List<NPCControlSet>();
            comboBoxAllyDirection.Items.Add("North");
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
            typeLabel.Name = "labelNPCType" + NPCList.Count;
            typeLabel.Size = new System.Drawing.Size(74, 16);
            typeLabel.TabIndex = 0;
            typeLabel.Text = "NPC Type:";
            panelNPCList.Controls.Add(typeLabel);

            Label xLabel = new Label();
            xLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xLabel.Location = new Point(139, (NPCList.Count * 30) + 4);
            xLabel.Name = "labelNPCX" + NPCList.Count;
            xLabel.Size = new System.Drawing.Size(19, 16);
            xLabel.TabIndex = 0;
            xLabel.Text = "X:";
            panelNPCList.Controls.Add(xLabel);

            Label yLabel = new Label();
            yLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            yLabel.Location = new Point(202, (NPCList.Count * 30) + 4);
            yLabel.Name = "labelNPCY" + NPCList.Count;
            yLabel.Size = new System.Drawing.Size(20, 16);
            yLabel.TabIndex = 0;
            yLabel.Text = "Y:";
            panelNPCList.Controls.Add(yLabel);

            Label directionLabel = new Label();
            directionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            directionLabel.Location = new Point(266, (NPCList.Count * 30) + 4);
            directionLabel.Name = "labelNPCDirection" + NPCList.Count;
            directionLabel.Size = new System.Drawing.Size(64, 16);
            directionLabel.TabIndex = 0;
            directionLabel.Text = "Direction:";
            panelNPCList.Controls.Add(directionLabel);

            ComboBox typeBox = new ComboBox();
            typeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            typeBox.FormattingEnabled = true;
            typeBox.Location = new System.Drawing.Point(84, (NPCList.Count * 30) + 4);
            typeBox.Name = "comboBoxNPCDirection" + NPCList.Count;
            typeBox.Size = new System.Drawing.Size(49, 21);
            typeBox.TabIndex = 3;
            panelNPCList.Controls.Add(typeBox);

            ComboBox directionBox = new ComboBox();
            directionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            directionBox.FormattingEnabled = true;
            directionBox.Location = new System.Drawing.Point(336, (NPCList.Count * 30) + 4);
            directionBox.Name = "comboBoxNPCDirection" + NPCList.Count;
            directionBox.Size = new System.Drawing.Size(49, 21);
            directionBox.TabIndex = 3;
            panelNPCList.Controls.Add(directionBox);

            NumericUpDown xUpDown = new NumericUpDown();
            xUpDown.Location = new System.Drawing.Point(164, (NPCList.Count * 30) + 4);
            xUpDown.Maximum = new decimal(new int[] {
            42,
            0,
            0,
            0});
            xUpDown.Name = "numericUpDownNPCX" + NPCList.Count;
            xUpDown.Size = new System.Drawing.Size(32, 20);
            xUpDown.TabIndex = 7;
            panelNPCList.Controls.Add(xUpDown);

            NumericUpDown yUpDown = new NumericUpDown();
            yUpDown.Location = new System.Drawing.Point(228, (NPCList.Count * 30) + 4);
            yUpDown.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            yUpDown.Name = "numericUpDownNPCX" + NPCList.Count;
            yUpDown.Size = new System.Drawing.Size(32, 20);
            yUpDown.TabIndex = 7;
            panelNPCList.Controls.Add(xUpDown);

            Button deleteButton = new Button();
            deleteButton.Location = new System.Drawing.Point(391, (NPCList.Count * 30) + 4);
            deleteButton.Name = "buttonNPCDelete" + NPCList.Count;
            deleteButton.Size = new System.Drawing.Size(75, 23);
            deleteButton.TabIndex = 14;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += new System.EventHandler(this.buttonNewNPC_Click);
        }


        //private void 

    }
}
