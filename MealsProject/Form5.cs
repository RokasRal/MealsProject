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

namespace MealsProject
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadList(); // loads list of recpies with chosen ingredient
        }

        private async void loadList()
        {
            IngredientList il = await RecipesByCategoryDataProc.LoadMealIngredients(listBox1.SelectedItem.ToString());
            Form6 form6 = new Form6();
            form6.setupRecipesList(il, listBox1.SelectedItem.ToString()); //calling function that will contain list of recipes 
            form6.Text = "Recipes with main ingredient - " + listBox1.SelectedItem.ToString();
            form6.Show();
        }

        private async void loadList(string name)
        {
            IngredientList il = await RecipesByCategoryDataProc.LoadMealIngredients(name);
            Form6 form6 = new Form6();
            form6.setupRecipesList(il, name);
            form6.Text = "Recipes with main ingredient - " + name;
            form6.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0) // checker if something is written before pressing the button
            {
                loadList(textBox2.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                loadMealSearch(textBox1.Text);
            }
        }

        private async void loadMealSearch(string name)
        {
            Form2 f2 = new Form2();
            f2.setWindow(name);
            f2.Show();
        }
    }
}
