using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

//Variables and methods names need some cleanup.

namespace xdPatcher
{
    public partial class Form1 : Form
    {
        private Process xdeltaProcess = null;

        private List<string[]> filesToCopy = new List<string[]>();
        private List<string[]> filesToPatch = new List<string[]>();
        private List<string> filesToDelete = new List<string>(); //not used

        private string targetPath = null;
        private string oldPath = null;
        private string newPath = null;
        private string emptyFilePath = null;

        private string applyXdpPath = null;
        private string applyOrigPath = null;
        private string applyTargetPath = null;
        private List<string[]> origFilesToPatch = new List<string[]>();

        public Form1()
        {
            InitializeComponent();
        }

        public static string EscapeArguments(params string[] args)
        {
            StringBuilder arguments = new StringBuilder();
            Regex invalidChar = new Regex("[\x00\x0a\x0d]");//  these can not be escaped
            Regex needsQuotes = new Regex(@"\s|""");//          contains whitespace or two quote characters
            Regex escapeQuote = new Regex(@"(\\*)(""|$)");//    one or more '\' followed with a quote or end of string
            for (int carg = 0; args != null && carg < args.Length; carg++)
            {
                if (args[carg] == null) { throw new ArgumentNullException("args[" + carg + "]"); }
                if (invalidChar.IsMatch(args[carg])) { throw new ArgumentOutOfRangeException("args[" + carg + "]"); }
                if (args[carg] == String.Empty) { arguments.Append("\"\""); }
                else if (!needsQuotes.IsMatch(args[carg])) { arguments.Append(args[carg]); }
                else
                {
                    arguments.Append('"');
                    arguments.Append(escapeQuote.Replace(args[carg], m =>
                    m.Groups[1].Value + m.Groups[1].Value +
                    (m.Groups[2].Value == "\"" ? "\\\"" : "")
                    ));
                    arguments.Append('"');
                }
                if (carg + 1 < args.Length)
                    arguments.Append(' ');
            }
            return arguments.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btStop.Enabled = false;
            btApplyStop.Enabled = false;
            tabControl.SelectedIndex = 0;

            /*textBoxOldPath.Text = @"F:\steam-bup\BorderlandsPreSequel-v1.0.5";
            textBoxNewPath.Text = @"F:\steam-bup\BorderlandsPreSequel-v1.0.3";
            textBoxTargetPath.Text = @"K:\test";

            textBoxApplyPatch.Text = @"K:\test\BorderlandsPreSequel-v1.0.5.xdpatch";
            textBoxApplyOld.Text = @"F:\steam-bup\BorderlandsPreSequel-v1.0.5";
            textBoxApplyTarget.Text = @"K:\test";*/
        }

        private void Form1_BrowseButtonClicked(object sender, EventArgs e)
        {
            string path = null;
            FolderBrowserDialog folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;
                if (btBrowseOld == sender)
                {
                    textBoxOldPath.Text = path;
                }
                else if (btBrowseNew == sender)
                {
                    textBoxNewPath.Text = path;
                }
                else if (btBrowseTarget == sender)
                {
                    textBoxTargetPath.Text = path;
                }
                else if (btBrowseChoosePatch == sender)
                {
                    textBoxApplyPatch.Text = path;
                }
                else if (btBrowseOutdated == sender)
                {
                    textBoxApplyOld.Text = path;
                }
                else if (btBrowsePatchedTarget == sender)
                {
                    textBoxApplyTarget.Text = path;
                }
            }
        }

        private void xdelta3_DataReceived(object sender, DataReceivedEventArgs e)
        {
            string strMessage = e.Data;

            Invoke(new MethodInvoker(() =>
            {
                if (null != strMessage)
                {
                    strMessage = strMessage.Replace("\n", Environment.NewLine);
                    logTextBox.AppendText(strMessage + Environment.NewLine);
                }
            }));
        }

        private void xdelta3Apply_DataReceived(object sender, DataReceivedEventArgs e)
        {
            string strMessage = e.Data;

            Invoke(new MethodInvoker(() =>
            {
                if (null != strMessage)
                {
                    strMessage = strMessage.Replace("\n", Environment.NewLine);
                    logTextBox.AppendText(strMessage + Environment.NewLine);
                }
            }));
        }

