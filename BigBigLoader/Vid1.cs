using System;
using System.Windows.Forms;

namespace BigBigLoader
{
    public partial class Vid1 : Form
    {
        public Vid1()
        {
            InitializeComponent();
        }

        private void Play_Click(object sender, EventArgs e)
        {


            if (axVLCPlugin21.playlist.isPlaying == true)
            {
                axVLCPlugin21.playlist.stop();
                axVLCPlugin21.playlist.items.clear();
            }



            string ipaddress = textBox4.Text;
            string port = textBox9.Text;
            string url = textBox1.Text;
            string username = textBox2.Text;
            string password = textBox3.Text;


            string combinedurl = "rtsp://" + username + ":" + password + "@" + ipaddress + ":" + port + "/" + url;




            axVLCPlugin21.playlist.add(combinedurl, null, ":network-caching=" + textBox13.Text);
            axVLCPlugin21.playlist.next();
            axVLCPlugin21.playlist.play();
        }
    }
}
