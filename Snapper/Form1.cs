using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace snapper
{
    public partial class Form1 : Form
    {
        private bool firsttime = true;
        private bool firstclick = true;
        private string directory = @"C:\";
        private int interval;
        private int imgs;
        private bool stop = false;
        private Timer time = new Timer();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XmlDocument optionsfile = new XmlDocument();
            optionsfile.LoadXml(File.OpenText("options.xml").ReadToEnd());
            XmlNodeList options = optionsfile.SelectNodes("/options/time");

            hrsbox.Value = Decimal.Parse(options[0]["hours"].InnerText);
            minbox.Value = Decimal.Parse(options[0]["minutes"].InnerText);
            secbox.Value = Decimal.Parse(options[0]["seconds"].InnerText);

            XmlNode directoryxml = optionsfile.SelectSingleNode("/options/directory");
            dir_text.Text = directoryxml.InnerText;
            directory = directoryxml.InnerText;

            notif_icon.BalloonTipTitle = "Click to Minimize";
            notif_icon.BalloonTipText = "After changing the settings, you can click here or click the red [X] to minimize Snapper down here. Or, just click Start.";
            notif_icon.ShowBalloonTip(2000);
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            notif_icon.BalloonTipTitle = "Snapper's down here!";
            notif_icon.BalloonTipText = "Right click this icon for a nifty menu, or just click it to show the options again.";

            this.Hide();

            if (firsttime == true)
            {
                notif_icon.ShowBalloonTip(1000);
                firsttime = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog newDir = new FolderBrowserDialog();
            newDir.Description = "Select the folder you would like Snapper to save your screenshots to.";
            newDir.ShowDialog();
            directory = newDir.SelectedPath;
            dir_text.Text = directory;
        }

        private void timeout_help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the amount of time Snapper will wait inbetween each snapshot.\r\n\r\nSnapper will try it's best, but limitations in the .NET framework mean that your image might not be taken at _exactly_ the time entered in these boxes. However, it will probably be close enough that it shouldn't matter.");
        }

        private void save_help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is where Snapper will save each snapshot.\r\n\r\nNote that you should have write-permission to this directory, otherwise you will have to run Snapper as an administrator.");
        }

        private void quitbtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void showOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void notif_icon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.Visible)
                {
                    this.Hide();
                }
                else
                {
                    this.Show();
                }
            }
        }

        private void button2_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FileStream optionsstream = new FileStream("options.xml", FileMode.Open);
                StreamReader optionsdoc = new StreamReader(optionsstream, System.Text.Encoding.UTF8);
                XmlDocument optionsfile = new XmlDocument();
                optionsfile.LoadXml(optionsdoc.ReadToEnd());
                XmlNodeList options = optionsfile.SelectNodes("/options/time");

                options[0]["hours"].InnerText = hrsbox.Value.ToString();
                options[0]["minutes"].InnerText = minbox.Value.ToString();
                options[0]["seconds"].InnerText = secbox.Value.ToString();

                XmlNode directoryxml = optionsfile.SelectSingleNode("/options/directory");
                directoryxml.InnerText = directory;
                optionsstream.SetLength(0);
                optionsfile.Save(optionsstream);
                optionsstream.Close();
            }
            else if(e.Button == MouseButtons.Right)
            {
                MessageBox.Show("This will save the options you have set to the XML file in the Snapper directory, which will then be loaded each time you start Snapper.");
            }
        }

        private void start_notify(object sender, EventArgs e)
        {
            if (firstclick)
            {
                notif_icon.ShowBalloonTip(500, "Before you start!", "Snapper will take a \"Preliminary Screenshot\" 3 seconds after the program starts. Make sure that you're all set before you click!", ToolTipIcon.Error);
                firstclick = false;
            }
        }

        private void startbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (stop)
            {
                imgs = 1;
                stop = false;
                interval = (int)((hrsbox.Value * 3600000) + (minbox.Value * 60000) + (secbox.Value * 1000));
                notif_icon.ShowBalloonTip(0, "Snapper is starting!", "Snapper will take its first screenshot in 3 seconds...", ToolTipIcon.Info);
                System.Threading.Thread.Sleep(3000);
                cap();
                time.Interval = interval;
                time.Tick += new EventHandler(cap);
                time.Start();
            }
        }

        private void cap()
        {
            if (stop)
            {
                time.Stop();
            }
            else
            {
                // http://stackoverflow.com/questions/5049122/capture-the-screen-shot-using-net
                Bitmap bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                                     Screen.PrimaryScreen.Bounds.Height);
                Graphics g = Graphics.FromImage(bmpScreenCapture);
                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                 Screen.PrimaryScreen.Bounds.Y,
                                 0, 0,
                                 bmpScreenCapture.Size,
                                 CopyPixelOperation.SourceCopy);

                bmpScreenCapture.Save(directory + "\\snapper_" + imgs + ".png");
                notif_icon.BalloonTipTitle = "Captured!";
                notif_icon.BalloonTipText = "Snapper has captured image #" + imgs + ".";
                notif_icon.ShowBalloonTip(0);
                imgs++;
            }
        }
        private void cap(object sender, EventArgs e) { cap(); }

        private void stopSnappingMenuItem1_Click(object sender, EventArgs e)
        {
            stop = true;
            pauseSnappingTemporarilyToolStripMenuItem.Checked = false;
        }

        private void pauseSnappingTemporarilyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!stop)
            {
                if (pauseSnappingTemporarilyToolStripMenuItem.Checked)
                {
                    time.Enabled = true;
                    pauseSnappingTemporarilyToolStripMenuItem.Checked = false;
                }
                else
                {
                    time.Enabled = false;
                    pauseSnappingTemporarilyToolStripMenuItem.Checked = true;
                }
            }
        }
    }
}