        private void xdelta3_Exited(object sender, System.EventArgs e)
        {
            Invoke(new MethodInvoker(() =>
            {
                xdeltaProcess = null;
                patchNextFile();
            }));
        }

        private void xdelta3_ApplyExited(object sender, System.EventArgs e)
        {
            Invoke(new MethodInvoker(() =>
            {
                xdeltaProcess = null;
                applyPatchForNextFile();
            }));
        }

        private void runXdelta(string oldFile, string newFile, string targetDir)
        {

            logTextBox.AppendText("Now creating delta for: " + newFile.Replace(newPath, "") + Environment.NewLine);

            string deltaPath = targetDir + Path.DirectorySeparatorChar + Path.GetFileName(newFile) + ".delta";
            string oldP = oldFile;
            string newP = newFile;

            xdeltaProcess = new Process();
            xdeltaProcess.StartInfo.FileName = @"data\xdelta3.exe";
            xdeltaProcess.StartInfo.Arguments = EscapeArguments("-9", "-e", "-s", oldP, newP, deltaPath);
            xdeltaProcess.StartInfo.UseShellExecute = false;
            xdeltaProcess.StartInfo.RedirectStandardOutput = true;
            xdeltaProcess.StartInfo.RedirectStandardError = true;
            xdeltaProcess.StartInfo.CreateNoWindow = true;
            xdeltaProcess.StartInfo.WorkingDirectory = "data";

            xdeltaProcess.EnableRaisingEvents = true;
            xdeltaProcess.ErrorDataReceived += xdelta3_DataReceived;
            xdeltaProcess.OutputDataReceived += xdelta3_DataReceived;
            xdeltaProcess.Exited += xdelta3_Exited;

            if (xdeltaProcess.Start())
            {
                xdeltaProcess.BeginOutputReadLine();
                xdeltaProcess.BeginErrorReadLine();
            }
            else
            {
                logTextBox.AppendText("xdelta failed to start." + Environment.NewLine);
            }
        }
        
        private void runApplyXdelta(string oldFile, string deltaFile, string patchedTargetDir)
        {
            if (!Directory.Exists(patchedTargetDir))
            {
                Directory.CreateDirectory(patchedTargetDir);
            }
            string targetFile = patchedTargetDir + Path.DirectorySeparatorChar + Path.GetFileName(oldFile);
            logTextBox.AppendText("Now applying delta for: " + targetFile.Replace(applyTargetPath,"") + Environment.NewLine);

            xdeltaProcess = new Process();
            xdeltaProcess.StartInfo.FileName = @"data\xdelta3.exe";
            xdeltaProcess.StartInfo.Arguments = EscapeArguments("-d", "-s", oldFile, deltaFile, targetFile);
            xdeltaProcess.StartInfo.UseShellExecute = false;
            xdeltaProcess.StartInfo.RedirectStandardOutput = true;
            xdeltaProcess.StartInfo.RedirectStandardError = true;
            xdeltaProcess.StartInfo.CreateNoWindow = true;
            xdeltaProcess.StartInfo.WorkingDirectory = "data";

            xdeltaProcess.EnableRaisingEvents = true;
            xdeltaProcess.ErrorDataReceived += xdelta3Apply_DataReceived;
            xdeltaProcess.OutputDataReceived += xdelta3Apply_DataReceived;
            xdeltaProcess.Exited += xdelta3_ApplyExited;

            if (xdeltaProcess.Start())
            {
                xdeltaProcess.BeginOutputReadLine();
                xdeltaProcess.BeginErrorReadLine();
            }
            else
            {
                logTextBox.AppendText("xdelta failed to start." + Environment.NewLine);
            }
        }

