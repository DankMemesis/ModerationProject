using Microsoft.VisualBasic.ApplicationServices;
using ModeratingProject.Models;
using ModeratingProject.Repository;
using ModeratingProject.Repository.Interfaces;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace ModeratingProject
{
    public partial class MainForm : Form
    {
        private BindingSource _bsUsers;
        private BindingSource _bsCurrentUser;
        private IUserRepository _userrepo;

        public MainForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            Text = "SQL";

            SetBindings();

            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //тестовый репозиторий
            _userrepo = new MySqlRepository();

            //Загрузка данных
            LoadData(_textBoxSearch);

            //кнопки
            _buttonAdd.Click += ButtonAdd_Click;
            //_buttonSearch.Click += ButtonSearch_Click;
            _buttonDelete.Click += ButtonDelete_Click;
            _buttonSave.Click += ButtonSave_Click;
            _buttonNext.Click += ButtonNext_Click;
            _buttonPrevious.Click += ButtonPrevious_Click;
            //клик по строке в DGV
            _dataGridViewUsers.MouseClick += (s, a) => SetCurrentUser();
            //_checkBoxBan.Checked += CheckBoxBan_Checked;
        }

        private void SetBindings()
        {
            _bsUsers = new BindingSource();
            _bsUsers.DataSource = typeof(List<UserModel>);
            //привязки для DGV
            _dataGridViewUsers.AutoGenerateColumns = false;
            _dataGridViewUsers.DataSource = _bsUsers;
            //привязки у столбцов
            _columnId.DataPropertyName = nameof(UserModel.Id);
            _columnUsername.DataPropertyName = nameof(UserModel.Username);
            _columnPassword.DataPropertyName = nameof(UserModel.Password);
            _columnBan.DataPropertyName = nameof(UserModel.Ban);

            //текстбоксы
            _bsCurrentUser = new BindingSource();
            _bsCurrentUser.DataSource = new List<UserModel> { new UserModel(0) };
            _textBoxUsername.DataBindings.Add("Text", _bsCurrentUser, nameof(UserModel.Username));
            _textBoxPassword.DataBindings.Add("Text", _bsCurrentUser, nameof(UserModel.Password));
            _checkBoxBan.DataBindings.Add("Checked", _bsCurrentUser, nameof(UserModel.Ban));
            //_textBoxSearch.DataBindings.Add("Text", _bsCurrentUser, nameof(UserModel.UsernameSearch));
        }

        private async void LoadData(TextBox _textBoxSearch)
        {
            //получаем
            var result = await _userrepo.GetUsers(_textBoxSearch);
            if (result)
            {
                //извлекаем
                List<UserModel> users = result.Value;
                //пронумеровываем
                int i = 1;
                users.ForEach(e => e.OrderNumber = i++);
                //отображаем
                _bsUsers.DataSource = users;
                _bsUsers.MoveFirst();
                SetCurrentUser();
            }
            else
            {
                MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            //курсор на последнего
            _bsUsers.MoveLast();
            //след.порядковый номер
            int number = ((UserModel)_bsUsers.Current).OrderNumber + 1;
            //добавляем нового
            _bsUsers.Add(new UserModel(0) { OrderNumber = number });
            //выделяем его
            _bsUsers.MoveNext();
            SetCurrentUser();
            //выделяем имя для редактирования
            Username.Focus();
        }

        private async void ButtonSave_Click(object sender, EventArgs e)
        {
            SwitchOnWaiting();

            var current = (UserModel)_bsCurrentUser.Current;
            Result<int> result;

            try
            {
                if (current.Id == 0)
                {
                    //добавляем нового сотрудника
                    result = await _userrepo.AddUser(current);
                }
                else
                {
                    //иначе обновляем существующего сотрудника
                    result = await _userrepo.UpdateUser(current);
                }

                if (result)
                {
                    //перечитываем данные
                    LoadData(_textBoxSearch);
                }
            }
            finally
            {
                SwitchOffWaiting();
            }

            if (!result)
            {
                MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ButtonDelete_Click(object sender, EventArgs e)
        {
            SwitchOnWaiting();

            //получаем текущего
            var user = (UserModel)_bsUsers.Current;
            Result<int> result;
            try
            {
                //удаляем из БД
                result = await _userrepo.RemoveUser(user.Id);
                if (result)
                {
                    //удаляем из отображения
                    _bsUsers.Remove(user);
                    _bsUsers.MoveFirst();
                    SetCurrentUser();
                }
            }
            finally
            {
                SwitchOffWaiting();
            }

            if (!result)
            {
                MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            _bsUsers.MovePrevious();
            SetCurrentUser();
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            _bsUsers.MoveNext();
            SetCurrentUser();
        }
        private void SetCurrentUser()
        {
            if (_bsUsers.Count > 0)
            {
                _bsCurrentUser.List[0] = UserModel.GetClone((UserModel)_bsUsers.Current);

            }
            else
            {
                _bsCurrentUser.List[0] = new UserModel(0);
            }

            _bsCurrentUser.ResetItem(0);
        }
        private void SwitchOnWaiting()
        {
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.Enabled = false;
            }
            _dataGridViewUsers.Enabled = false;
            Cursor = Cursors.WaitCursor;
        }
        private void SwitchOffWaiting()
        {
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.Enabled = true;
            }
            _dataGridViewUsers.Enabled = true;
            Cursor = Cursors.Default;
        }

        private async void ButtonSearch_Click(object sender, EventArgs e)
        {
            /*string searchValue = _textBoxSearch.Text;
            _dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                bool valueResult = false;
                foreach (DataGridViewRow row in _dataGridViewUsers.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (row.Cells[i].Value != null && row.Cells[i].Value.ToString().Equals(searchValue))
                        {
                            int rowIndex = row.Index;
                            _dataGridViewUsers.Rows[rowIndex].Selected = true;

                            //_dataGridViewUsers.Rows[].Selected = false;
                            valueResult = true;
                            break;
                        }
                    }

                }
                if (!valueResult)
                {
                    MessageBox.Show("Unable to find " + _textBoxSearch.Text, "Not Found");
                    return;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }*/
           /* SwitchOnWaiting();

            var current = (UserModel)_bsCurrentUser.Current;
            

            
            var result = await _userrepo.SearchUser(current);
            if (result)
            {
                //извлекаем
                List<UserModel> users = result.Value;
                //пронумеровываем
                int i = 1;
                users.ForEach(e => e.OrderNumber = i++);
                //отображаем
                _bsUsers.DataSource = users;
                _bsUsers.MoveFirst();
                SetCurrentUser();
            }
            else
            {
                MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           */

        }

        private void _textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(_textBoxSearch);
           //(_dataGridViewUsers.DataSource as DataTable).DefaultView.RowFilter = $"username like '%{_textBoxSearch.Text}%'";
        }
    }
}