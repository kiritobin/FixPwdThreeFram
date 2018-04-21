using FixPwd.BLL;
using FixPwd.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FixPwd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        UserInfo user = new UserInfo();
        UserInfoBLL userBll = new UserInfoBLL();
        public bool Insert { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            user.userName = textBox1.Text.Trim();
            user.password = textBox2.Text.Trim();
            if (user.userName == "")
            {
                MessageBox.Show("请输入用户名!");
                return;
            }
            if (user.password == "")
            {
                MessageBox.Show("请输入密码!");
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("请输入修改密码!");
                return;
            }
            int count = userBll.Query(user);
            if (count > 0)
            {
                user.password = textBox3.Text.Trim();
                userBll.Fix(user);
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            user.userName = textBox5.Text.Trim();
            user.tel = textBox6.Text.Trim();
            if (user.userName=="")
            {
                MessageBox.Show("请输入用户名!");
            }
            if (user.tel=="")
            {
                MessageBox.Show("请输入手机号!");
            }
            if (userBll.ResetPwd(user))
            {
                MessageBox.Show("重置成功");
            }
            else
            {
                MessageBox.Show("用户名或手机号错误");
            }
        }
    }
}