        private void patchNextFile()
        {
            progressBar.Value++;

            if (filesToPatch.Count == 0)
            {
                filesToCopy.Clear();
                filesToPatch.Clear();
                filesToDelete.Clear();

                if (null != emptyFilePath)
                {
                    File.Delete(emptyFilePath);
                    emptyFilePath = null;
                }

                logTextBox.AppendText(Environment.NewLine + "Done." + Environment.NewLine);
                btCreatePatch.Enabled = true;
                btStop.Enabled = false;
                btApplyStop.Enabled = false;
                btApplyPatch.Enabled = true;
                progressBar.Value = progressBar.Maximum;
                return;
            }

            string[] array = filesToPatch.First();
            filesToPatch.RemoveAt(0);

            string dir = array[2];
            string where = targetPath + Path.DirectorySeparatorChar;

            if (dir.Length > 0)
            {
                where += dir;
                if (!System.IO.Directory.Exists(where))
                {
                    System.IO.Directory.CreateDirectory(where);
                }
            }

            runXdelta(array[0], array[1], where);
        }
        
        private void applyPatchForNextFile()
        {
            progressBar.Value++;

            if (origFilesToPatch.Count == 0)
            {
                origFilesToPatch.Clear();

                logTextBox.AppendText(Environment.NewLine + "Done." + Environment.NewLine);
                btCreatePatch.Enabled = true;
                btStop.Enabled = false;
                btApplyStop.Enabled = false;
                btApplyPatch.Enabled = true;
                progressBar.Value = progressBar.Maximum;
                return;
            }

            string[] array = origFilesToPatch.First();
            origFilesToPatch.RemoveAt(0);

            runApplyXdelta(array[0], array[1], array[2]);
        }

        private void applyPatch(string xdpPath, string origPath, string targetPath)
        {
            logTextBox.Clear();

            if (File.Exists(xdpPath + Path.DirectorySeparatorChar + "info.txt"))
            {
                string info = File.ReadAllText(xdpPath + Path.DirectorySeparatorChar + "info.txt");
                DialogResult r = MessageBox.Show(
                        info,
                        "Info about the patch",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information
                        );
                if (r == DialogResult.Cancel)
                {
                    btCreatePatch.Enabled = true;
                    btStop.Enabled = false;
                    btApplyStop.Enabled = false;
                    btApplyPatch.Enabled = true;
                    return;
                }
            }

            logTextBox.AppendText("Copying and patching..." + Environment.NewLine);

            int notFoundCount = 0;

            IEnumerable<string> patchDirEnum = Directory.EnumerateFiles(xdpPath, "*.delta", SearchOption.AllDirectories);
            foreach (string file in patchDirEnum)
            {
                string pathInOrigDir = file.Replace(xdpPath, origPath);
                pathInOrigDir = pathInOrigDir.Substring(0, pathInOrigDir.Length - 6);

                if (!File.Exists(pathInOrigDir))
                {
                    notFoundCount++;
                    logTextBox.AppendText("Error file not found: " + pathInOrigDir + Environment.NewLine);
                }
                else
                {
                    string parent = Path.GetDirectoryName(file);
                    string targetFile = targetPath + Path.DirectorySeparatorChar + parent.Replace(xdpPath, "");
                    string[] array = new string[3];
                    array[0] = pathInOrigDir;
                    array[1] = file;
                    array[2] = targetFile;
                    origFilesToPatch.Add(array);
                }
            }

            if (notFoundCount > 0)
            {
                DialogResult r = MessageBox.Show(
                    "Are you sure you've selected the proper original directory ? " + notFoundCount + " files were not found. Would you like to continue ?",
                    "Missing files",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                    );
                if (r == DialogResult.Cancel)
                    return;
            }

            progressBar.Maximum = 1 + origFilesToPatch.Count;
            applyPatchForNextFile();
        }

        private void Form1_ApplyPatchButtonClicked(object sender, EventArgs e)
        {
            if (xdeltaProcess != null)
            {
                logTextBox.AppendText("xdelta is already running." + Environment.NewLine);
                return;
            }

            applyXdpPath = textBoxApplyPatch.Text;
            applyOrigPath = textBoxApplyOld.Text;
            applyTargetPath = textBoxApplyTarget.Text;

            string patchName = Path.GetFileName(applyXdpPath).Replace(".xdpatch", "");
            applyTargetPath += Path.DirectorySeparatorChar + patchName;
            if (System.IO.Directory.Exists(applyTargetPath))
            {
                logTextBox.AppendText("target directory already exists: " + applyTargetPath + Environment.NewLine);
                return;
            }
            else
            {
                System.IO.Directory.CreateDirectory(applyTargetPath);
            }

            progressBar.Value = 0;

            if (applyXdpPath.Length == 0 || applyOrigPath.Length == 0 || applyTargetPath.Length == 0)
            {
                logTextBox.AppendText("Missing path." + Environment.NewLine);
                return;
            }

            btCreatePatch.Enabled = false;
            btStop.Enabled = false;
            btApplyStop.Enabled = true;
            btApplyPatch.Enabled = false;

            applyPatch(applyXdpPath, applyOrigPath, applyTargetPath);
        }

