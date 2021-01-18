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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private string areaname;

        public async void setupRecipesList(RecipesByAreaList ral, string name)
        {
            this.areaname = name;
            foreach(RecipesByAreaModel rbam in ral.meals)
            {
                listBox1.Items.Add(rbam.strMeal);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            openForm2();
        }

        private async void openForm2()
        {
            RecipesByAreaList rbal = await RecipesByCategoryDataProc.LoadMeals(this.areaname);
        
            Form2 form2 = new Form2();
            form2.setWindow(rbal.meals[listBox1.SelectedIndex].idMeal);
            form2.Show();


        }
    }
}
