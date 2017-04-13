using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            test();
        }
        private  void test()
        {
            String[] users = System.IO.File.ReadAllLines("d:\\1.txt");
            foreach(string user in users)
            {
              
                    string py = getPy.ConvertE(user).ToLower();
                    string email = py + "@msunsoft.com";
                    string password = py + "321";
                    post(user, password, email);
                   System.Threading.Thread.Sleep(50);
               
            }
            MessageBox.Show("添加完成");

        }
        private  void post(string username,string password,string email)
        {
            HttpHelper http = new HttpHelper();
            
            var cookie = "hd_searchtime=1491534079; hd_sid=Eq9dpI; hd_auth=8c2dbH8nrn53RnsKJ2DRQ1%2F9p4G%2FDr7SpirZSSvB0b8EoSbkh9hbxLSpBIgghGaDXF8WpHkPXibSto2RmVx0; PHPSESSID=bd5h8ahie7kmct2kqcukbuklq4; hd_querystring=admin_user-add";
            string data = "id=&username=" + System.Web.HttpUtility.UrlEncode(username)
                + "&password="
                + password 
                +"&email="
               + email +"&groupid=2&submit=%E7%A1%AE%E5%AE%9A";
            HttpItem item = new HttpItem();
            item.URL = "http://10.68.4.69/index.php?admin_user-add";
            item.Method = "post";
            item.Postdata = data;
            item.Encoding = Encoding.GetEncoding("gb2312");
            item.Cookie = cookie;
            item.ContentType = "application/x-www-form-urlencoded";
            var html = http.GetHtml(item);
            System.Diagnostics.Trace.WriteLine(html);

            
        }
    }
}