        private void createPatch(string oldPath, string newPath, string targetPath)
        {
            logTextBox.Clear();
            logTextBox.AppendText("Analyzing directories..." + Environment.NewLine);

            emptyFilePath = targetPath + Path.DirectorySeparatorChar + "empty";
            FileStream f = File.Create(emptyFilePath);
            f.Close();

            IEnumerable<string> newDirEnum = Directory.EnumerateFiles(newPath, "*", SearchOption.AllDirectories);
            foreach (string file in newDirEnum)
            {
                string pathInOldDir = file.Replace(newPath, oldPath);
                string fileDir = Path.GetDirectoryName(file);
                string relDirPath = fileDir.Replace(newPath, "");

                if (File.Exists(pathInOldDir))
                {
                    //file is present in both versions
                    string[] array = new string[3];
                    array[0] = pathInOldDir;
                    array[1] = file;
                    array[2] = relDirPath;
                    filesToPatch.Add(array);
                }
                else
                {
                    //file exists only in the new version
                    string[] array = new string[3];
                    array[0] = emptyFilePath;
                    array[1] = file;
                    array[2] = relDirPath;
                    filesToCopy.Add(array);
                    filesToPatch.Add(array); //files will be compared against an empty file.
                }
            }

            IEnumerable<string> oldDirEnum = Directory.EnumerateFiles(oldPath, "*", SearchOption.AllDirectories);
            foreach (string file in oldDirEnum)
            {
                string pathInNewDir = file.Replace(oldPath, newPath);

                if (!File.Exists(pathInNewDir))
                {
                    //file only exists in old dir
                    filesToDelete.Add(file);
                }
            }
            logTextBox.AppendText("Files present in both versions: " + filesToPatch.Count + Environment.NewLine);
            logTextBox.AppendText("Files present in new version only: " + filesToCopy.Count + Environment.NewLine);
            logTextBox.AppendText("Files present in old version only: " + filesToDelete.Count + Environment.NewLine);
            logTextBox.AppendText("Generating patch..." + Environment.NewLine);

            progressBar.Maximum = 1 + filesToPatch.Count;

            patchNextFile();
        }

        private void Form1_CreatePatchButtonClicked(object sender, EventArgs e)
        {
            if (xdeltaProcess != null)
            {
                logTextBox.AppendText("xdelta is already running." + Environment.NewLine);
                return;
            }

            oldPath = textBoxOldPath.Text;
            newPath = textBoxNewPath.Text;
            targetPath = textBoxTargetPath.Text;

            string patchName = Path.GetFileName(oldPath) + ".xdpatch";
            targetPath += Path.DirectorySeparatorChar + patchName;

            if (System.IO.Directory.Exists(targetPath))
            {
                logTextBox.AppendText("target directory already exists: " + targetPath + Environment.NewLine);
                return;
            }
            else
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            progressBar.Value = 0;

            if (oldPath.Length==0 || newPath.Length==0 || targetPath.Length==0)
            {
                logTextBox.AppendText("Missing path." + Environment.NewLine);
                return;
            }

            btCreatePatch.Enabled = false;
            btStop.Enabled = true;
            btApplyStop.Enabled = false;
            btApplyPatch.Enabled = false;
            createPatch(oldPath, newPath, targetPath);
            return;

        }
        
        private void btApplyStop_Click(object sender, EventArgs e)
        {
            if (xdeltaProcess != null)
            {
                origFilesToPatch.Clear();
            }
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            if (xdeltaProcess != null)
            {
                filesToPatch.Clear();
                filesToDelete.Clear();
                filesToCopy.Clear();
            }
        }

    }
}
