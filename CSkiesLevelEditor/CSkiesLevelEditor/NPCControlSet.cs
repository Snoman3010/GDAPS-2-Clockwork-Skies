using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSkiesLevelEditor
{
    public class NPCControlSet
    {
        private Label typeLabel;
        private Label xLabel;
        private Label yLabel;
        private Label directionLabel;
        private ComboBox typeBox;
        private ComboBox directionBox;
        private NumericUpDown xUpDown;
        private NumericUpDown yUpDown;
        private Button deleteButton;
        private int position;

        public NPCControlSet(int pos, Label tL, ComboBox tB, Label xL, NumericUpDown xUD, Label yL, NumericUpDown yUD, Label dL, ComboBox dB, Button button)
        {
            position = pos;
            typeLabel = tL;
            xLabel = xL;
            yLabel = yL;
            directionLabel = dL;
            typeBox = tB;
            directionBox = dB;
            xUpDown = xUD;
            yUpDown = yUD;
            deleteButton = button;
        }

        public void moveUp()
        {
            typeLabel.Location = new System.Drawing.Point(typeLabel.Location.X, typeLabel.Location.Y - 30);
            xLabel.Location = new System.Drawing.Point(xLabel.Location.X, xLabel.Location.Y - 30);
            yLabel.Location = new System.Drawing.Point(yLabel.Location.X, yLabel.Location.Y - 30);
            directionLabel.Location = new System.Drawing.Point(directionLabel.Location.X, directionLabel.Location.Y - 30);
            typeBox.Location = new System.Drawing.Point(typeBox.Location.X, typeBox.Location.Y - 30);
            directionBox.Location = new System.Drawing.Point(directionBox.Location.X, directionBox.Location.Y - 30);
            xUpDown.Location = new System.Drawing.Point(xUpDown.Location.X, xUpDown.Location.Y - 30);
            yUpDown.Location = new System.Drawing.Point(yUpDown.Location.X, yUpDown.Location.Y - 30);
            deleteButton.Location = new System.Drawing.Point(deleteButton.Location.X, deleteButton.Location.Y - 30);
            position--;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            typeLabel.Dispose();
            xLabel.Dispose();
            yLabel.Dispose();
            directionLabel.Dispose();
            typeBox.Dispose();
            directionBox.Dispose();
            xUpDown.Dispose();
            yUpDown.Dispose();
            deleteButton.Dispose();
            Form1.NPCList.RemoveAt(position);
            for (int i = position; i < Form1.NPCList.Count; i++)
            {
                Form1.NPCList[i].moveUp();
            }
        }
    }
}
