using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace snapper
{
    public partial class Form1 : Form 
    {

        #region Fields
        private bool firsttime = true;         //First time running?
        private bool firstclick = true;        //Have we completed our first session?
        private bool stop = true;             //Should we be taking images right now?
        private bool showNotifications = true; //Does the user want notification balloons?

        private string directory = @"C:\";     //Directory where snaps are stored.
        private int interval;                  //How many MS until taking a snapshot?
        private int imgs;                      //How many images have we taken?
        private Timer time = new Timer();      //The timer that stores how much longer until the next snapshot
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        //Initialization
        private void Form1_Load(object sender, EventArgs e)
        {
            bool retry = true;
            while (retry)
            {
                retry = false;
                //make new options.xml if none found
                if (!File.Exists("options.xml"))
                    using (System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(@"snapper.Resources.options.xml"))
                    {
                        using (System.IO.FileStream fileStream = new System.IO.FileStream(System.IO.Path.Combine(".", "options.xml"), System.IO.FileMode.Create))
                        {
                            for (int i = 0; i < stream.Length; i++)
                            {
                                fileStream.WriteByte((byte)stream.ReadByte());
                            }
                            fileStream.Close();
                        }
                    }
                try
                {
                    //Load options.xml
                    XmlDocument optionsfile = new XmlDocument();
                    optionsfile.LoadXml(File.OpenText("options.xml").ReadToEnd());

                    //Replace interval with one found in options
                    XmlNodeList options = optionsfile.SelectNodes("/options/time");
                    hrsbox.Value = Decimal.Parse(options[0]["hours"].InnerText);
                    minbox.Value = Decimal.Parse(options[0]["minutes"].InnerText);
                    secbox.Value = Decimal.Parse(options[0]["seconds"].InnerText);

                    //Replace directory with one found in options
                    XmlNode directoryxml = optionsfile.SelectSingleNode("/options/directory");
                    dir_text.Text = directoryxml.InnerText;
                    directory = directoryxml.InnerText;

                    //Retrieve notification preference.
                    XmlNode notificationxml = optionsfile.SelectSingleNode("/options/notifications");
                    showNotifications = Convert.ToBoolean(notificationxml.InnerText);
                    showNotifBox.Checked = showNotifications;

                    //First time running?
                    XmlNode firsttimexml = optionsfile.SelectSingleNode("/options/firsttime");
                    firsttime = Convert.ToBoolean(firsttimexml.InnerText);
                    firstclick = Convert.ToBoolean(firsttimexml.InnerText);

                    //If so, show welcoming balloon.
                    notif_icon.BalloonTipTitle = "Click to Minimize";
                    notif_icon.BalloonTipText = "After changing the settings, you can click here or click the red [X] to minimize Snapper down here. Or, just click Start.";
                    if (firsttime)
                        notif_icon.ShowBalloonTip(2000);
                }
                catch (Exception ex) //I don't think I need to catch for anything other than System.Xml.XmlException, but this is just in case.
                {
                    //Let the user know about the exception
                    string message = null;
                    if (ex is System.Xml.XmlException)
                        message += "Snapper encountered a problem trying to load your XML file.";
                    else
                        message += "Snapper encountered a really weird exception of type " + ex.GetType() + " while it was parsing your options file. You should bring this to the Github issues page.";
                    message += "\r\n\r\nWe're sorry for the inconvenience. We'll make you a brand new options file so you can get back to work.";
                   
                    MessageBox.Show(message, "Snapper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    try
                    {
                        File.Delete("options.xml"); //Delete bunk Options.xml
                    }
                    catch (System.IO.IOException)
                    {
                        //Quit if file is write-protected.
                        MessageBox.Show("Snapper was unable to delete options.xml. Make sure you have access to the folder you have Snapper saved to, and that no other programs are using the options.xml file. Please delete this file yourself (It should be right next to Snapper.exe). If this happens again, try running Snapper as an administrator.\r\n\r\nSnapper will now shut down.", "Snapper", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Environment.Exit(5);
                    }
                    retry = true; //Try again (This will make a new options file)
                }
            }

            //Set the enabledness of the toolstrip items.
            stopSnappingMenuItem.Enabled = false;
            startSnappingNowToolStripMenuItem.Enabled = true;
            pauseSnappingTemporarilyToolStripMenuItem.Enabled = false;
        } 

        //Minimizing
        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; //Prevent quitting

            notif_icon.BalloonTipTitle = "Snapper's down here!";
            notif_icon.BalloonTipText = "Right click this icon for a nifty menu, or just click it to show the options again.";

            this.Hide(); //Minimize

            //Show balloon on first time.
            if (firsttime == true)
            {
                notif_icon.ShowBalloonTip(1000);
                firsttime = false;
            }
        }

        //Choose folder via dialogue box
        private void directoryButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog newDir = new FolderBrowserDialog();
            newDir.Description = "Select the folder you would like Snapper to save your screenshots to.";
            newDir.ShowDialog();
            directory = newDir.SelectedPath;
            dir_text.Text = directory;
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            //Read options.xml to be written to
            FileStream optionsstream = new FileStream("options.xml", FileMode.Open);
            StreamReader optionsdoc = new StreamReader(optionsstream, System.Text.Encoding.UTF8);
            XmlDocument optionsfile = new XmlDocument();
            optionsfile.LoadXml(optionsdoc.ReadToEnd());
            
            //Write interval to XML
            XmlNodeList options = optionsfile.SelectNodes("/options/time");
            options[0]["hours"].InnerText = hrsbox.Value.ToString();
            options[0]["minutes"].InnerText = minbox.Value.ToString();
            options[0]["seconds"].InnerText = secbox.Value.ToString();

            //Write directory to XML
            XmlNode directoryxml = optionsfile.SelectSingleNode("/options/directory");
            directoryxml.InnerText = directory;

            //Write notification preference to XML
            XmlNode notificationxml = optionsfile.SelectSingleNode("/options/notifications");
            notificationxml.InnerText = showNotifications.ToString();

            //Set first time status.
            XmlNode firsttimexml = optionsfile.SelectSingleNode("/options/firsttime");
            firsttimexml.InnerText = "false"; //It's obviously false. The program is running.

            //Overwrite and then close the file.
            optionsstream.SetLength(0);
            optionsfile.Save(optionsstream);
            optionsstream.Close();
        }

        //Before the first ever snap, display informative bubble.
        private void start_notify(object sender, EventArgs e)
        {
            if (firstclick)
            {
                notif_icon.ShowBalloonTip(500, "Before you start!", "Snapper will take a \"Preliminary Screenshot\" 3 seconds after the program starts. Make sure that you're all set before you click!", ToolTipIcon.Error);
                firstclick = false;
            }
        }

        //LETS GET THIS PARTY STARTED
        private void startbtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(directory))
            {
                if (stop)//Don't continue unless we're not taking screenshots.
                {
                    interval = (int)((hrsbox.Value * 3600000) + (minbox.Value * 60000) + (secbox.Value * 1000)); //Calculate interval

                    if (interval != 0)
                    {
                        this.Hide(); //Minimize because oops screenshot

                        //Enable the "Stop snapping" item and disable the "Start snapping" item.
                        stopSnappingMenuItem.Enabled = true;
                        pauseSnappingTemporarilyToolStripMenuItem.Enabled = true;
                        startSnappingNowToolStripMenuItem.Enabled = false;

                        imgs = 1; //Set image number one to... image number 1
                        stop = false; //We're taking photos now
                        //Preliminary screenshot
                        notif_icon.ShowBalloonTip(0, "Snapper is starting!", "Snapper will take its first screenshot in 3 seconds...", ToolTipIcon.Info);
                        System.Threading.Thread.Sleep(3000);
                        cap();

                        //Set the timer
                        time.Interval = interval;
                        time.Tick += new EventHandler(cap);
                        time.Start();
                    }
                    else
                    {
                        MessageBox.Show("Snapper can't take screenshots with a 0 second interval! Please type in a larger number.", "Snapper", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else //Saving folder can't be found.
                MessageBox.Show("Snapper couldn't find that folder. Double check to make sure it exists, and try again.", "Snapper", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Code for taking a screenshot
        private void cap()
        {
            //This is a really gross way to stop the timer but it works 9 times out of ten.
            if (stop)
            {
                time.Stop();
            }
            else
            {
                //MessageBox.Show(Path.Combine(directory, "\\snapper_" + imgs + ".png")); //Uncomment for debug
                
                // http://stackoverflow.com/questions/5049122/capture-the-screen-shot-using-net
                
                //New bitmap with height/width of screen
                Bitmap bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                                     Screen.PrimaryScreen.Bounds.Height);
                Graphics g = Graphics.FromImage(bmpScreenCapture); //New drawing surface
                //Copy pixel data from screen to bitmap
                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                 Screen.PrimaryScreen.Bounds.Y,
                                 0, 0,
                                 bmpScreenCapture.Size,
                                 CopyPixelOperation.SourceCopy);

                //Save image to specified directory
                bmpScreenCapture.Save(
                    Path.Combine(directory, "snapper_" + imgs + ".png"));
                
                //Display notification if specified.
                if (showNotifications)
                {
                    notif_icon.BalloonTipTitle = "Captured!";
                    notif_icon.BalloonTipText = "Snapper has captured image #" + imgs + ".";
                    notif_icon.ShowBalloonTip(0);
                }

                imgs++; //Increment images saved by one.
            }
        }
        //Overload for cap that takes arguments -- For compatibility
        private void cap(object sender, EventArgs e) { cap(); }

        //Stop Snapping menu item behavior
        private void stopSnappingMenuItem_Click(object sender, EventArgs e)
        {
            stop = true;
            stopSnappingMenuItem.Enabled = false;
            startSnappingNowToolStripMenuItem.Enabled = true;
            pauseSnappingTemporarilyToolStripMenuItem.Enabled = false;
            pauseSnappingTemporarilyToolStripMenuItem.Checked = false;
        }

        //Pause Snapping Temporarily menu item behavior
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

        //Change whether notifications should show
        private void showNotifBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showNotifBox.CheckState == CheckState.Checked)
                showNotifications = true;
            else
                showNotifications = false;
        }

        //Show or hide window on notification icon click
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

        //Show notification icon menu
        private void showOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        //Change internal directory when directory box text changes
        private void dir_textChange(object sender, EventArgs e) {
            directory = dir_text.Text;
        }

        //Exit
        private void quitbtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        
        //Help button messages
        private void timeout_help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the amount of time Snapper will wait inbetween each snapshot.\r\n\r\nSnapper will try it's best, but limitations in the .NET framework mean that your image might not be taken at _exactly_ the time entered in these boxes. However, it will probably be close enough that it shouldn't matter.");
        }

        private void save_help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is where Snapper will save each snapshot.\r\n\r\nNote that you should have write-permission to this directory, otherwise you will have to run Snapper as an administrator.\r\n\r\nSnapper will overwrite any existing images in this directory. Keep this in mind.");
        }

        private void notifications_help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("On particularly short intervals, the notification balloon that lets a user know how many images have been taken can get in the way of snapshots. They can also be distracting to some people. This box disables those notifications so you can do your thing clutter-free.");
        }
    }
}
