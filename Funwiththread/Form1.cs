using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Funwiththread
{
    public partial class Form1 : Form
    {
        int state1, state2;
        Thread thread1, thread2, thread3;

        

        public Form1()
        {
            state1 = 0;
            state2 = 0;
            thread1 = new Thread(Thread1);
            thread2 = new Thread(Thread2);
            thread3 = Thread.CurrentThread;
            InitializeComponent();
            label7.Text = thread1.ThreadState.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (thread1.ThreadState == ThreadState.Unstarted)
            {
                thread1.Start();
            }
            else if(thread1.ThreadState == ThreadState.Suspended)
            {
                thread1.Resume();
            }
            else
            {
                thread1.Interrupt();
                thread1.Suspend();
            }
            if(thread1.ThreadState == ThreadState.Suspended&&thread2.ThreadState == ThreadState.Suspended)
            {
                try
                {
                    thread3.Resume();
                }
                catch
                {

                }
            }
            label7.Text = thread1.ThreadState.ToString();
            label8.Text = thread2.ThreadState.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (thread2.ThreadState == ThreadState.Unstarted)
            {
                thread2.Start();
            }
            else if (thread2.ThreadState == ThreadState.Suspended)
            {
                thread2.Resume();
            }
            else
            {
                thread2.Interrupt();
                thread2.Suspend();
            }
            label7.Text = thread1.ThreadState.ToString();
            label8.Text = thread2.ThreadState.ToString();
        }

        private void Thread1()
        {
            while (true)
            {
                Action action = (() => label3.Text = Convert.ToString(state1));
                if(InvokeRequired)
                    Invoke(action);
                state1++;
                try
                {
                    Thread.Sleep(1000);
                }
                catch
                {

                }
            }
        }
        private void Thread2()
        {
            while (true)
            {
                Action action2 = (() => label4.Text = Convert.ToString(state2));
                if (InvokeRequired)
                    Invoke(action2);
                state2++;
                try
                {
                    Thread.Sleep(2000);
                }
                catch
                {

                }
            }
        }

    }
}
