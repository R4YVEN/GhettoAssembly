using FastColoredTextBoxNS;
using GhettoASM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GhettoASM_IDE
{
    public partial class Main : Form
    {
        static Main main;
        bool currentlyExecuting = false;
        bool stopExecuting = false;

        public Main()
        {
            InitializeComponent();
            main = this;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ramWindowUpdater.Start();
            GhettoASM.main.load_prog(codeBox.Text.Split('\n').ToList<string>());
        }

        private void execBtn_Click(object sender, EventArgs e)
        {
            if (currentlyExecuting)
            {
                stopExecuting = true;
                return;
            }

            outputBox.Clear();
            GhettoASM.mem.reset();      //reset memory to default
            GhettoASM.G.reset_prog();   //reset all labels, instruction-lists, etc.

            execBtn.Text = "STOP!";
            ExecuteProgramIDE();
            execBtn.Text = "Execute";
        }

        public void ExecuteProgramIDE()
        {
            GhettoASM.G.printfunc = typeof(Main).GetMethod("DebugLog");

            GhettoASM.main.load_prog(codeBox.Text.Split('\n').ToList<string>());
            currentlyExecuting = true;
            while (!stopExecuting)
            {
                Application.DoEvents();

                if (stopExecuting)
                    goto exit;

                if (mem.ip > G.prog.Count - 1)
                    goto exit;

                if (delayedCheckBox.Checked)
                {
                    codeBox.SelectionColor= Color.Red;
                    codeBox.Selection = codeBox.GetLine((int)mem.ip - 1);

                    Thread.Sleep((int)delayUD.Value);
                }

                if (G.prog[(int)mem.ip].op == OP.EXIT)
                    goto exit;

                if (G.prog[(int)mem.ip].op != OP.NOP)
                {
                    Instruction ins = G.prog[(int)mem.ip];
                    if (!GhettoASM.main.exec_instruction(ins))
                        goto exit;
                }

                memoryWindow.Text = mem.dump_raw();
                mem.ip++;
            }

        exit:
            memoryWindow.Text = mem.dump_raw();
            stopExecuting = false;
            currentlyExecuting = false;
            //mem.dump_to_file();
        }

        public static void DebugLog(string msg)
        {
            main.outputBox.AppendText(msg);
            main.outputBox.ScrollToCaret();
        }

        private void tb_loadfromfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt|*.ga";
            ofd.Title = "Select .ga file";
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                codeBox.Text = File.ReadAllText(ofd.FileName);
            }

            GhettoASM.main.load_prog(codeBox.Text.Split('\n').ToList<string>());
        }

        private void tb_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.ga|*.ga";
            sfd.Title = "Where to save?";
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, codeBox.Text);  
                MessageBox.Show("Successfully saved at " + sfd.FileName, "File saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", Directory.GetCurrentDirectory() + "\\help.txt");
        }


        Style op_style = new TextStyle(Brushes.Green, null, FontStyle.Regular);
        Style var_style = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        Style str_style = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        Style lbl_style = new TextStyle(Brushes.DarkOrange, null, FontStyle.Regular);
        private void codeBox_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            codeBox.Range.SetStyle(op_style, @"\b(NOP|EXIT|MOV|ADD|SUB|CMP|JMP|JE|JNE|RET|PRNT|PRNTR|INPT|FFMEM)\b");
            codeBox.Range.SetStyle(var_style, @"\b(IP|R1|R2|R3|R4|R5|R6|R7|R8|R9|R10|R11|R12|R13|R14|R15|R16|R17|R18|R19)\b");
            codeBox.Range.SetStyle(str_style, "\".*?\"");
            codeBox.Range.SetStyle(lbl_style, @"#.*");
        }

        private void tb_new_Click(object sender, EventArgs e)
        {
            codeBox.Clear();
            outputBox.Clear();
            GhettoASM.mem.reset();
        }

        private void ramWindowUpdater_Tick(object sender, EventArgs e)
        {
            ramWindow.Text = BitConverter.ToString(mem.ram).Replace("-", " ");
        }

        private void compileToGAOBJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GhettoASM.main.load_prog(codeBox.Text.Split('\n').ToList<string>());

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.exe|*.exe";
            sfd.Title = "Where to save?";
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                byte[] compiled = GhettoASM.serializer.serialize_prog();
                int result = GhettoASM_Compiler.Compiler.compile_with_cs(sfd.FileName, File.ReadAllBytes("stub\\stub.bin"));
                if (result == 0)
                    MessageBox.Show("Successfully saved compiled program at " + sfd.FileName + "\n\nMake sure to execute it with the command prompt to see the output.", "Program compiled!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (result == -1)
                    MessageBox.Show("Failed to compile. I dont want to add proper error-handling so figure it out yourself", "Compilation failed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void testbtn_Click(object sender, EventArgs e)
        {
            GAObject test = serializer.deserialize_gaobj(File.ReadAllBytes("compiled"));
            MessageBox.Show("" + test.prog.Length);
        }
    }
}