using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatNumber
{
    public partial class Form1 : Form
    {
        
        public Button[,] but = new Button[game.size, game.size];
        Game game = new Game(but);
        public int[] number = new int[size * size];
        public Form1()
        {
            InitializeComponent();
            InitializeNumber(number);
            InitializeButton(size);

        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }

    class Game
    {
        public int size = 4; // ?????
        void InitializeButton(int count,Button[,] but)
        {
            int k = 0;
            for (int i = 0; i < count; ++i)
            {
                for (int j = 0; j < count; ++j)
                {
                    but[i, j] = new Button();
                    but[i, j].Size = new Size(60, 60);
                    but[i, j].Location = new Point(i * 60, j * 60);
                    but[i, j].Text = number[k].ToString(); k++;
                    int x = i;
                    int y = j;
                    but[i, j].Click += (sender, but_event) =>
                    {
                        but_MouseClick(x, y);
                    };
                    Form1.Controls.Add(but[i, j]);
                }
            }
        }
        void but_MouseClick(int i, int j)
        {
            but[i, j].Enabled = false;
            but[i, j].Text = $"{i} {j}";

        }
        void InitializeNumber(int[] massive)
        {
            Random rnd = new Random();
            for (int i = 0; i < size * 2; i++)
            {
                massive[i] = rnd.Next(1, size * 2 + 1);
                for (int p = 0; p < size * 2; p++)
                {
                    if ((massive[i] == massive[p]) && (i != p)) { i--; break; } // числа не должны повторяться
                }
            }
            for (int j = size * 2; j < size * size; j++)
            {
                massive[j] = rnd.Next(1, size * 2 + 1);
                for (int p = size * 2; p < size * size; p++)
                {
                    if ((massive[j] == massive[p]) && (j != p)) { j--; break; } // числа не должны повторяться
                }
            }
        }

    }
}
