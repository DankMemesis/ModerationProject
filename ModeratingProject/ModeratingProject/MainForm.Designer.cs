namespace ModeratingProject
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.Password = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.Label();
            this._textBoxUsername = new System.Windows.Forms.TextBox();
            this._textBoxPassword = new System.Windows.Forms.TextBox();
            this._dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this._columnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnBan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UserBox = new System.Windows.Forms.GroupBox();
            this.Search = new System.Windows.Forms.Label();
            this._textBoxSearch = new System.Windows.Forms.TextBox();
            this._checkBoxBan = new System.Windows.Forms.CheckBox();
            this._buttonSave = new System.Windows.Forms.Button();
            this._buttonPrevious = new System.Windows.Forms.Button();
            this._buttonAdd = new System.Windows.Forms.Button();
            this._buttonDelete = new System.Windows.Forms.Button();
            this._buttonNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userModelBindingSource)).BeginInit();
            this.UserBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(56, 175);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(57, 15);
            this.Password.TabIndex = 18;
            this.Password.Text = "Password";
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Location = new System.Drawing.Point(56, 149);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(60, 15);
            this.Username.TabIndex = 17;
            this.Username.Text = "Username";
            // 
            // _textBoxUsername
            // 
            this._textBoxUsername.Location = new System.Drawing.Point(134, 146);
            this._textBoxUsername.Name = "_textBoxUsername";
            this._textBoxUsername.Size = new System.Drawing.Size(156, 23);
            this._textBoxUsername.TabIndex = 16;
            // 
            // _textBoxPassword
            // 
            this._textBoxPassword.Location = new System.Drawing.Point(134, 175);
            this._textBoxPassword.Name = "_textBoxPassword";
            this._textBoxPassword.Size = new System.Drawing.Size(156, 23);
            this._textBoxPassword.TabIndex = 15;
            // 
            // _dataGridViewUsers
            // 
            this._dataGridViewUsers.AllowUserToAddRows = false;
            this._dataGridViewUsers.AllowUserToDeleteRows = false;
            this._dataGridViewUsers.AutoGenerateColumns = false;
            this._dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._columnId,
            this._columnUsername,
            this._columnPassword,
            this._columnBan,
            this.OrderNumber});
            this._dataGridViewUsers.DataSource = this.userModelBindingSource;
            this._dataGridViewUsers.Location = new System.Drawing.Point(355, 40);
            this._dataGridViewUsers.Name = "_dataGridViewUsers";
            this._dataGridViewUsers.ReadOnly = true;
            this._dataGridViewUsers.RowTemplate.Height = 25;
            this._dataGridViewUsers.Size = new System.Drawing.Size(409, 370);
            this._dataGridViewUsers.TabIndex = 14;
            this._dataGridViewUsers.UseWaitCursor = true;
            // 
            // _columnId
            // 
            this._columnId.DataPropertyName = "Id";
            this._columnId.HeaderText = "Id";
            this._columnId.Name = "_columnId";
            this._columnId.ReadOnly = true;
            // 
            // _columnUsername
            // 
            this._columnUsername.DataPropertyName = "Username";
            this._columnUsername.HeaderText = "Username";
            this._columnUsername.Name = "_columnUsername";
            this._columnUsername.ReadOnly = true;
            // 
            // _columnPassword
            // 
            this._columnPassword.DataPropertyName = "Password";
            this._columnPassword.HeaderText = "Password";
            this._columnPassword.Name = "_columnPassword";
            this._columnPassword.ReadOnly = true;
            // 
            // _columnBan
            // 
            this._columnBan.DataPropertyName = "Ban";
            this._columnBan.HeaderText = "Ban";
            this._columnBan.Name = "_columnBan";
            this._columnBan.ReadOnly = true;
            // 
            // OrderNumber
            // 
            this.OrderNumber.DataPropertyName = "OrderNumber";
            this.OrderNumber.HeaderText = "OrderNumber";
            this.OrderNumber.Name = "OrderNumber";
            this.OrderNumber.ReadOnly = true;
            // 
            // userModelBindingSource
            // 
            this.userModelBindingSource.DataSource = typeof(ModeratingProject.Models.UserModel);
            // 
            // UserBox
            // 
            this.UserBox.Controls.Add(this.Search);
            this.UserBox.Controls.Add(this._textBoxSearch);
            this.UserBox.Controls.Add(this._checkBoxBan);
            this.UserBox.Controls.Add(this._buttonSave);
            this.UserBox.Controls.Add(this._buttonPrevious);
            this.UserBox.Controls.Add(this._buttonAdd);
            this.UserBox.Controls.Add(this._buttonDelete);
            this.UserBox.Controls.Add(this._buttonNext);
            this.UserBox.Location = new System.Drawing.Point(42, 109);
            this.UserBox.Name = "UserBox";
            this.UserBox.Size = new System.Drawing.Size(277, 285);
            this.UserBox.TabIndex = 21;
            this.UserBox.TabStop = false;
            this.UserBox.Text = "User";
            // 
            // Search
            // 
            this.Search.AutoSize = true;
            this.Search.Location = new System.Drawing.Point(14, 226);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(42, 15);
            this.Search.TabIndex = 10;
            this.Search.Text = "Search";
            // 
            // _textBoxSearch
            // 
            this._textBoxSearch.Location = new System.Drawing.Point(92, 223);
            this._textBoxSearch.Name = "_textBoxSearch";
            this._textBoxSearch.Size = new System.Drawing.Size(156, 23);
            this._textBoxSearch.TabIndex = 9;
            this._textBoxSearch.TextChanged += new System.EventHandler(this._textBoxSearch_TextChanged);
            // 
            // _checkBoxBan
            // 
            this._checkBoxBan.AutoSize = true;
            this._checkBoxBan.Location = new System.Drawing.Point(92, 95);
            this._checkBoxBan.Name = "_checkBoxBan";
            this._checkBoxBan.Size = new System.Drawing.Size(46, 19);
            this._checkBoxBan.TabIndex = 8;
            this._checkBoxBan.Text = "Ban";
            this._checkBoxBan.UseVisualStyleBackColor = true;
            // 
            // _buttonSave
            // 
            this._buttonSave.Location = new System.Drawing.Point(92, 180);
            this._buttonSave.Name = "_buttonSave";
            this._buttonSave.Size = new System.Drawing.Size(75, 23);
            this._buttonSave.TabIndex = 6;
            this._buttonSave.Text = "Save";
            this._buttonSave.UseVisualStyleBackColor = true;
            // 
            // _buttonPrevious
            // 
            this._buttonPrevious.Location = new System.Drawing.Point(134, 151);
            this._buttonPrevious.Name = "_buttonPrevious";
            this._buttonPrevious.Size = new System.Drawing.Size(75, 23);
            this._buttonPrevious.TabIndex = 5;
            this._buttonPrevious.Text = "Previous";
            this._buttonPrevious.UseVisualStyleBackColor = true;
            // 
            // _buttonAdd
            // 
            this._buttonAdd.Location = new System.Drawing.Point(53, 122);
            this._buttonAdd.Name = "_buttonAdd";
            this._buttonAdd.Size = new System.Drawing.Size(75, 23);
            this._buttonAdd.TabIndex = 2;
            this._buttonAdd.Text = "Add";
            this._buttonAdd.UseVisualStyleBackColor = true;
            // 
            // _buttonDelete
            // 
            this._buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._buttonDelete.Location = new System.Drawing.Point(134, 122);
            this._buttonDelete.Name = "_buttonDelete";
            this._buttonDelete.Size = new System.Drawing.Size(75, 23);
            this._buttonDelete.TabIndex = 3;
            this._buttonDelete.Text = "Delete";
            this._buttonDelete.UseVisualStyleBackColor = true;
            // 
            // _buttonNext
            // 
            this._buttonNext.Location = new System.Drawing.Point(53, 151);
            this._buttonNext.Name = "_buttonNext";
            this._buttonNext.Size = new System.Drawing.Size(75, 23);
            this._buttonNext.TabIndex = 4;
            this._buttonNext.Text = "Next";
            this._buttonNext.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this._textBoxUsername);
            this.Controls.Add(this._textBoxPassword);
            this.Controls.Add(this._dataGridViewUsers);
            this.Controls.Add(this.UserBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userModelBindingSource)).EndInit();
            this.UserBox.ResumeLayout(false);
            this.UserBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label Password;
        private Label Username;
        private TextBox _textBoxUsername;
        private TextBox _textBoxPassword;
        private GroupBox UserBox;
        private Button _buttonSave;
        private Button _buttonPrevious;
        private Button _buttonAdd;
        private Button _buttonDelete;
        private Button _buttonNext;
        private DataGridView _dataGridViewUsers;
        private BindingSource userModelBindingSource;
        private DataGridViewTextBoxColumn _columnId;
        private DataGridViewTextBoxColumn _columnUsername;
        private DataGridViewTextBoxColumn _columnPassword;
        private DataGridViewCheckBoxColumn _columnBan;
        private CheckBox _checkBoxBan;
        private Label Search;
        private TextBox _textBoxSearch;
        private DataGridViewTextBoxColumn OrderNumber;
    }
}