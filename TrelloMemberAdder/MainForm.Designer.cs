namespace TrelloMemberAdder
{
	partial class MainForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_tokenTextBox = new System.Windows.Forms.TextBox();
			this.m_keyTextBox = new System.Windows.Forms.TextBox();
			this.m_authButton = new System.Windows.Forms.Button();
			this.m_boardComboBox = new System.Windows.Forms.ComboBox();
			this.m_listComboBox = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.m_memberComboBox = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.m_addButton = new System.Windows.Forms.Button();
			this.m_removeButton = new System.Windows.Forms.Button();
			this.m_authLabel = new System.Windows.Forms.Label();
			this.m_progressBar = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 15);
			this.label1.TabIndex = 2;
			this.label1.Text = "API キー";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "Token";
			// 
			// m_tokenTextBox
			// 
			this.m_tokenTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TrelloMemberAdder.Properties.Settings.Default, "Token", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.m_tokenTextBox.Location = new System.Drawing.Point(76, 34);
			this.m_tokenTextBox.Name = "m_tokenTextBox";
			this.m_tokenTextBox.Size = new System.Drawing.Size(550, 22);
			this.m_tokenTextBox.TabIndex = 1;
			this.m_tokenTextBox.Text = global::TrelloMemberAdder.Properties.Settings.Default.Token;
			this.m_tokenTextBox.TextChanged += new System.EventHandler(this.OnInput);
			// 
			// m_keyTextBox
			// 
			this.m_keyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TrelloMemberAdder.Properties.Settings.Default, "Key", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.m_keyTextBox.Location = new System.Drawing.Point(76, 6);
			this.m_keyTextBox.Name = "m_keyTextBox";
			this.m_keyTextBox.Size = new System.Drawing.Size(275, 22);
			this.m_keyTextBox.TabIndex = 0;
			this.m_keyTextBox.Text = global::TrelloMemberAdder.Properties.Settings.Default.Key;
			this.m_keyTextBox.TextChanged += new System.EventHandler(this.OnInput);
			// 
			// m_authButton
			// 
			this.m_authButton.Location = new System.Drawing.Point(480, 62);
			this.m_authButton.Name = "m_authButton";
			this.m_authButton.Size = new System.Drawing.Size(150, 23);
			this.m_authButton.TabIndex = 4;
			this.m_authButton.Text = "認証";
			this.m_authButton.UseVisualStyleBackColor = true;
			this.m_authButton.Click += new System.EventHandler(this.authButton_Click);
			// 
			// m_boardComboBox
			// 
			this.m_boardComboBox.Enabled = false;
			this.m_boardComboBox.FormattingEnabled = true;
			this.m_boardComboBox.Location = new System.Drawing.Point(76, 91);
			this.m_boardComboBox.Name = "m_boardComboBox";
			this.m_boardComboBox.Size = new System.Drawing.Size(550, 23);
			this.m_boardComboBox.TabIndex = 5;
			this.m_boardComboBox.SelectedValueChanged += new System.EventHandler(this.m_boardComboBox_SelectedValueChanged);
			// 
			// m_listComboBox
			// 
			this.m_listComboBox.Enabled = false;
			this.m_listComboBox.FormattingEnabled = true;
			this.m_listComboBox.Location = new System.Drawing.Point(76, 120);
			this.m_listComboBox.Name = "m_listComboBox";
			this.m_listComboBox.Size = new System.Drawing.Size(550, 23);
			this.m_listComboBox.TabIndex = 6;
			this.m_listComboBox.SelectedValueChanged += new System.EventHandler(this.OnSelected);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 94);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 15);
			this.label3.TabIndex = 7;
			this.label3.Text = "ボード";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 123);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 15);
			this.label4.TabIndex = 8;
			this.label4.Text = "リスト";
			// 
			// m_memberComboBox
			// 
			this.m_memberComboBox.Enabled = false;
			this.m_memberComboBox.FormattingEnabled = true;
			this.m_memberComboBox.Location = new System.Drawing.Point(76, 149);
			this.m_memberComboBox.Name = "m_memberComboBox";
			this.m_memberComboBox.Size = new System.Drawing.Size(550, 23);
			this.m_memberComboBox.TabIndex = 9;
			this.m_memberComboBox.SelectedValueChanged += new System.EventHandler(this.OnSelected);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 152);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 15);
			this.label5.TabIndex = 10;
			this.label5.Text = "メンバー";
			// 
			// m_addButton
			// 
			this.m_addButton.Enabled = false;
			this.m_addButton.Location = new System.Drawing.Point(324, 188);
			this.m_addButton.Name = "m_addButton";
			this.m_addButton.Size = new System.Drawing.Size(150, 23);
			this.m_addButton.TabIndex = 11;
			this.m_addButton.Text = "追加";
			this.m_addButton.UseVisualStyleBackColor = true;
			this.m_addButton.Click += new System.EventHandler(this.m_addButton_Click);
			// 
			// m_removeButton
			// 
			this.m_removeButton.Enabled = false;
			this.m_removeButton.Location = new System.Drawing.Point(480, 188);
			this.m_removeButton.Name = "m_removeButton";
			this.m_removeButton.Size = new System.Drawing.Size(150, 23);
			this.m_removeButton.TabIndex = 12;
			this.m_removeButton.Text = "削除";
			this.m_removeButton.UseVisualStyleBackColor = true;
			this.m_removeButton.Click += new System.EventHandler(this.m_removeButton_Click);
			// 
			// m_authLabel
			// 
			this.m_authLabel.AutoSize = true;
			this.m_authLabel.ForeColor = System.Drawing.Color.Green;
			this.m_authLabel.Location = new System.Drawing.Point(409, 66);
			this.m_authLabel.Name = "m_authLabel";
			this.m_authLabel.Size = new System.Drawing.Size(65, 15);
			this.m_authLabel.TabIndex = 13;
			this.m_authLabel.Text = "認証済み";
			// 
			// m_progressBar
			// 
			this.m_progressBar.Location = new System.Drawing.Point(15, 188);
			this.m_progressBar.Name = "m_progressBar";
			this.m_progressBar.Size = new System.Drawing.Size(303, 23);
			this.m_progressBar.TabIndex = 14;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(642, 223);
			this.Controls.Add(this.m_progressBar);
			this.Controls.Add(this.m_authLabel);
			this.Controls.Add(this.m_removeButton);
			this.Controls.Add(this.m_addButton);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.m_memberComboBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_listComboBox);
			this.Controls.Add(this.m_boardComboBox);
			this.Controls.Add(this.m_authButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_tokenTextBox);
			this.Controls.Add(this.m_keyTextBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "Trello メンバー追加くん";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox m_keyTextBox;
		private System.Windows.Forms.TextBox m_tokenTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button m_authButton;
		private System.Windows.Forms.ComboBox m_boardComboBox;
		private System.Windows.Forms.ComboBox m_listComboBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox m_memberComboBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button m_addButton;
		private System.Windows.Forms.Button m_removeButton;
		private System.Windows.Forms.Label m_authLabel;
		private System.Windows.Forms.ProgressBar m_progressBar;
	}
}

