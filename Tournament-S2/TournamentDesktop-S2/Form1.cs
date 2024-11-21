using BLL.Enum;
using BLL.Interfaces;
using BLL.Models;
using BLL.UserBLL;
using BLL.Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TournamentDesktop_S2
{
    public partial class Form1 : Form
    {
        private readonly UserLogicLayer userLogicLayer = Program.GetService<UserLogicLayer>();

        public Form1()
        {
            InitializeComponent();
        }

        private void logIn_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(usernameLogIn_tb.Text) || string.IsNullOrEmpty(passwordLogIn_tb.Text))
            {
                MessageBox.Show("Fill all the fields!", "Please !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var userByUsername = userLogicLayer.GetUserByUsername(new Users(usernameLogIn_tb.Text));

                var getUser = new Users(usernameLogIn_tb.Text, PasswordHash.HashPassword(passwordLogIn_tb.Text, userByUsername.Salt), userByUsername.Salt);

                var user = userLogicLayer.GetUser(getUser);
                 

                if (user == null)
                {
                    MessageBox.Show("Set the correct credentials!", "Please !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (user.Role == Role.ADMIN)
                    {
                        this.Hide();
                        StoreUserInfo(user);
                        Admin admin = new Admin();
                        admin.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("You do not have permison to use the app!", "Thank you!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public void StoreUserInfo(Users user)
        {
            UtilityClass.UserName = user.Username;
            UtilityClass.UserId = Convert.ToString(user.Id);
            UtilityClass.Role = user.Role.ToString();
        }
    }
}