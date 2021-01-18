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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public async void setWindow(int num)
        {
            MealModel mm = await DataProccesor.LoadMeal(num);
            pictureBox1.Load(mm.strMealThumb);
            
            if(num == 0) this.Text = "Random Recipe - " + mm.strMeal; //same function is using for both random recipe and showing any other recipe
                else this.Text = "Recipe - " + mm.strMeal;

            label1.Text = mm.strMeal; //first label in ListBox for title of recipe
            fillListBox(mm); //calling function that will handle item in the right container
            textBox1.Text = mm.strInstructions;
            
        }
        public async void setWindow(string text)
        {
            MealModel mm = await DataProccesor.LoadMeal(text);
            pictureBox1.Load(mm.strMealThumb);

            this.Text = "Recipe - " + mm.strMeal;

            label1.Text = mm.strMeal; //first label in ListBox for title of recipe
            fillListBox(mm); //calling function that will handle item in the right container
            textBox1.Text = mm.strInstructions;

        }


        public async void fillListBox(MealModel mm)
        {
            while (true)
            {
                if (!String.IsNullOrEmpty(mm.strIngredient1)) listBox1.Items.Add(mm.strIngredient1 + " " + mm.strMeasure1);
                else break;
                if (!String.IsNullOrEmpty(mm.strIngredient2)) listBox1.Items.Add(mm.strIngredient2 + " " + mm.strMeasure2);
                else break;
                if (!String.IsNullOrEmpty(mm.strIngredient3)) listBox1.Items.Add(mm.strIngredient3 + " " + mm.strMeasure3);
                else break;
                if (!String.IsNullOrEmpty(mm.strIngredient4)) listBox1.Items.Add(mm.strIngredient4 + " " + mm.strMeasure4);
                else break;
                if (!String.IsNullOrEmpty(mm.strIngredient5)) listBox1.Items.Add(mm.strIngredient5 + " " + mm.strMeasure5);
                else break;
                if (!String.IsNullOrEmpty(mm.strIngredient6)) listBox1.Items.Add(mm.strIngredient6 + " " + mm.strMeasure6);
                else break;
                if (!String.IsNullOrEmpty(mm.strIngredient7)) listBox1.Items.Add(mm.strIngredient7 + " " + mm.strMeasure7);
                else break;
                if (!String.IsNullOrEmpty(mm.strIngredient8)) listBox1.Items.Add(mm.strIngredient8 + " " + mm.strMeasure8);
                else break;
                if (!String.IsNullOrEmpty(mm.strIngredient9)) listBox1.Items.Add(mm.strIngredient9 + " " + mm.strMeasure9);
                else break;
                if (!String.IsNullOrEmpty(mm.strIngredient10)) listBox1.Items.Add(mm.strIngredient10 + " " + mm.strMeasure10);
                else break;
                if (!String.IsNullOrEmpty(mm.strIngredient11)) listBox1.Items.Add(mm.strIngredient11 + " " + mm.strMeasure11);
                else break;
                if (!String.IsNullOrEmpty(mm.strIngredient12)) listBox1.Items.Add(mm.strIngredient12 + " " + mm.strMeasure12);
                else break;
                if (!String.IsNullOrEmpty(mm.strIngredient13)) listBox1.Items.Add(mm.strIngredient13 + " " + mm.strMeasure13);
                else break;
                if (!String.IsNullOrEmpty(mm.strIngredient14)) listBox1.Items.Add(mm.strIngredient14 + " " + mm.strMeasure14);
                else break;
                if (!String.IsNullOrEmpty(mm.strIngredient15)) listBox1.Items.Add(mm.strIngredient15 + " " + mm.strMeasure15);
                else break;
                if (!String.IsNullOrEmpty(mm.strIngredient16)) listBox1.Items.Add(mm.strIngredient16 + " " + mm.strMeasure16);
                else break;
                if (!String.IsNullOrEmpty(mm.strIngredient17)) listBox1.Items.Add(mm.strIngredient17 + " " + mm.strMeasure17);
                else break;
                if (!String.IsNullOrEmpty(mm.strIngredient18)) listBox1.Items.Add(mm.strIngredient18 + " " + mm.strMeasure18);
                else break;
                if (!String.IsNullOrEmpty(mm.strIngredient19)) listBox1.Items.Add(mm.strIngredient19 + " " + mm.strMeasure19);
                else break;
                if (!String.IsNullOrEmpty(mm.strIngredient20)) listBox1.Items.Add(mm.strIngredient20 + " " + mm.strMeasure20);
                else break;
            }
            
        }
    }
}
