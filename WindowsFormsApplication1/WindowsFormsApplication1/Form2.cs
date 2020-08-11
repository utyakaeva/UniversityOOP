using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Variant6
{
    public partial class Form2 : Form
    {
        biblioteka books;
        Book b,b1,b2,b3,b4,b5;
        DataTable DT;
        public Form2()
        {
            InitializeComponent();
            books = new biblioteka();

            DT = new DataTable();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //b[6] = new Book("Война и Мри","Толстой Л.Н.", 1854);
            //b[7] = new Book("Мастер и Маргарита","Булгаков М.А. ", 1920);

            b = new Book("Капитанская дочка", " А. С. Пушкин", 1861);
            books.AddBook(b);
            b1 = new Book("Чёрный человек", "Есенин С ", 1900);
            books.AddBook(b1);
            b2 = new Book("Саша", "Некрасов Н.А", 1868);
            books.AddBook(b2);
            b3 = new Book("Бедная невеста", "Островский А.Н. ", 1850);
            books.AddBook(b3);
            b4 = new Book("Пузыри Земли", "Блок А.А. ", 1912);
            books.AddBook(b4);
            b5 = new Book("Мцыри", "Лермонтов М.Ю. ", 1835);
            books.AddBook(b5);
            DataTable dt = books.GetAllBooks();
            dataGridView1.DataSource = dt;
        }
        //добавление
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
            string n = form3.textBox1.Text;
            string a = form3.textBox2.Text;
            //string o1 = form3.textBox3.Text;
            int y = int.Parse(form3.textBox3.Text);
            b = new Book(n, a, y);
            books.AddBook(b);
            DataTable dt = books.GetAllBooks();
            dataGridView1.DataSource = dt;
           
        }
        //удаление
        private void button2_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            books.RemoveBook(i);
            DataTable dt = books.GetAllBooks();
            dataGridView1.DataSource = dt;

        }
        //редактирование
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            form4.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            form4.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
            form4.ShowDialog();

            string n = form4.textBox1.Text;
            string a = form4.textBox2.Text;
            int y = int.Parse(form4.textBox3.Text);
            b = new Book(n,a,y);
            int i = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            books.UpdBook(i, b);
            DataTable dt = books.GetAllBooks();
            dataGridView1.DataSource = dt;
        }
        
        
        
        
    }
}
