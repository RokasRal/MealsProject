using DLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace MealsProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ApiHelper.InitializeClient(); //calling ApiHelper class in DLibrary to initialize AI client
            setupCategories();            //loading categories panel on the upper right of this window
            setupAreas();                 //loading areas panel on the lower right of this window
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Form2 f2 = new Form2(); //creating Form2 variable
            // new window position on screen
            f2.Top = 100;
            f2.Left = 200;
            
            f2.setWindow(0); //calling function in From2 class which is handling the ewindow setup
            f2.Show();       //making window visible
           
        }
        //---Functions for menu item handling
        private void jjToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You can use this application in couple ways. The button" +
                "at the bottom(Random Recipe) will open new window with random meal and how to make it represented." +
                "On the right of the main screen You can see category list and areas list, You can press on it and that will show " +
                "You recipies in that cateory or area. search button will help you to find recipe easier if you know the name", "How To Use", MessageBoxButtons.OK);
        }

        private void aboutUsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application show functionality of .net with windows forms and API Client. All the data and recipes are taken from TheMealDB.com", "About Us", MessageBoxButtons.OK);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If You have faced any issue while using this application - please contact us rokas.ralys@mif.stud.vu.lt", "If Any Problem", MessageBoxButtons.OK);
        }

        private async void setupAreas()
        {
            AreasList al = await AreasDataProc.LoadAreas(); //Assigning request results and showing them on the listbox
            foreach (AreasModel am in al.meals)
            {
                listBox2.Items.Add(am.strArea);
            }
        }

        private async void setupCategories()
        {
            CategoryList cl = await DataProccesorCat.LoadCategory();//Assigning request results and showing them on the listbox
            foreach (CategoryModel cm in cl.categories)
            {
                listBox1.Items.Add(cm.strCategory);
            }
        }

        private void upperT_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoryWin(); //If item in listbox is clicked tihis function handles it 
        }

        private async void categoryWin()
        {
            CategoryList cl = await DataProccesorCat.LoadCategory(); //assigning result to list
            Form3 form3 = new Form3();                               //creating new window
            form3.testukas(cl.categories[listBox1.SelectedIndex]);   //sending particular category name 
            form3.Show();                                            //making window visible
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            areasWin();//If item in listbox is clicked tihis function handles it 
        }
        private async void areasWin()
        {
            RecipesByAreaList rbal = await RecipesByCategoryDataProc.LoadMeals(listBox2.SelectedItem.ToString()); // assigning request's result
            Form4 form4 = new Form4();
            form4.setupRecipesList(rbal, listBox2.SelectedItem.ToString());
            form4.Text = listBox2.SelectedItem.ToString() + " Recipes List";
            form4.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }
    }
}
