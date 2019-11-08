using Ionic.Zip;
using Ionic.Zlib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        string txtFolder;
        string txtDestination;
        string savePath;
        string saveName;
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer each = new DispatcherTimer();
        ProcessStartInfo pStartInfo = new ProcessStartInfo();
        List<string> mylist = new List<string>();
        List<string> mylistfix = new List<string>();
        List<string> myfeat = new List<string>();
        List<string> myfeatfix = new List<string>();
        List<string> mybugs = new List<string>();
        List<string> mybugsfix = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            labelCompressionStatus.Text = "";
        }

        void timer_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = 5;
            labelCompressionStatus.Text = "Terminé";
            if (File.Exists(savePath + "\\" + saveName + "\\" + saveName + ".love"))
            {
                File.Delete(savePath + "\\" + saveName + "\\" + saveName + ".love");
            }
            if (File.Exists(savePath + "\\" + saveName + "\\love.exe"))
            {
                File.Delete(savePath + "\\" + saveName + "\\love.exe");
            }
            if (File.Exists(savePath + "\\" + saveName + "\\lovec.exe"))
            {
                File.Delete(savePath + "\\" + saveName + "\\lovec.exe");
            }
            timer.Tick -= timer_Tick;
            each.Tick -= each_Tick;
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName == "cmd" || p.ProcessName == "CMD")
                {
                    p.Kill();
                }
            }

            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Exportation terminée\n" +
                "Consulter le dossier de destination ?", "Succès", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(savePath);
            }
            else if (dialogResult == System.Windows.Forms.DialogResult.No)
            {
                //do something else
            }
        }

        void each_Tick(object sender, EventArgs e)
        {
            progressBar1.Maximum = 5;
            if (progressBar1.Value == 3)
            {
                progressBar1.Value = 3.5f;
            }
            else
            {
                progressBar1.Value++;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var zip = new ZipFile())
            {
                if (Directory.Exists(PathText.Text) && DestinationText.Text != "")
                {
                    if (!Directory.Exists(savePath + "\\" + saveName))
                    {
                        Directory.CreateDirectory(savePath + "\\" + saveName);
                    }
                    if (!File.Exists(savePath + "\\" + saveName + "\\love.dll"))
                    {
                        File.Copy("C:\\Program Files\\LOVE\\love.dll", savePath + "\\" + saveName + "\\love.dll");
                    }
                    if (!File.Exists(savePath + "\\" + saveName + "\\love.exe"))
                    {
                        File.Copy("C:\\Program Files\\LOVE\\love.exe", savePath + "\\" + saveName + "\\love.exe");
                    }
                    if (!File.Exists(savePath + "\\" + saveName + "\\lovec.exe"))
                    {
                        File.Copy("C:\\Program Files\\LOVE\\lovec.exe", savePath + "\\" + saveName + "\\lovec.exe");
                    }
                    if (!File.Exists(savePath + "\\" + saveName + "\\lua51.dll"))
                    {
                        File.Copy("C:\\Program Files\\LOVE\\lua51.dll", savePath + "\\" + saveName + "\\lua51.dll");
                    }
                    if (!File.Exists(savePath + "\\" + saveName + "\\mpg123.dll"))
                    {
                        File.Copy("C:\\Program Files\\LOVE\\mpg123.dll", savePath + "\\" + saveName + "\\mpg123.dll");
                    }
                    if (!File.Exists(savePath + "\\" + saveName + "\\msvcp120.dll"))
                    {
                        File.Copy("C:\\Program Files\\LOVE\\msvcp120.dll", savePath + "\\" + saveName + "\\msvcp120.dll");
                    }
                    if (!File.Exists(savePath + "\\" + saveName + "\\msvcr120.dll"))
                    {
                        File.Copy("C:\\Program Files\\LOVE\\msvcr120.dll", savePath + "\\" + saveName + "\\msvcr120.dll");
                    }
                    if (!File.Exists(savePath + "\\" + saveName + "\\OpenAL32.dll"))
                    {
                        File.Copy("C:\\Program Files\\LOVE\\OpenAL32.dll", savePath + "\\" + saveName + "\\OpenAL32.dll");
                    }
                    if (!File.Exists(savePath + "\\" + saveName + "\\SDL2.dll"))
                    {
                        File.Copy("C:\\Program Files\\LOVE\\SDL2.dll", savePath + "\\" + saveName + "\\SDL2.dll");
                    }
                    if (File.Exists(savePath + "\\" + saveName + "\\" + saveName + ".exe"))
                    {
                        File.Delete(savePath + "\\" + saveName + ".exe");
                    }
                    if (File.Exists(savePath + "\\" + saveName + "\\" + saveName + ".love"))
                    {
                        File.Delete(savePath + "\\" + saveName + ".love");
                    }
                    var readMeLines = new List<string>();
                    readMeLines.Add("Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " (Dernière build)");
                    readMeLines.Add("");
                    readMeLines.Add("Auteurs: \n" + autors.Text);
                    readMeLines.Add("");
                    readMeLines.Add("Description: \n" + description.Text);
                    readMeLines.Add("");
                    readMeLines.Add("Contrôles:");
                    foreach (string item in controls.Items)
                    {
                        readMeLines.Add("   - " + item);
                    }
                    readMeLines.Add("");
                    readMeLines.Add("Fonctionnalités:");
                    foreach (string item in features.Items)
                    {
                        readMeLines.Add("   - " + item);
                    }
                    readMeLines.Add("");
                    readMeLines.Add("Bugs connus:");
                    foreach (string item in bugs.Items)
                    {
                        readMeLines.Add("   - " + item);
                    }
                    if (File.Exists(savePath + "\\ReadMe.txt"))
                    {
                        File.Delete(savePath + "\\ReadMe.txt");
                    }
                    File.WriteAllLines(savePath + "\\ReadMe.txt", readMeLines);
                    
                    zip.SaveProgress += SaveProgress;
                    zip.CompressionLevel = CompressionLevel.Default;
                    zip.AddDirectory(PathText.Text); // (Chemin accès, Chemin dans l'archive)
                    string renamed = savePath + "\\" + saveName + "\\" + saveName + ".love";
                    zip.Save(renamed);
                    timer.Interval = TimeSpan.FromSeconds(5);
                    timer.Tick += timer_Tick;
                    timer.Start();

                    progressBar1.Value = 0;
                    each.Interval = TimeSpan.FromSeconds(1);
                    each.Tick += each_Tick;
                    each.Start();
                }
                else if (Directory.Exists(PathText.Text))
                {
                    System.Windows.MessageBox.Show("Dossier de réception non indiqué", "Erreur");
                }
                else 
                {
                    System.Windows.MessageBox.Show("Dossier à compresser introuvable", "Erreur");
                }
            }
        }

        public void SaveProgress(object sender, SaveProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Saving_Started)
            {
                //MessageBox.Show("Begin Saving: " + e.ArchiveName);
            }
            else if (e.EventType == ZipProgressEventType.Saving_BeforeWriteEntry)
            { 

            }
            else if (e.EventType == ZipProgressEventType.Saving_EntryBytesRead)
            {
                labelCompressionStatus.Text = "Compression en cours...";
                progressBar1.Value = (int)((e.BytesTransferred * 100) / e.TotalBytesToTransfer);
            }
            else if (e.EventType == ZipProgressEventType.Saving_Completed)
            {
                labelCompressionStatus.Text = "Compression Réussi. Création de l'éxécutable...";
                pStartInfo.FileName = "CMD";
                pStartInfo.Arguments = @"/K copy / b " + savePath + "\\" + saveName + "\\love.exe + " + savePath + "\\" + saveName + "\\" + saveName + ".love " + savePath + "\\" + saveName + "\\" + saveName + ".exe";
                pStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(pStartInfo);
            }
        }

        private void FOlderSelect_Click(object sender, RoutedEventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            //fbd.Description = "Selectionnez le dossier contenant le projet LOVE";
            if (PathText.Text == "")
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    txtFolder = fbd.SelectedPath;
                    if (File.Exists(fbd.SelectedPath + "\\ReadMe.txt"))
                    {
                        bool autor = false;
                        bool desc = false;
                        bool control = false;
                        bool feat = false;
                        bool bug = false;

                        string autorsStr = "";
                        string descStr = "";

                        foreach (string line in File.ReadAllLines(fbd.SelectedPath + "\\ReadMe.txt"))
                        {
                            if (line.Contains("Auteurs:"))
                            {
                                autor = true;
                            }
                            if (line.Contains("Description:"))
                            {
                                desc = true;
                            }
                            if (line.Contains("Contrôles:"))
                            {
                                control = true;
                            }
                            if (line.Contains("Fonctionnalités:"))
                            {
                                feat = true;
                            }
                            if (line.Contains("Bugs connus:"))
                            {
                                bug = true;
                            }

                            //Get authors
                            if (autor && !desc && !line.Contains("Auteurs:") && line != "")
                            {
                                if (autorsStr == "")
                                {
                                    autorsStr += line;
                                }
                                else
                                {
                                    autorsStr += "\n";
                                    autorsStr += line;
                                }
                            }
                            autors.Text = autorsStr;

                            //Get desc
                            if (desc && !control && !line.Contains("Description:") && line != "")
                            {
                                if (descStr == "")
                                {
                                    descStr += line;
                                }
                                else
                                {
                                    descStr += "\n";
                                    descStr += line;
                                }
                            }
                            description.Text = descStr;

                            //Get controls
                            if (control && !feat && !line.Contains("Contrôles:") && line != "")
                            {
                                mylist.Add(line);
                            }
                            controls.ItemsSource = null;
                            controls.ItemsSource = mylist;

                            //Get features
                            if (feat && !bug && !line.Contains("Fonctionnalités:") && line != "")
                            {
                                myfeat.Add(line);
                            }
                            features.ItemsSource = null;
                            features.ItemsSource = myfeat;

                            //Get bugs
                            if (bug && !line.Contains("Bugs connus:") && line != "")
                            {
                                mybugs.Add(line);
                            }
                            bugs.ItemsSource = null;
                            bugs.ItemsSource = mybugs;
                        }
                        string str = "";
                        foreach (string item in mylist)
                        {
                            if (item.Contains("- "))
                            {
                                if (str != "")
                                {
                                    mylistfix.Add(str);
                                    str = "";
                                }
                                str = item;
                                str = str.Remove(0, 5);
                            }
                            else
                            {
                                str += "\n" + item;
                            }
                        }
                        if (mylist.Count != 0)
                        {
                            mylistfix.Add(str);
                            mylist = mylistfix;
                            controls.ItemsSource = null;
                            controls.ItemsSource = mylistfix;
                        }

                        str = "";
                        foreach (string item in myfeat)
                        {
                            if (item.Contains("- "))
                            {
                                if (str != "")
                                {
                                    myfeatfix.Add(str);
                                    str = "";
                                }
                                str = item;
                                str = str.Remove(0, 5);
                            }
                            else
                            {
                                str += "\n" + item;
                            }
                        }
                        if (myfeat.Count != 0)
                        {
                            myfeatfix.Add(str);
                            myfeat = myfeatfix;
                            features.ItemsSource = null;
                            features.ItemsSource = myfeatfix;
                        }

                        str = "";
                        foreach (string item in mybugs)
                        {
                            if (item.Contains("- "))
                            {
                                if (str != "")
                                {
                                    mybugsfix.Add(str);
                                    str = "";
                                }
                                str = item;
                                str = str.Remove(0, 5);
                            }
                            else
                            {
                                str += "\n" + item;
                            }
                        }
                        if (mybugs.Count != 0)
                        {
                            mybugsfix.Add(str);
                            mybugs = mybugsfix;
                            bugs.ItemsSource = null;
                            bugs.ItemsSource = mybugsfix;
                        }
                    }
                }
                else
                {
                    fbd.SelectedPath = txtFolder;
                }

                PathText.Text = txtFolder;
            }
            else
            {
                System.Windows.MessageBox.Show("Vous avez déjà ouvert un document", "Erreur");
            }
        }

        private void DestinationButton_Click(object sender, RoutedEventArgs e)
        {
            using (var ofd = new SaveFileDialog())
            {
                ofd.Filter = "Fichier executable|*.exe";
                ofd.ValidateNames = true;

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtDestination = ofd.FileName;
                }
                else
                {
                    ofd.FileName = txtDestination;
                }

                DestinationText.Text = txtDestination;

                var file = new FileInfo(ofd.FileName);
                savePath = file.DirectoryName;
                saveName = file.Name;
                saveName = saveName.Remove(saveName.Length - 4);
            }
        }

        

        private void btnAddToList_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Window1 cWin = new Window1();
            cWin.Owner = this;
            cWin.Show();
        }

        public void AddSelected(string touch, string func)
        {
            mylist.Add(touch + ": " + func);
            controls.ItemsSource = null;
            controls.ItemsSource = mylist;
        }

        public void AddSelectedFeat(string func)
        {
            myfeat.Add(func);
            features.ItemsSource = null;
            features.ItemsSource = myfeat;
        }

        public void AddSelectedBug(string bug)
        {
            mybugs.Add(bug);
            bugs.ItemsSource = null;
            bugs.ItemsSource = mybugs;
        }

        private void BtnDelToList_Click(object sender, RoutedEventArgs e)
        {
            if (controls.SelectedItem != null)
            {
                for (int i = 0; i < controls.Items.Count; i++)
                {
                    if (mylist[i] == (string)controls.SelectedValue)
                    {
                        mylist.RemoveAt(i);
                    }
                }

                controls.ItemsSource = null;
                controls.ItemsSource = mylist;
            }
        }

        private void BtnAddToFeat_Click(object sender, RoutedEventArgs e)
        {
            Window2 fWin = new Window2();
            fWin.Owner = this;
            fWin.Show();
        }

        private void BtnDelToFeat_Click(object sender, RoutedEventArgs e)
        {
            if (features.SelectedItem != null)
            {
                for (int i = 0; i < features.Items.Count; i++)
                {
                    if (myfeat[i] == (string)features.SelectedValue)
                    {
                        myfeat.RemoveAt(i);
                    }
                }

                features.ItemsSource = null;
                features.ItemsSource = myfeat;
            }
        }

        private void BtnAddToBugs_Click(object sender, RoutedEventArgs e)
        {
            Window3 bWin = new Window3();
            bWin.Owner = this;
            bWin.Show();
        }

        private void BtnDelToBugs_Click(object sender, RoutedEventArgs e)
        {
            if (bugs.SelectedItem != null)
            {
                for (int i = 0; i < bugs.Items.Count; i++)
                {
                    if (mybugs[i] == (string)bugs.SelectedValue)
                    {
                        mybugs.RemoveAt(i);
                    }
                }

                bugs.ItemsSource = null;
                bugs.ItemsSource = mybugs;
            }
        }
    }
}
