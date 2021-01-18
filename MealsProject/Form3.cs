using DLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;

namespace MealsProject
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private string catname;
       // RecipesByCategoryList ml;

        public void testukas(CategoryModel xx)
        {
            this.catname = xx.strCategory;
            recipiesByCategory(xx.strCategory);
            this.Text = xx.strCategory;
            label1.Text = xx.strCategory;
            pictureBox1.Load(xx.strCategoryThumb);
            textBox1.Text = xx.strCategoryDescription;
          
        }

        private async void recipiesByCategory(string catname)
        {

            RecipesByCategoryList ml = await RecipesByCategoryDataProc.LoadMeal(catname);
            foreach (RecipesByCategoryModel cm in ml.meals)
            {
                listBox1.Items.Add(cm.strMeal);
            }
  
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            openForm2();
        }

        private async void openForm2()
        {
            //MessageBox.Show(listBox1.SelectedItem.ToString());
           //  MessageBox.Show(ml.meals[listBox1.SelectedIndex].strMeal);
            RecipesByCategoryList ml = await RecipesByCategoryDataProc.LoadMeal(this.catname);
           // MessageBox.Show(ml.meals[listBox1.SelectedIndex].idMeal.ToString());
            Form2 form2 = new Form2();
            form2.setWindow(ml.meals[listBox1.SelectedIndex].idMeal);
            form2.Show();


        }
    }
}
