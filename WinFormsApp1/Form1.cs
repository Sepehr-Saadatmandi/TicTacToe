using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
	public partial class Form1 : Form
	{
		public bool turn = true;
		public int turnCount = 0;
		public bool isAnyoneWin = false;
		private List<Tuple<int, int, int>> Lines { get; set; }
		private string[] Matrix;



		public Form1()
		{
			Matrix = new string[10];
			for (int i = 1; i < 10; i++)
			{
				Matrix[i] = "";
			}
			InitializeComponent();
			Lines = new List<Tuple<int, int, int>>();

			Lines.Add(new Tuple<int, int, int>(1, 2, 3));
			Lines.Add(new Tuple<int, int, int>(4, 5, 6));
			Lines.Add(new Tuple<int, int, int>(7, 8, 9));
			Lines.Add(new Tuple<int, int, int>(1, 4, 7));
			Lines.Add(new Tuple<int, int, int>(2, 5, 8));
			Lines.Add(new Tuple<int, int, int>(3, 6, 9));
			Lines.Add(new Tuple<int, int, int>(1, 5, 9));
			Lines.Add(new Tuple<int, int, int>(3, 5, 7));
		}
		private void Form1_Load(object sender, EventArgs e){}

		public void NewGameBtn(object sender, EventArgs e)
		{
			turn = true;
			turnCount = 0;
			isAnyoneWin = false;


			a1.Text = "";
			a2.Text = "";
			a3.Text = "";
			a4.Text = "";
			a5.Text = "";
			a6.Text = "";
			a7.Text = "";
			a8.Text = "";
			a9.Text = "";
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void btnClick(object sender, EventArgs e)
		{
			Button b = (Button)sender;

			var clickedBtn = Convert.ToInt32(b.Name.Replace("a", ""));
			if (Matrix[clickedBtn] != "")
			{
				return;
			}
			if (turn)
			{
				Matrix[clickedBtn] = "X";
				b.Text = "X";
			}
			else
			{
				Matrix[clickedBtn] = "O";
				b.Text = "O";
			}

			turnCount++;
			turn = !turn;

			var winner = GetWinner();

			if (winner == "X")
			{
				MessageBox.Show("X Wins");

			}
			else if (winner == "O")
			{
				MessageBox.Show("O Wins");
			}
			else if (turnCount >= 9)
			{
				MessageBox.Show("=====");
			}
			else
			{
				return;
			}

			turn = true;
			turnCount = 0;
			isAnyoneWin = false;

			a1.Text = "";
			a2.Text = "";
			a3.Text = "";
			a4.Text = "";
			a5.Text = "";
			a6.Text = "";
			a7.Text = "";
			a8.Text = "";
			a9.Text = "";

		}

		private string GetWinner()
		{
			foreach (var line in Lines)
			{
				if (Matrix[line.Item1] == Matrix[line.Item2] && Matrix[line.Item1] == Matrix[line.Item3])
				{
					if (Matrix[line.Item1] == "X")
					{
						return "X";
					}

					if (Matrix[line.Item1] == "O")
					{
						return "O";
					}
				}
			}
			return "";
		}

	}
}