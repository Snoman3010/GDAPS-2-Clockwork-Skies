namespace CSkiesLevelEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelLevel = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelVictory = new System.Windows.Forms.Label();
            this.comboBoxVictory = new System.Windows.Forms.ComboBox();
            this.numericUpDownTime = new System.Windows.Forms.NumericUpDown();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelAlly = new System.Windows.Forms.Label();
            this.numericUpDownAllyX = new System.Windows.Forms.NumericUpDown();
            this.labelAllyX = new System.Windows.Forms.Label();
            this.labelAllyY = new System.Windows.Forms.Label();
            this.numericUpDownAllyY = new System.Windows.Forms.NumericUpDown();
            this.labelAllyDirection = new System.Windows.Forms.Label();
            this.comboBoxAllyDirection = new System.Windows.Forms.ComboBox();
            this.comboBoxEnemyDirection = new System.Windows.Forms.ComboBox();
            this.labelEnemy = new System.Windows.Forms.Label();
            this.numericUpDownEnemyX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownEnemyY = new System.Windows.Forms.NumericUpDown();
            this.labelEnemyX = new System.Windows.Forms.Label();
            this.labelEnemyY = new System.Windows.Forms.Label();
            this.labelEnemyDirection = new System.Windows.Forms.Label();
            this.labelAllyBase = new System.Windows.Forms.Label();
            this.numericUpDownABaseX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownABaseY = new System.Windows.Forms.NumericUpDown();
            this.labelABaseX = new System.Windows.Forms.Label();
            this.labelABaseY = new System.Windows.Forms.Label();
            this.labelEnemyBase = new System.Windows.Forms.Label();
            this.numericUpDownEBaseX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownEBaseY = new System.Windows.Forms.NumericUpDown();
            this.labelEBaseX = new System.Windows.Forms.Label();
            this.labelEBaseY = new System.Windows.Forms.Label();
            this.comboBoxPlayerDirection = new System.Windows.Forms.ComboBox();
            this.labelPlayer = new System.Windows.Forms.Label();
            this.numericUpDownPlayerX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPlayerY = new System.Windows.Forms.NumericUpDown();
            this.labelPlayerX = new System.Windows.Forms.Label();
            this.labelPlayerY = new System.Windows.Forms.Label();
            this.labelPlayerDirection = new System.Windows.Forms.Label();
            this.panelNPCList = new System.Windows.Forms.Panel();
            this.labelNPC = new System.Windows.Forms.Label();
            this.buttonNewNPC = new System.Windows.Forms.Button();
            this.labelExport = new System.Windows.Forms.Label();
            this.buttonExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAllyX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAllyY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnemyX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnemyY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownABaseX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownABaseY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEBaseX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEBaseY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayerX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayerY)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLevel.Location = new System.Drawing.Point(13, 13);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(84, 16);
            this.labelLevel.TabIndex = 0;
            this.labelLevel.Text = "Level Name:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(128, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(180, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // labelVictory
            // 
            this.labelVictory.AutoSize = true;
            this.labelVictory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVictory.Location = new System.Drawing.Point(12, 40);
            this.labelVictory.Name = "labelVictory";
            this.labelVictory.Size = new System.Drawing.Size(111, 16);
            this.labelVictory.TabIndex = 2;
            this.labelVictory.Text = "Victory Condition:";
            // 
            // comboBoxVictory
            // 
            this.comboBoxVictory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVictory.FormattingEnabled = true;
            this.comboBoxVictory.Location = new System.Drawing.Point(129, 39);
            this.comboBoxVictory.Name = "comboBoxVictory";
            this.comboBoxVictory.Size = new System.Drawing.Size(163, 21);
            this.comboBoxVictory.TabIndex = 3;
            this.comboBoxVictory.SelectedIndexChanged += new System.EventHandler(this.comboBoxVictory_SelectedIndexChanged);
            // 
            // numericUpDownTime
            // 
            this.numericUpDownTime.Location = new System.Drawing.Point(457, 13);
            this.numericUpDownTime.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDownTime.Name = "numericUpDownTime";
            this.numericUpDownTime.Size = new System.Drawing.Size(42, 20);
            this.numericUpDownTime.TabIndex = 4;
            this.numericUpDownTime.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(314, 13);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(137, 16);
            this.labelTime.TabIndex = 5;
            this.labelTime.Text = "Time Limit (Seconds):";
            // 
            // labelAlly
            // 
            this.labelAlly.AutoSize = true;
            this.labelAlly.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlly.Location = new System.Drawing.Point(12, 74);
            this.labelAlly.Name = "labelAlly";
            this.labelAlly.Size = new System.Drawing.Size(76, 16);
            this.labelAlly.TabIndex = 6;
            this.labelAlly.Text = "Target Ally:";
            // 
            // numericUpDownAllyX
            // 
            this.numericUpDownAllyX.Location = new System.Drawing.Point(38, 94);
            this.numericUpDownAllyX.Maximum = new decimal(new int[] {
            42,
            0,
            0,
            0});
            this.numericUpDownAllyX.Name = "numericUpDownAllyX";
            this.numericUpDownAllyX.Size = new System.Drawing.Size(32, 20);
            this.numericUpDownAllyX.TabIndex = 7;
            // 
            // labelAllyX
            // 
            this.labelAllyX.AutoSize = true;
            this.labelAllyX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAllyX.Location = new System.Drawing.Point(13, 94);
            this.labelAllyX.Name = "labelAllyX";
            this.labelAllyX.Size = new System.Drawing.Size(19, 16);
            this.labelAllyX.TabIndex = 9;
            this.labelAllyX.Text = "X:";
            // 
            // labelAllyY
            // 
            this.labelAllyY.AutoSize = true;
            this.labelAllyY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAllyY.Location = new System.Drawing.Point(76, 94);
            this.labelAllyY.Name = "labelAllyY";
            this.labelAllyY.Size = new System.Drawing.Size(20, 16);
            this.labelAllyY.TabIndex = 10;
            this.labelAllyY.Text = "Y:";
            // 
            // numericUpDownAllyY
            // 
            this.numericUpDownAllyY.Location = new System.Drawing.Point(102, 94);
            this.numericUpDownAllyY.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownAllyY.Name = "numericUpDownAllyY";
            this.numericUpDownAllyY.Size = new System.Drawing.Size(32, 20);
            this.numericUpDownAllyY.TabIndex = 7;
            // 
            // labelAllyDirection
            // 
            this.labelAllyDirection.AutoSize = true;
            this.labelAllyDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAllyDirection.Location = new System.Drawing.Point(140, 94);
            this.labelAllyDirection.Name = "labelAllyDirection";
            this.labelAllyDirection.Size = new System.Drawing.Size(64, 16);
            this.labelAllyDirection.TabIndex = 11;
            this.labelAllyDirection.Text = "Direction:";
            // 
            // comboBoxAllyDirection
            // 
            this.comboBoxAllyDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAllyDirection.FormattingEnabled = true;
            this.comboBoxAllyDirection.Location = new System.Drawing.Point(210, 93);
            this.comboBoxAllyDirection.Name = "comboBoxAllyDirection";
            this.comboBoxAllyDirection.Size = new System.Drawing.Size(49, 21);
            this.comboBoxAllyDirection.TabIndex = 3;
            // 
            // comboBoxEnemyDirection
            // 
            this.comboBoxEnemyDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEnemyDirection.FormattingEnabled = true;
            this.comboBoxEnemyDirection.Location = new System.Drawing.Point(486, 93);
            this.comboBoxEnemyDirection.Name = "comboBoxEnemyDirection";
            this.comboBoxEnemyDirection.Size = new System.Drawing.Size(49, 21);
            this.comboBoxEnemyDirection.TabIndex = 3;
            this.comboBoxEnemyDirection.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // labelEnemy
            // 
            this.labelEnemy.AutoSize = true;
            this.labelEnemy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnemy.Location = new System.Drawing.Point(288, 74);
            this.labelEnemy.Name = "labelEnemy";
            this.labelEnemy.Size = new System.Drawing.Size(96, 16);
            this.labelEnemy.TabIndex = 6;
            this.labelEnemy.Text = "Target Enemy:";
            this.labelEnemy.Click += new System.EventHandler(this.label8_Click);
            // 
            // numericUpDownEnemyX
            // 
            this.numericUpDownEnemyX.Location = new System.Drawing.Point(314, 94);
            this.numericUpDownEnemyX.Maximum = new decimal(new int[] {
            42,
            0,
            0,
            0});
            this.numericUpDownEnemyX.Name = "numericUpDownEnemyX";
            this.numericUpDownEnemyX.Size = new System.Drawing.Size(32, 20);
            this.numericUpDownEnemyX.TabIndex = 7;
            this.numericUpDownEnemyX.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // numericUpDownEnemyY
            // 
            this.numericUpDownEnemyY.Location = new System.Drawing.Point(378, 94);
            this.numericUpDownEnemyY.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownEnemyY.Name = "numericUpDownEnemyY";
            this.numericUpDownEnemyY.Size = new System.Drawing.Size(32, 20);
            this.numericUpDownEnemyY.TabIndex = 7;
            this.numericUpDownEnemyY.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // labelEnemyX
            // 
            this.labelEnemyX.AutoSize = true;
            this.labelEnemyX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnemyX.Location = new System.Drawing.Point(289, 94);
            this.labelEnemyX.Name = "labelEnemyX";
            this.labelEnemyX.Size = new System.Drawing.Size(19, 16);
            this.labelEnemyX.TabIndex = 9;
            this.labelEnemyX.Text = "X:";
            this.labelEnemyX.Click += new System.EventHandler(this.label10_Click);
            // 
            // labelEnemyY
            // 
            this.labelEnemyY.AutoSize = true;
            this.labelEnemyY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnemyY.Location = new System.Drawing.Point(352, 94);
            this.labelEnemyY.Name = "labelEnemyY";
            this.labelEnemyY.Size = new System.Drawing.Size(20, 16);
            this.labelEnemyY.TabIndex = 10;
            this.labelEnemyY.Text = "Y:";
            this.labelEnemyY.Click += new System.EventHandler(this.label11_Click);
            // 
            // labelEnemyDirection
            // 
            this.labelEnemyDirection.AutoSize = true;
            this.labelEnemyDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnemyDirection.Location = new System.Drawing.Point(416, 94);
            this.labelEnemyDirection.Name = "labelEnemyDirection";
            this.labelEnemyDirection.Size = new System.Drawing.Size(64, 16);
            this.labelEnemyDirection.TabIndex = 11;
            this.labelEnemyDirection.Text = "Direction:";
            this.labelEnemyDirection.Click += new System.EventHandler(this.label12_Click);
            // 
            // labelAllyBase
            // 
            this.labelAllyBase.AutoSize = true;
            this.labelAllyBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAllyBase.Location = new System.Drawing.Point(12, 130);
            this.labelAllyBase.Name = "labelAllyBase";
            this.labelAllyBase.Size = new System.Drawing.Size(80, 16);
            this.labelAllyBase.TabIndex = 6;
            this.labelAllyBase.Text = "Allied Base:";
            // 
            // numericUpDownABaseX
            // 
            this.numericUpDownABaseX.Location = new System.Drawing.Point(38, 150);
            this.numericUpDownABaseX.Maximum = new decimal(new int[] {
            42,
            0,
            0,
            0});
            this.numericUpDownABaseX.Name = "numericUpDownABaseX";
            this.numericUpDownABaseX.Size = new System.Drawing.Size(32, 20);
            this.numericUpDownABaseX.TabIndex = 7;
            // 
            // numericUpDownABaseY
            // 
            this.numericUpDownABaseY.Location = new System.Drawing.Point(102, 150);
            this.numericUpDownABaseY.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownABaseY.Name = "numericUpDownABaseY";
            this.numericUpDownABaseY.Size = new System.Drawing.Size(32, 20);
            this.numericUpDownABaseY.TabIndex = 7;
            // 
            // labelABaseX
            // 
            this.labelABaseX.AutoSize = true;
            this.labelABaseX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelABaseX.Location = new System.Drawing.Point(13, 150);
            this.labelABaseX.Name = "labelABaseX";
            this.labelABaseX.Size = new System.Drawing.Size(19, 16);
            this.labelABaseX.TabIndex = 9;
            this.labelABaseX.Text = "X:";
            // 
            // labelABaseY
            // 
            this.labelABaseY.AutoSize = true;
            this.labelABaseY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelABaseY.Location = new System.Drawing.Point(76, 150);
            this.labelABaseY.Name = "labelABaseY";
            this.labelABaseY.Size = new System.Drawing.Size(20, 16);
            this.labelABaseY.TabIndex = 10;
            this.labelABaseY.Text = "Y:";
            // 
            // labelEnemyBase
            // 
            this.labelEnemyBase.AutoSize = true;
            this.labelEnemyBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnemyBase.Location = new System.Drawing.Point(288, 130);
            this.labelEnemyBase.Name = "labelEnemyBase";
            this.labelEnemyBase.Size = new System.Drawing.Size(88, 16);
            this.labelEnemyBase.TabIndex = 6;
            this.labelEnemyBase.Text = "Enemy Base:";
            // 
            // numericUpDownEBaseX
            // 
            this.numericUpDownEBaseX.Location = new System.Drawing.Point(314, 150);
            this.numericUpDownEBaseX.Maximum = new decimal(new int[] {
            42,
            0,
            0,
            0});
            this.numericUpDownEBaseX.Name = "numericUpDownEBaseX";
            this.numericUpDownEBaseX.Size = new System.Drawing.Size(32, 20);
            this.numericUpDownEBaseX.TabIndex = 7;
            // 
            // numericUpDownEBaseY
            // 
            this.numericUpDownEBaseY.Location = new System.Drawing.Point(378, 150);
            this.numericUpDownEBaseY.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownEBaseY.Name = "numericUpDownEBaseY";
            this.numericUpDownEBaseY.Size = new System.Drawing.Size(32, 20);
            this.numericUpDownEBaseY.TabIndex = 7;
            // 
            // labelEBaseX
            // 
            this.labelEBaseX.AutoSize = true;
            this.labelEBaseX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEBaseX.Location = new System.Drawing.Point(289, 150);
            this.labelEBaseX.Name = "labelEBaseX";
            this.labelEBaseX.Size = new System.Drawing.Size(19, 16);
            this.labelEBaseX.TabIndex = 9;
            this.labelEBaseX.Text = "X:";
            // 
            // labelEBaseY
            // 
            this.labelEBaseY.AutoSize = true;
            this.labelEBaseY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEBaseY.Location = new System.Drawing.Point(352, 150);
            this.labelEBaseY.Name = "labelEBaseY";
            this.labelEBaseY.Size = new System.Drawing.Size(20, 16);
            this.labelEBaseY.TabIndex = 10;
            this.labelEBaseY.Text = "Y:";
            // 
            // comboBoxPlayerDirection
            // 
            this.comboBoxPlayerDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlayerDirection.FormattingEnabled = true;
            this.comboBoxPlayerDirection.Location = new System.Drawing.Point(210, 209);
            this.comboBoxPlayerDirection.Name = "comboBoxPlayerDirection";
            this.comboBoxPlayerDirection.Size = new System.Drawing.Size(49, 21);
            this.comboBoxPlayerDirection.TabIndex = 3;
            this.comboBoxPlayerDirection.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // labelPlayer
            // 
            this.labelPlayer.AutoSize = true;
            this.labelPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer.Location = new System.Drawing.Point(12, 190);
            this.labelPlayer.Name = "labelPlayer";
            this.labelPlayer.Size = new System.Drawing.Size(131, 16);
            this.labelPlayer.TabIndex = 6;
            this.labelPlayer.Text = "Player Start Position:";
            this.labelPlayer.Click += new System.EventHandler(this.label8_Click);
            // 
            // numericUpDownPlayerX
            // 
            this.numericUpDownPlayerX.Location = new System.Drawing.Point(38, 210);
            this.numericUpDownPlayerX.Maximum = new decimal(new int[] {
            42,
            0,
            0,
            0});
            this.numericUpDownPlayerX.Name = "numericUpDownPlayerX";
            this.numericUpDownPlayerX.Size = new System.Drawing.Size(32, 20);
            this.numericUpDownPlayerX.TabIndex = 7;
            this.numericUpDownPlayerX.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // numericUpDownPlayerY
            // 
            this.numericUpDownPlayerY.Location = new System.Drawing.Point(102, 210);
            this.numericUpDownPlayerY.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownPlayerY.Name = "numericUpDownPlayerY";
            this.numericUpDownPlayerY.Size = new System.Drawing.Size(32, 20);
            this.numericUpDownPlayerY.TabIndex = 7;
            this.numericUpDownPlayerY.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // labelPlayerX
            // 
            this.labelPlayerX.AutoSize = true;
            this.labelPlayerX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayerX.Location = new System.Drawing.Point(13, 210);
            this.labelPlayerX.Name = "labelPlayerX";
            this.labelPlayerX.Size = new System.Drawing.Size(19, 16);
            this.labelPlayerX.TabIndex = 9;
            this.labelPlayerX.Text = "X:";
            this.labelPlayerX.Click += new System.EventHandler(this.label10_Click);
            // 
            // labelPlayerY
            // 
            this.labelPlayerY.AutoSize = true;
            this.labelPlayerY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayerY.Location = new System.Drawing.Point(76, 210);
            this.labelPlayerY.Name = "labelPlayerY";
            this.labelPlayerY.Size = new System.Drawing.Size(20, 16);
            this.labelPlayerY.TabIndex = 10;
            this.labelPlayerY.Text = "Y:";
            this.labelPlayerY.Click += new System.EventHandler(this.label11_Click);
            // 
            // labelPlayerDirection
            // 
            this.labelPlayerDirection.AutoSize = true;
            this.labelPlayerDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayerDirection.Location = new System.Drawing.Point(140, 210);
            this.labelPlayerDirection.Name = "labelPlayerDirection";
            this.labelPlayerDirection.Size = new System.Drawing.Size(64, 16);
            this.labelPlayerDirection.TabIndex = 11;
            this.labelPlayerDirection.Text = "Direction:";
            this.labelPlayerDirection.Click += new System.EventHandler(this.label12_Click);
            // 
            // panelNPCList
            // 
            this.panelNPCList.AutoScroll = true;
            this.panelNPCList.Location = new System.Drawing.Point(16, 267);
            this.panelNPCList.Name = "panelNPCList";
            this.panelNPCList.Size = new System.Drawing.Size(559, 194);
            this.panelNPCList.TabIndex = 12;
            // 
            // labelNPC
            // 
            this.labelNPC.AutoSize = true;
            this.labelNPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNPC.Location = new System.Drawing.Point(13, 243);
            this.labelNPC.Name = "labelNPC";
            this.labelNPC.Size = new System.Drawing.Size(62, 16);
            this.labelNPC.TabIndex = 13;
            this.labelNPC.Text = "NPC List:";
            // 
            // buttonNewNPC
            // 
            this.buttonNewNPC.Location = new System.Drawing.Point(82, 240);
            this.buttonNewNPC.Name = "buttonNewNPC";
            this.buttonNewNPC.Size = new System.Drawing.Size(75, 23);
            this.buttonNewNPC.TabIndex = 14;
            this.buttonNewNPC.Text = "New";
            this.buttonNewNPC.UseVisualStyleBackColor = true;
            this.buttonNewNPC.Click += new System.EventHandler(this.buttonNewNPC_Click);
            // 
            // labelExport
            // 
            this.labelExport.AutoSize = true;
            this.labelExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExport.Location = new System.Drawing.Point(289, 210);
            this.labelExport.Name = "labelExport";
            this.labelExport.Size = new System.Drawing.Size(85, 16);
            this.labelExport.TabIndex = 15;
            this.labelExport.Text = "Export Level:";
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(380, 207);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 16;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 473);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.labelExport);
            this.Controls.Add(this.buttonNewNPC);
            this.Controls.Add(this.labelNPC);
            this.Controls.Add(this.panelNPCList);
            this.Controls.Add(this.labelPlayerDirection);
            this.Controls.Add(this.labelEnemyDirection);
            this.Controls.Add(this.labelAllyDirection);
            this.Controls.Add(this.labelPlayerY);
            this.Controls.Add(this.labelEnemyY);
            this.Controls.Add(this.labelEBaseY);
            this.Controls.Add(this.labelABaseY);
            this.Controls.Add(this.labelAllyY);
            this.Controls.Add(this.labelPlayerX);
            this.Controls.Add(this.labelEnemyX);
            this.Controls.Add(this.labelEBaseX);
            this.Controls.Add(this.labelABaseX);
            this.Controls.Add(this.labelAllyX);
            this.Controls.Add(this.numericUpDownPlayerY);
            this.Controls.Add(this.numericUpDownEnemyY);
            this.Controls.Add(this.numericUpDownEBaseY);
            this.Controls.Add(this.numericUpDownPlayerX);
            this.Controls.Add(this.numericUpDownEnemyX);
            this.Controls.Add(this.numericUpDownABaseY);
            this.Controls.Add(this.numericUpDownAllyY);
            this.Controls.Add(this.numericUpDownEBaseX);
            this.Controls.Add(this.labelPlayer);
            this.Controls.Add(this.labelEnemy);
            this.Controls.Add(this.numericUpDownABaseX);
            this.Controls.Add(this.labelEnemyBase);
            this.Controls.Add(this.numericUpDownAllyX);
            this.Controls.Add(this.labelAllyBase);
            this.Controls.Add(this.labelAlly);
            this.Controls.Add(this.comboBoxPlayerDirection);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.comboBoxEnemyDirection);
            this.Controls.Add(this.numericUpDownTime);
            this.Controls.Add(this.comboBoxAllyDirection);
            this.Controls.Add(this.comboBoxVictory);
            this.Controls.Add(this.labelVictory);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelLevel);
            this.Name = "Form1";
            this.Text = "Clockwork Skies Level Editor";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAllyX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAllyY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnemyX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnemyY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownABaseX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownABaseY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEBaseX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEBaseY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayerX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayerY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelVictory;
        private System.Windows.Forms.ComboBox comboBoxVictory;
        private System.Windows.Forms.NumericUpDown numericUpDownTime;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelAlly;
        private System.Windows.Forms.NumericUpDown numericUpDownAllyX;
        private System.Windows.Forms.Label labelAllyX;
        private System.Windows.Forms.Label labelAllyY;
        private System.Windows.Forms.NumericUpDown numericUpDownAllyY;
        private System.Windows.Forms.Label labelAllyDirection;
        private System.Windows.Forms.ComboBox comboBoxAllyDirection;
        private System.Windows.Forms.ComboBox comboBoxEnemyDirection;
        private System.Windows.Forms.Label labelEnemy;
        private System.Windows.Forms.NumericUpDown numericUpDownEnemyX;
        private System.Windows.Forms.NumericUpDown numericUpDownEnemyY;
        private System.Windows.Forms.Label labelEnemyX;
        private System.Windows.Forms.Label labelEnemyY;
        private System.Windows.Forms.Label labelEnemyDirection;
        private System.Windows.Forms.Label labelAllyBase;
        private System.Windows.Forms.NumericUpDown numericUpDownABaseX;
        private System.Windows.Forms.NumericUpDown numericUpDownABaseY;
        private System.Windows.Forms.Label labelABaseX;
        private System.Windows.Forms.Label labelABaseY;
        private System.Windows.Forms.Label labelEnemyBase;
        private System.Windows.Forms.NumericUpDown numericUpDownEBaseX;
        private System.Windows.Forms.NumericUpDown numericUpDownEBaseY;
        private System.Windows.Forms.Label labelEBaseX;
        private System.Windows.Forms.Label labelEBaseY;
        private System.Windows.Forms.ComboBox comboBoxPlayerDirection;
        private System.Windows.Forms.Label labelPlayer;
        private System.Windows.Forms.NumericUpDown numericUpDownPlayerX;
        private System.Windows.Forms.NumericUpDown numericUpDownPlayerY;
        private System.Windows.Forms.Label labelPlayerX;
        private System.Windows.Forms.Label labelPlayerY;
        private System.Windows.Forms.Label labelPlayerDirection;
        private System.Windows.Forms.Panel panelNPCList;
        private System.Windows.Forms.Label labelNPC;
        private System.Windows.Forms.Button buttonNewNPC;
        private System.Windows.Forms.Label labelExport;
        private System.Windows.Forms.Button buttonExport;
    }
}

