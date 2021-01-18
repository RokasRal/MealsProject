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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private string ingName;

        public async void setupRecipesList(IngredientList il, string name)
        {
            this.ingName = name;
            foreach (IngredientModel im in il.meals)
            {
                listBox1.Items.Add(im.strMeal);
            }
        }   

        private async void openForm2()
        {
            IngredientList il = await RecipesByCategoryDataProc.LoadMealIngredients(this.ingName);

            Form2 form2 = new Form2();
            form2.setWindow(il.meals[listBox1.SelectedIndex].idMeal);
            form2.Show();


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            openForm2();
        }
    }
}
